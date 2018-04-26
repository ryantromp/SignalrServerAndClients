using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Server
{
    public class EventHub : Hub
    {        
        public override Task OnConnectedAsync()
        {
            this.Clients.Client(this.Context.ConnectionId).SendAsync("serverMessage", "Welcome to SignalR.");
            Console.WriteLine("Client connected");
            return base.OnConnectedAsync();
        }
    }
}