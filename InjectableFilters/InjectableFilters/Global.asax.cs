namespace InjectableFilters {
    using System.Web.Mvc;
    using System.Web.Routing;
    using Models;
    using Ninject;

    public class MvcApplication : System.Web.HttpApplication {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            RegisterFilterProviders(FilterProviders.Providers);
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        public static void RegisterFilterProviders(FilterProviderCollection providers) {
            // Remove the old provider since we do not want dubplicates
            providers.Remove<FilterAttributeFilterProvider>();

            // Create the IKernel and register the services
            var kernel = new StandardKernel();
            kernel.Bind<IMessageService>().To<MessageService>();

            // Register the provider with the MVC3 runtime
            providers.Add(new InjectableFilterProvider(kernel));
        }
    }
}
