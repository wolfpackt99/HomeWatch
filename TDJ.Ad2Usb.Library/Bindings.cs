using Common.Logging;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDJ.Ad2Usb.Library
{
    [Export(typeof(Bindings))]
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<ILog>().ToMethod(t => Common.Logging.LogManager.GetCurrentClassLogger());
            Kernel.Bind<IMessageParser>().To(typeof(MessageParser));
        }
    }
}
