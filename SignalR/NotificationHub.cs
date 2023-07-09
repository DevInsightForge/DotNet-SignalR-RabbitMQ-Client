using Microsoft.AspNetCore.SignalR;

namespace test_dot.SignalR
{
    public class NotificationHub : Hub

    {
        //private static Dictionary<string, string> userConnectionMap = new Dictionary<string, string>();

        public async Task SendNotification(string notification)
        {
            await Clients.All.SendAsync("ReceiveNotification", notification);
        }

        //public override async Task OnConnectedAsync()
        //{
        //    // Associate the user ID with the connection ID when a user connects
        //    //var userId = Context.UserIdentifier;
        //    //var connectionId = Context.ConnectionId;

        //    //userConnectionMap[userId] = connectionId;
        //    Console.WriteLine(Context.ConnectionId);

        //    await base.OnConnectedAsync();
        //}

        //public override async Task OnDisconnectedAsync(Exception? exception)
        //{
        //    // Remove the user ID from the connection map when a user disconnects
        //    //var userId = Context.UserIdentifier;

        //    //if (userConnectionMap.ContainsKey(userId))
        //    //{
        //    //    userConnectionMap.Remove(userId);
        //    //}

        //    await base.OnDisconnectedAsync(exception);
        //}

        //public async Task SendNotificationToUser(string userId, string message)
        //{
        //    if (userConnectionMap.TryGetValue(userId, out var connectionId))
        //    {
        //        await Clients.Client(connectionId).SendAsync("ReceiveNotification", message);
        //    }
        //}

        //public async Task AddToRoleGroup(string roleName)
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, roleName);
        //}

        //public async Task SendNotificationToRole(string roleName, string message)
        //{
        //    await Clients.Group(roleName).SendAsync("ReceiveNotification", message);
        //}

    }
}
