using Microsoft.AspNetCore.Components;
using MurderMysteryParty.Models;
using MurderMysteryParty.Services;

namespace MurderMysteryParty.Components.Pages;

public partial class Admin : IDisposable
{
    [Inject] private GameSessionService GameSessionService { get; set; } = default!;
    [Inject] private CharacterService CharacterService { get; set; } = default!;
    [Inject] private RoundSignalRService RoundSignalRService { get; set; } = default!;
    [Inject] private AdminAuthService AdminAuthService { get; set; } = default!;

    private GameSession gameSession = new();
    private List<Character> allCharacters = new();
    private string adminPassword = string.Empty;
    private string? loginError;

    protected override async Task OnInitializedAsync()
    {
        await AdminAuthService.InitializeAsync();
        gameSession = GameSessionService.GetGameSession();
        allCharacters = CharacterService.GetAllCharacters();
        CharacterService.OnAssignmentsChanged += OnAssignmentsChanged;
        RoundSignalRService.AssignmentSyncRequested += OnAssignmentSyncRequested;
    }

    private async void OnAssignmentsChanged()
    {
        await InvokeAsync(StateHasChanged);
    }

    private async Task OnAssignmentSyncRequested()
    {
        if (AdminAuthService.IsAuthenticated)
        {
            await BroadcastCurrentAssignments();
        }
    }

    public void Dispose()
    {
        CharacterService.OnAssignmentsChanged -= OnAssignmentsChanged;
        RoundSignalRService.AssignmentSyncRequested -= OnAssignmentSyncRequested;
    }

    private async Task AuthenticateAdmin()
    {
        loginError = null;
        if (await AdminAuthService.LoginAsync(adminPassword))
        {
            adminPassword = string.Empty;
            StateHasChanged();
            return;
        }
        loginError = "Invalid password.";
    }

    private async Task Logout()
    {
        await AdminAuthService.LogoutAsync();
        adminPassword = string.Empty;
        loginError = null;
    }

    private async Task UnlockRound1()
    {
        GameSessionService.UnlockRound1();
        gameSession = GameSessionService.GetGameSession();
        await RoundSignalRService.SendRoundUnlockedAsync(1);
        StateHasChanged();
    }

    private async Task UnlockRound2A()
    {
        GameSessionService.UnlockRound2A();
        gameSession = GameSessionService.GetGameSession();
        await RoundSignalRService.SendRoundUnlockedAsync(2);
        StateHasChanged();
    }

    private async Task UnlockRound2B()
    {
        GameSessionService.UnlockRound2B();
        gameSession = GameSessionService.GetGameSession();
        await RoundSignalRService.SendRoundUnlockedAsync(3);
        StateHasChanged();
    }

    private void UnlockRound3A()
    {
        GameSessionService.UnlockRound3A();
        gameSession = GameSessionService.GetGameSession();
        StateHasChanged();
    }

    private void UnlockRound3B()
    {
        GameSessionService.UnlockRound3B();
        gameSession = GameSessionService.GetGameSession();
        StateHasChanged();
    }

    private async Task UnlockRound3()
    {
        GameSessionService.UnlockRound3();
        gameSession = GameSessionService.GetGameSession();
        await RoundSignalRService.SendRoundUnlockedAsync(4);
        StateHasChanged();
    }

    private async Task ResetAllRounds()
    {
        GameSessionService.ResetGame();
        gameSession = GameSessionService.GetGameSession();
        await RoundSignalRService.SendRoundsResetAsync();
        StateHasChanged();
    }

    private async Task ResetCharacterAssignments()
    {
        CharacterService.ResetCharacterAssignments();
        await RoundSignalRService.SendAllAssignmentsResetAsync();
        allCharacters = CharacterService.GetAllCharacters();
        StateHasChanged();
    }

    private async Task BroadcastCurrentAssignments()
    {
        var assignedCharacters = CharacterService.GetAllCharacters().Where(c => c.IsAssigned);
        foreach (var character in assignedCharacters)
            await RoundSignalRService.SendCharacterAssignmentChangedAsync(character.Id, true);

        var availableCharacters = CharacterService.GetAllCharacters().Where(c => !c.IsAssigned);
        foreach (var character in availableCharacters)
            await RoundSignalRService.SendCharacterAssignmentChangedAsync(character.Id, false);
    }

    private async Task ToggleDirectAssignment()
    {
        var newValue = !gameSession.IsDirectAssignmentAllowed;
        GameSessionService.SetDirectAssignmentAllowed(newValue);
        gameSession = GameSessionService.GetGameSession();
        await RoundSignalRService.SendDirectAssignmentAllowedAsync(newValue);
        StateHasChanged();
    }
}
