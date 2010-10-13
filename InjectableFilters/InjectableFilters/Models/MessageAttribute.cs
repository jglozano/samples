namespace InjectableFilters.Models
{
    using System.Web.Mvc;
    using Ninject;

    public class MessageAttribute : ActionFilterAttribute
    {
        // Tell Ninject to inject the type
        [Inject]
        public IMessageService MessageService {get; set;}

        public override void  OnActionExecuted(ActionExecutedContext filterContext)
        {
            var actionName = filterContext.ActionDescriptor.ActionName;
            filterContext.Controller.ViewModel.FilterMessage = MessageService.GetMessage(actionName);
        }
    }
}
