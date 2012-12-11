using Microsoft.AspNet.SignalR;
using Ninject;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDJ.HomeWatch.Business.SignalR
{
    public class NinjectDependencyResolver : DefaultDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            if (kernel != null)
            {
                this._kernel = kernel;
                return;
            }
            else
            {
                throw new ArgumentNullException("kernel");
            }
        }

        public override object GetService(Type serviceType)
        {
            object obj = ResolutionExtensions.TryGet(this._kernel, serviceType, new IParameter[0]);
            object service = obj;
            if (obj == null)
            {
                service = base.GetService(serviceType);
            }
            return service;
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            return ResolutionExtensions.GetAll(this._kernel, serviceType, new IParameter[0]).Concat<object>(base.GetServices(serviceType));
        }
    }
}
