namespace JSONMvcSample.Controllers {
    using System.Web.Mvc;
    using Models;

    [HandleError]
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult Save(PersonInputModel inputModel) {
            string message = string.Format("Created user '{0}' in the system.", inputModel.Name);
            return Json(new PersonViewModel {Message = message});
        }
    }
}