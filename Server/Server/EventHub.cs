using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Server
{
    public class EventHub : Hub
    {        
        public override Task OnConnectedAsync()
        {
            Console.WriteLine("Client connected");
            return base.OnConnectedAsync();
        }
    }
}