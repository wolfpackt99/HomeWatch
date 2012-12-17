
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using RabbitMQ.Client;
using RabbitMQ.Client;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TDJ.HomeWatch.Business;
using TDJ.HomeWatch.Business.SignalR;
using SignalR.RabbitMQ;

namespace TDJ.Homewatch.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static ConnectionFactory factory = new RabbitMQ.Client.ConnectionFactory();

        protected void Application_Start()
        {

            RouteTable.Routes.MapHubs();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            factory.Endpoint = new RabbitMQ.Client.AmqpTcpEndpoint(Config.RabbitUri);
            var exchange = "SignalRExchange";

            GlobalHost.DependencyResolver.UseRabbitMq(factory, exchange);
            GlobalHost.HubPipeline.EnableAutoRejoiningGroups();
            
        }
    }
}