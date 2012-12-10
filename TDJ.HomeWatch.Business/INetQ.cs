using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDJ.HomeWatch.Business
{
    public interface INetQ
    {
        Task Publish(QRequest item);
        Task<QResponse> Request(QRequest item);
    }
}
