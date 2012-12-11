using EasyNetQ;
using Ninject;
using System.Threading.Tasks;

namespace TDJ.HomeWatch.Business
{
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
