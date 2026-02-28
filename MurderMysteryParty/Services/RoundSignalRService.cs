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

    public async Task StartAsync()
    {
        if (_started)
        {
            return;
        }

        var hubUrl = _configuration["SignalR:HubUrl"];
        if (string.IsNullOrWhiteSpace(hubUrl))
        {
            _logger.LogWarning("SignalR hub URL is not configured.");
            return;
        }

        _connection = new HubConnectionBuilder()
            .WithUrl(hubUrl)
            .WithAutomaticReconnect()
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

    public async Task SendRoundUnlockedAsync(int round)
    {
        if (_connection == null || _connection.State != HubConnectionState.Connected)
        {
            await StartAsync();
        }

        if (_connection == null || _connection.State != HubConnectionState.Connected)
        {
            return;
        }

        await _connection.SendAsync("SendRoundUnlocked", round);
    }

    public async Task SendCharacterAssignmentChangedAsync(int characterId, bool isAssigned)
    {
        if (_connection == null || _connection.State != HubConnectionState.Connected)
        {
            await StartAsync();
        }

        if (_connection == null || _connection.State != HubConnectionState.Connected)
        {
            return;
        }

        await _connection.SendAsync("SendCharacterAssignmentChanged", characterId, isAssigned);
    }

    public async ValueTask DisposeAsync()
    {
        if (_connection != null)
        {
            await _connection.DisposeAsync();
        }
    }
}
