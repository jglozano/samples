namespace JSONModelBinderSample {
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Models;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );
        }

        protected void Application_Start() {
            // Set the model binder to be the global one (support json and non-json requests)
            ModelBinders.Binders.DefaultBinder = new JsonModelBinder();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}