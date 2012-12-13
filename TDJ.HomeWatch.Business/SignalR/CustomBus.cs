using EasyNetQ;
using Microsoft.AspNet.SignalR;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDJ.HomeWatch.Business.SignalR
{
    public class CustomBus : ScaleoutMessageBus
    {
        readonly IBus _bus;
        public CustomBus(IDependencyResolver resolver, IBus bus)
            : base(resolver)
        {
            _bus = bus;
        }

        protected override Task Send(Message[] messages)
        {   
            IEnumerable<Task> result;
            result = messages.Select(s => Task.Factory.StartNew(() => 
            {
                try
                {
                    using (var ch = _bus.OpenPublishChannel())
                    {
                        ch.Publish<Message>(s);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }));
            return Task.WhenAll(result);
        }
    }
}
