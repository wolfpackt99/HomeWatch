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
        public void Send(string message)
        {
            //var rb = RabbitHutch.CreateBus(string.Format("host={0}", Config.RabbitUri));
            //using (var ch = rb.OpenPublishChannel())
            //{
            //    ch.Publish<string>(message);
            //}
            Clients.All.addMessage(message);
        }

        public void ToConsole(string message)
        {
            Clients.All.fromServer(message);
        }
    }
}
