using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MurderMysteryParty.Models;
using MurderMysteryParty.Services;

namespace MurderMysteryParty.Components.Pages;

public partial class CharacterDetails
{
    [Inject] private CharacterService CharacterService { get; set; } = default!;
    [Inject] private RoundSignalRService RoundSignalRService { get; set; } = default!;
    [Inject] private IJSRuntime JSRuntime { get; set; } = default!;
    [Inject] private NavigationManager NavigationManager { get; set; } = default!;

    [Parameter] public int CharacterId { get; set; }

    private Character? character;
    private string? statusMessage;
    private string? assignedCharacterId;
    private string qrCodeUrl = string.Empty;
    private bool isAssignDisabled;
    private bool autoAssignHandled;
    private bool showCloseHint;

    protected override async Task OnParametersSetAsync()
    {
        character = CharacterService.GetCharacterById(CharacterId);
        qrCodeUrl = BuildQrCodeUrl();
        await LoadAssignmentState();
        UpdateStatusMessage();
        await TryAutoAssign();
    }

    private void UpdateStatusMessage()
    {
        if (character == null)
        {
            statusMessage = "? Character not found. Please choose a different character.";
            return;
        }

        if (assignedCharacterId == CharacterId.ToString())
        {
            statusMessage = $"? You are currently assigned as {character.Name}.";
            return;
        }

        if (IsAssignedToDifferentCharacter())
        {
            statusMessage = "? You already have a different character assigned. Clear your current assignment first.";
            return;
        }

        if (character.IsAssigned)
        {
            statusMessage = $"? {character.Name} is already assigned to another player. Please choose a different character.";
            return;
        }

        statusMessage = $"Tap the button below to claim {character.Name}!";
    }

    private string BuildQrCodeUrl()
    {
        var characterUrl = $"{NavigationManager.BaseUri}character/{CharacterId}?assign=true";
        return $"https://api.qrserver.com/v1/create-qr-code/?size=220x220&data={Uri.EscapeDataString(characterUrl)}";
    }

    private async Task LoadAssignmentState()
    {
        assignedCharacterId = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "assignedCharacterId");

        if (!string.IsNullOrWhiteSpace(assignedCharacterId) && int.TryParse(assignedCharacterId, out int storedId))
        {
            var storedCharacter = CharacterService.GetCharacterById(storedId);
            if (storedCharacter != null && !storedCharacter.IsAssigned)
                CharacterService.TryAssignCharacter(storedId);
        }

        isAssignDisabled = character == null || IsAssignedToDifferentCharacter() || (character.IsAssigned && assignedCharacterId != CharacterId.ToString());
    }

    private bool IsAssignedToDifferentCharacter()
    {
        return !string.IsNullOrWhiteSpace(assignedCharacterId) && assignedCharacterId != CharacterId.ToString();
    }

    private async Task TryAutoAssign()
    {
        if (autoAssignHandled || character == null)
            return;

        var uri = new Uri(NavigationManager.Uri);
        var query = uri.Query.TrimStart('?').Split('&', StringSplitOptions.RemoveEmptyEntries);
        var shouldAssign = query.Any(item => string.Equals(item, "assign=true", StringComparison.OrdinalIgnoreCase));
        if (!shouldAssign)
            return;

        autoAssignHandled = true;
        await AssignCharacter();

        bool hasOtherTab = false;
        try
        {
            hasOtherTab = await JSRuntime.InvokeAsync<bool>("hasOtherTabOpen");
        }
        catch
        {
            // BroadcastChannel not available — assume no other tab
        }

        if (hasOtherTab)
        {
            if (!string.IsNullOrWhiteSpace(statusMessage))
            {
                var style = GetStatusClass() switch
                {
                    "status-success" => "success",
                    "status-error" => "error",
                    "status-warning" => "warning",
                    _ => "info"
                };
                try
                {
                    await JSRuntime.InvokeVoidAsync("sendToastToOtherTabs", statusMessage, style);
                }
                catch
                {
                    // ignore if BroadcastChannel unavailable
                }
            }

            await Task.Delay(1500);
            try
            {
                await JSRuntime.InvokeVoidAsync("window.close");
            }
            catch
            {
                // ignore — some browsers throw on window.close()
            }

            await Task.Delay(500);
            showCloseHint = true;
            StateHasChanged();
        }
    }

    private async Task AssignCharacter()
    {
        if (character == null)
            return;

        await LoadAssignmentState();

        if (IsAssignedToDifferentCharacter())
        {
            statusMessage = "? You already have a different character assigned. Clear your current assignment first.";
            return;
        }

        if (character.IsAssigned && assignedCharacterId != CharacterId.ToString())
        {
            statusMessage = $"? {character.Name} is already assigned to another player. Please choose a different character.";
            await LoadAssignmentState();
            return;
        }

        if (assignedCharacterId == CharacterId.ToString())
        {
            statusMessage = $"?? You are already assigned as {character.Name}.";
            return;
        }

        if (!CharacterService.TryAssignCharacter(CharacterId))
        {
            statusMessage = $"? {character.Name} was just claimed by another player. Please choose a different character.";
            await LoadAssignmentState();
            UpdateStatusMessage();
            StateHasChanged();
            return;
        }

        await JSRuntime.InvokeVoidAsync("localStorage.setItem", "assignedCharacterId", CharacterId.ToString());
        await RoundSignalRService.SendCharacterAssignmentChangedAsync(CharacterId, true);
        assignedCharacterId = CharacterId.ToString();
        statusMessage = $"?? Success! You are now assigned as {character.Name}.";
        await LoadAssignmentState();
    }

    private string GetStatusClass()
    {
        if (statusMessage == null) return "";
        if (statusMessage.Contains("You are currently assigned as") || statusMessage.Contains("Success!"))
            return "status-success";
        if (statusMessage.Contains("You are already assigned as"))
            return "status-warning";
        if (statusMessage.Contains("Please") || statusMessage.Contains("Clear"))
            return "status-error";
        return "";
    }
}
