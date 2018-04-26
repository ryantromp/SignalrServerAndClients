using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;

namespace ConsoleClient
{
    class Program
    {
        private static async Task Main()
        {
            try
            {
                const string connectionUrl = "http://localhost:9000/eventHub";

                var hubConnection = new HubConnectionBuilder()
                    .WithUrl(connectionUrl)
                    .WithConsoleLogger(LogLevel.Trace)
                    .Build();

                hubConnection.On<dynamic>("serverMessage", message => Console.WriteLine($"server message : {message}"));

                await hubConnection.StartAsync();
                
                Console.WriteLine("Connected to signalR server...");
                Console.ReadKey();
            }
            catch (HubException exception)
            {
                Console.WriteLine(exception);
                Console.ReadKey();
            }
        }
    }
}
