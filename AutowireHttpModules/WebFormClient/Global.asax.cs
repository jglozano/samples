namespace WebFormClient
{
    using System.Web;
    using Common;
    using Modules;

    public class Global : AutowireApplication
    {
        protected override void RegisterComponents(IServiceLocator locator)
        {
            base.RegisterComponents(locator);

            locator.Register<IHttpModule>(typeof(CustomModule));
            locator.Register<ModuleDependency, ModuleDependency>();
        }
    }
}