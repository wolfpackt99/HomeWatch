using EasyNetQ;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDJ.HomeWatch.Business.SignalR
{
    //public class CustomBus : IMessageBus
    //{
    //    private IBus _bus;
    //    #region IMessageBus Members
    //    public CustomBus() {
    //        _bus = RabbitHutch.CreateBus(string.Format("host={0}"));
    //    }

    //    public Task Publish(Message message)
    //    {
    //        return Task.Factory.StartNew(() => {
    //            using (var channel = _bus.OpenPublishChannel())
    //            {
    //                channel.Publish<Message>(message);
    //            }    
    //        });
    //    }

    //    public IDisposable Subscribe(ISubscriber subscriber, string cursor, Func<MessageResult, Task<bool>> callback, int maxMessages)
    //    {

    //        _bus.
    //    }

    //    #endregion
    //}
}
