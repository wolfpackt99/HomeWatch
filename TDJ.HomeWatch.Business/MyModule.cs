
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace TDJ.HomeWatch.Business
{
    public class MyModule : Ninject.Modules.NinjectModule
    {
        //public override void Load()
        //{
        //    Bind<IBus>().ToMethod(_ => RabbitHutch.CreateBus(string.Format("host={0}", Config.RabbitUri))).
        //    Bind<INetQ>().To<NetQ>();
        //}
        public override void Load()
        {
            
        }
    }
}
