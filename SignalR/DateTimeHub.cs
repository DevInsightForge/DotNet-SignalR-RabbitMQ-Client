using Microsoft.AspNetCore.SignalR;

namespace test_dot.SignalR;
public class DateTimeHub : Hub
{

    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();

        // Start sending datetime messages at 1-second intervals
        await SendDateTime();
    }

    public async Task SendDateTime()
    {
        while (true)
        {
            // Send the datetime to all connected clients
            await Clients.All.SendAsync("ReceiveDateTime", DateTime.Now);

            // Wait for 1 second
            await Task.Delay(1000);
        }
    }
}
