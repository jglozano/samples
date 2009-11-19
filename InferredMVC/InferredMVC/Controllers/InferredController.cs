namespace InferredMVC.Controllers
{
    using System.Web.Mvc;

    public class InferredController : Controller
    {
        public InferredController()
        {
            ActionInvoker = new InferredActionInvoker();
        }
    }
}