
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Threading.Tasks;

namespace TDJ.HomeWatch.Business.SignalR
{
    public class Info : Hub
    {
        

        public void Subscribe(string groupName)
        {
            Groups.Add(Context.ConnectionId, groupName);
            Console.WriteLine("Subscribed to: " + groupName);
        }

        public Task Unsubscribe(string groupName)
        {
            return Clients.Group(groupName).leave(Context.ConnectionId);
        }
        public void Publish(string message, string groupName)
        {
            Clients.Group(groupName).sendMessage(message);
            //Clients.All.sendMessage(message);

        }

        public override Task OnDisconnected()
        {
            Clients.All.onDisconnected(Context.ConnectionId);
            return base.OnDisconnected();
        }
    }
}
