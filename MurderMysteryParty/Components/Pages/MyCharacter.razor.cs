using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MurderMysteryParty.Models;
using MurderMysteryParty.Services;

namespace MurderMysteryParty.Components.Pages;

public partial class MyCharacter : IDisposable
{
    [Inject] private CharacterService CharacterService { get; set; } = default!;
    [Inject] private GameSessionService GameSessionService { get; set; } = default!;
    [Inject] private IJSRuntime JSRuntime { get; set; } = default!;
    [Inject] private RoundSignalRService RoundSignalRService { get; set; } = default!;

    private Character? currentCharacter;
    private GameSession gameSession = new();
    private Timer? refreshMessageTimer;
    private bool showRefreshMessage;
    private bool isSyncing;
    private string notesText = string.Empty;

    protected override Task OnInitializedAsync()
    {
        gameSession = GameSessionService.GetGameSession();
        GameSessionService.OnGameStateChanged += OnGameStateChanged;
        CharacterService.OnAssignmentsChanged += OnAssignmentsChanged;
        return Task.CompletedTask;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await RefreshCharacterFromStorage();
            await LoadNotesAsync();
            StateHasChanged();
        }
    }

    private async void OnGameStateChanged()
    {
        await InvokeAsync(() => {
            gameSession = GameSessionService.GetGameSession();
            StateHasChanged();
        });
    }

    private async void OnAssignmentsChanged()
    {
        await InvokeAsync(async () => {
            if (currentCharacter != null)
            {
                var updatedCharacter = CharacterService.GetCharacterById(currentCharacter.Id);
                if (updatedCharacter != null && !updatedCharacter.IsAssigned)
                {
                    await JSRuntime.InvokeVoidAsync("localStorage.removeItem", "assignedCharacterId");
                    currentCharacter = null;
                }
            }
            StateHasChanged();
        });
    }

    private async Task RefreshCharacterFromStorage()
    {
        try
        {
            var characterIdString = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "assignedCharacterId");
            if (!string.IsNullOrEmpty(characterIdString) && int.TryParse(characterIdString, out int characterId))
            {
                var character = CharacterService.GetCharacterById(characterId);
                if (character != null)
                {
                    if (!character.IsAssigned)
                        CharacterService.TryAssignCharacter(characterId);
                    currentCharacter = character;
                }
                else
                {
                    await JSRuntime.InvokeVoidAsync("localStorage.removeItem", "assignedCharacterId");
                    currentCharacter = null;
                }
            }
            else
            {
                currentCharacter = null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving character assignment: {ex.Message}");
        }
    }

    private async Task LoadNotesAsync()
    {
        try
        {
            var key = currentCharacter != null ? $"playerNotes_{currentCharacter.Id}" : "playerNotes";
            notesText = await JSRuntime.InvokeAsync<string>("localStorage.getItem", key) ?? string.Empty;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading notes: {ex.Message}");
        }
    }

    private async Task SaveNotesAsync()
    {
        try
        {
            var key = currentCharacter != null ? $"playerNotes_{currentCharacter.Id}" : "playerNotes";
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", key, notesText ?? string.Empty);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving notes: {ex.Message}");
        }
    }

    private async Task RefreshGameState()
    {
        isSyncing = true;
        showRefreshMessage = false;
        StateHasChanged();

        await RoundSignalRService.SendAssignmentSyncRequestAsync();
        await Task.Delay(2000);

        gameSession = GameSessionService.GetGameSession();
        await RefreshCharacterFromStorage();

        isSyncing = false;
        showRefreshMessage = true;
        StateHasChanged();

        refreshMessageTimer?.Dispose();
        refreshMessageTimer = new Timer(_ =>
        {
            showRefreshMessage = false;
            InvokeAsync(StateHasChanged);
        }, null, TimeSpan.FromSeconds(2), Timeout.InfiniteTimeSpan);
    }

    private async Task ClearAssignment()
    {
        try
        {
            if (currentCharacter != null)
            {
                CharacterService.ResetCharacterAssignment(currentCharacter.Id);
                await RoundSignalRService.SendCharacterAssignmentChangedAsync(currentCharacter.Id, false);
                await JSRuntime.InvokeVoidAsync("localStorage.removeItem", "assignedCharacterId");
                currentCharacter = null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error clearing assignment: {ex.Message}");
        }
    }

    // Delegates to static formatter — keeps razor markup calling the same method names
    private string FormatRoundContent(string content) => RoundContentFormatter.FormatRound1Content(content);
    private string FormatRound2Content(string content) => RoundContentFormatter.FormatRound2Content(content);
    private string FormatRound3AContent(string content) => RoundContentFormatter.FormatRound3AContent(content);
    private string FormatRound3BContent(string content) => RoundContentFormatter.FormatRound3BContent(content);

    public void Dispose()
    {
        GameSessionService.OnGameStateChanged -= OnGameStateChanged;
        CharacterService.OnAssignmentsChanged -= OnAssignmentsChanged;
        refreshMessageTimer?.Dispose();
    }
}
