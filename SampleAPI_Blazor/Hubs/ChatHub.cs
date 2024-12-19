using Microsoft.AspNetCore.SignalR;

namespace SampleAPI_Blazor.Hubs
{
    public class ChatHub : Hub
    {
        public string currentGroup { get; set; }
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("notifyNewMessage",message);
        }

        public async Task JoinGroup(string groupName)
        {
            currentGroup = groupName;
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await SendToGroup(groupName, $"User with connection Id : {Context.ConnectionId} has joined");
        }

        public async Task SendToGroup(string groupName, string message)
        {
            await Clients.Group(groupName).SendAsync("notifyTo_"+groupName, message);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, currentGroup);
            await SendToGroup(currentGroup, "Il nous a quitté, versons une petite larme...");
        }
    }
}
