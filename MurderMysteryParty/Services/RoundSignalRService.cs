using Microsoft.AspNetCore.SignalR.Client;

namespace MurderMysteryParty.Services;

public class RoundSignalRService : IAsyncDisposable
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<RoundSignalRService> _logger;
    private HubConnection? _connection;
    private bool _started;

    public RoundSignalRService(IConfiguration configuration, ILogger<RoundSignalRService> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public event Func<int, Task>? RoundUnlocked;
    public event Func<int, bool, Task>? CharacterAssignmentChanged;
    public event Func<Task>? RoundsReset;
    public event Func<Task>? AllAssignmentsReset;
    public event Func<Task>? Reconnected;

    public async Task StartAsync()
    {
        if (_connection?.State == HubConnectionState.Connected)
        {
            return;
        }

        var hubUrl = _configuration["SignalR:HubUrl"];
        if (string.IsNullOrWhiteSpace(hubUrl))
        {
            _logger.LogWarning("SignalR hub URL is not configured.");
            return;
        }

        if (_connection == null)
        {
            _connection = new HubConnectionBuilder()
                .WithUrl(hubUrl, options =>
                {
                    // Use LongPolling as fallback — iOS Safari aggressively kills WebSocket
                    // connections in background tabs, but LongPolling HTTP requests survive better.
                    options.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.WebSockets
                                      | Microsoft.AspNetCore.Http.Connections.HttpTransportType.LongPolling;
                })
                .WithAutomaticReconnect(new[] { TimeSpan.Zero, TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(30) })
                .Build();

            _connection.On<int>("RoundUnlocked", async round =>
            {
                if (RoundUnlocked != null)
                {
                    await RoundUnlocked.Invoke(round);
                }
            });

            _connection.On<int, bool>("CharacterAssignmentChanged", async (characterId, isAssigned) =>
            {
                if (CharacterAssignmentChanged != null)
                {
                    await CharacterAssignmentChanged.Invoke(characterId, isAssigned);
                }
            });

            _connection.On("RoundsReset", async () =>
            {
                if (RoundsReset != null)
                {
                    await RoundsReset.Invoke();
                }
            });

            _connection.On("AllAssignmentsReset", async () =>
            {
                if (AllAssignmentsReset != null)
                {
                    await AllAssignmentsReset.Invoke();
                }
            });

            // When automatic reconnect succeeds, notify listeners so they can re-sync state
            _connection.Reconnected += async _ =>
            {
                if (Reconnected != null)
                {
                    await Reconnected.Invoke();
                }
            };

            // When the connection is permanently lost, allow StartAsync to rebuild it
            _connection.Closed += _ =>
            {
                _started = false;
                return Task.CompletedTask;
            };
        }

        if (_started)
        {
            return;
        }

        try
        {
            await _connection.StartAsync();
            _started = true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to connect to SignalR hub at {HubUrl}", hubUrl);
        }
    }

    /// <summary>
    /// Ensures the connection is alive. If disconnected, attempts to reconnect.
    /// Returns true if connected.
    /// </summary>
    public async Task<bool> EnsureConnectedAsync()
    {
        if (_connection?.State == HubConnectionState.Connected)
        {
            return true;
        }

        _started = false;
        await StartAsync();
        return _connection?.State == HubConnectionState.Connected;
    }

    public async Task SendRoundUnlockedAsync(int round)
    {
        if (!await EnsureConnectedAsync()) return;
        await _connection!.SendAsync("SendRoundUnlocked", round);
    }

    public async Task SendCharacterAssignmentChangedAsync(int characterId, bool isAssigned)
    {
        if (!await EnsureConnectedAsync()) return;
        await _connection!.SendAsync("SendCharacterAssignmentChanged", characterId, isAssigned);
    }

    public async Task SendRoundsResetAsync()
    {
        if (!await EnsureConnectedAsync()) return;
        await _connection!.SendAsync("SendRoundsReset");
    }

    public async Task SendAllAssignmentsResetAsync()
    {
        if (!await EnsureConnectedAsync()) return;
        await _connection!.SendAsync("SendAllAssignmentsReset");
    }

    public async ValueTask DisposeAsync()
    {
        if (_connection != null)
        {
            await _connection.DisposeAsync();
        }
    }
}
