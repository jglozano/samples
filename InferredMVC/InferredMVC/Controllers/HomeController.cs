namespace InferredMVC.Controllers
{
    using System.Web.Mvc;

    [HandleError]
    public class HomeController : InferredController
    {
        // No need for Index and About simple actions 
        // since the inferred controller will handle
        // the dispatching of the action to the correct
        // view.

        // Since this action is defined, it will not be processed by
        // the InferredActionInvoker class since it would be found by
        // it's parent class.
        public ActionResult Uninferred()
        {
            ViewData["Message"] = "I'm an un-inferred action!";
            return View();
        }
    }
}