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
    public static class DependencyResolverExtensions
    {
        public static IDependencyResolver UseRabbitServiceBus(this IDependencyResolver resolver)
        {

            var lazyBus = new Lazy<CustomBus>(() => new CustomBus(resolver, RabbitHutch.CreateBus(string.Format("host={0}", Config.RabbitUri))));
            resolver.Register(typeof(IMessageBus), () => lazyBus.Value);

            return resolver;
        }
    }
}
