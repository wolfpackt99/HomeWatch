[assembly: WebActivator.PreApplicationStartMethod(typeof(TDJ.Homewatch.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(TDJ.Homewatch.Web.App_Start.NinjectWebCommon), "Stop")]
[assembly: WebActivator.PostApplicationStartMethod(typeof(TDJ.Homewatch.Web.App_Start.NinjectWebCommon), "PostApplicationStart")]

namespace TDJ.Homewatch.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using TDJ.HomeWatch.Business;
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hosting;
    using Microsoft.AspNet.SignalR.Infrastructure;
    using TDJ.HomeWatch.Business.SignalR;
    using System.Web.Routing;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);

            RouteTable.Routes.MapHubs();
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        public static void PostApplicationStart()
        {
            var kernel = new StandardKernel();
            GlobalHost.DependencyResolver = new NinjectDependencyResolver(kernel);
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            
            kernel.Load(new MyModule());
        }        
    }
}
