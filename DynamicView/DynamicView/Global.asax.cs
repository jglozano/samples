using System.Web.Mvc;
using System.Web.Routing;

namespace DynamicView
{
    using Models;
    using StructureMap;

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            // Wire up the service
            ObjectFactory.Initialize(init => init.For<IMessageService>().Use<MessageService>().Named("Messages"));
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
