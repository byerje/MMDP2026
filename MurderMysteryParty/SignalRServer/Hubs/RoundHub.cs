using Microsoft.AspNetCore.SignalR;

namespace SignalRServer.Hubs;

public class RoundHub : Microsoft.AspNetCore.SignalR.Hub
{
    public async Task SendRoundUnlocked(int round)
    {
        await Clients.All.SendAsync("RoundUnlocked", round);
    }

    public async Task SendCharacterAssignmentChanged(int characterId, bool isAssigned)
    {
        await Clients.All.SendAsync("CharacterAssignmentChanged", characterId, isAssigned);
    }

    public async Task SendRoundsReset()
    {
        await Clients.All.SendAsync("RoundsReset");
    }

    public async Task SendAllAssignmentsReset()
    {
        await Clients.All.SendAsync("AllAssignmentsReset");
    }

    public async Task SendAssignmentSyncRequest()
    {
        await Clients.All.SendAsync("AssignmentSyncRequested");
    }

    public async Task SendDirectAssignmentAllowed(bool allowed)
    {
        await Clients.All.SendAsync("DirectAssignmentAllowedChanged", allowed);
    }
}
