using Microsoft.AspNet.SignalR.Hubs;
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
            Clients.All.addMessage(message);
        }
    }
}
