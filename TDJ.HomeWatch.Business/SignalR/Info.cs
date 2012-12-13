using EasyNetQ;
using Microsoft.AspNet.SignalR.Hubs;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDJ.HomeWatch.Business.SignalR
{


    [HubName("InfoHub")]
    public class Info : Hub
    {
        public INetQ Que { get; set; }

        [Inject]
        public Info(INetQ que)
        {
            Que = que;
        }

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
            //Clients.Group(groupName).sendMessage(message);
            Clients.All.sendMessage(message);

        }
    }
}
