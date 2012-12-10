using EasyNetQ;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace TDJ.HomeWatch.Business
{
    [Export(typeof(INetQ))]
    public class NetQ : INetQ
    {
        [Inject]
        public IBus Bus { get; set; }

        public async Task Publish(QRequest item)
        {
            using (var publishChannel = Bus.OpenPublishChannel())
            {
                publishChannel.Publish<QRequest>(item);
            }
        }

        public async Task<QResponse> Request(QRequest item)
        {
            QResponse response = null;
            using (var publish = Bus.OpenPublishChannel())
            {
                publish.Request<QRequest, QResponse>(item, resp => {
                    response = resp;
                });
            }
            return response;
        }

    }
}
