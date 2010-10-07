namespace InferredPoco
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using InferredPoco.Controllers;

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Person", action = "Index", id = "" });
        }

        protected void Application_Start()
        {
            // Supply our own controller factory to avoid inheritence overriding of
            // GetActionInvoker() for ControllerBase
            ControllerBuilder.Current.SetControllerFactory(new InferredControllerFactory());

            RegisterRoutes(RouteTable.Routes);
        }
    }
}
