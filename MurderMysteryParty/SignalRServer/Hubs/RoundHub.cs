using Microsoft.AspNetCore.SignalR;

namespace SignalRServer.Hubs;

public class RoundHub : Microsoft.AspNetCore.SignalR.Hub
{
    public async Task SendRoundUnlocked(int round)
    {
        await Clients.All.SendAsync("RoundUnlocked", round);
    }
}
