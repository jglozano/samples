namespace MvcApplication
{
    using System.Web.Mvc;
    using MvcTurbine;
    using MvcTurbine.ComponentModel;
    using MvcTurbine.Windsor;
	using MvcTurbine.Web;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : TurbineApplication
    {
        static MvcApplication()
        {
            ServiceLocatorManager.SetLocatorProvider(() => new WindsorServiceLocator());
        }
    }
}