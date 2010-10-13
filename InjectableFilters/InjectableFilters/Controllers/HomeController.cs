namespace InjectableFilters.Controllers
{
    using System.Web.Mvc;
    using Models;

    public class HomeController : Controller
    {
        [Message]
        public ActionResult Index()
        {
            ViewModel.Message = "Welcome to ASP.NET MVC!";

            return View();
        }
    }
}
