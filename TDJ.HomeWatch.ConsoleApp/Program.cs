using Microsoft.AspNet.SignalR.Client.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDJ.HomeWatch.Business;

namespace TDJ.HomeWatch.ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            var connection = new HubConnection(Config.SignalRUri);
            connection.ConnectionId = Config.ConsoleID;
            var hub = connection.CreateHubProxy("InfoHub");

            connection.Start().ContinueWith(task => 
            {
                if (!task.IsFaulted)
                {
                    Console.WriteLine("Connected...");
                }
                else
                {
                    Console.WriteLine("Failed to start: {0}", task.Exception.GetBaseException());
                }
            }).Wait();

            hub.Invoke<string>("Send", "From the console");

            hub.On("fromServer", data => { 
                Console.WriteLine(data);
            });

            hub.On("addMessage", data =>
            {
                Console.WriteLine(data);
            });

            // Keep going until somebody hits 'x'
            while (true)
            {
                ConsoleKeyInfo ki = Console.ReadKey(true);
                if (ki.Key == ConsoleKey.X)
                {
                    break;
                }
            }
        }
    }
}
