namespace InferredPoco.Controllers {
    using System.Web.Mvc;

    public class PocoInvoker : ControllerActionInvoker {
		protected override ActionResult CreateActionResult (ControllerContext controllerContext, ActionDescriptor actionDescriptor, object actionReturnValue) {
			if (!(actionReturnValue is ActionResult)) {
				controllerContext.Controller.ViewData.Model = actionReturnValue;
				return new PocoResult (actionReturnValue);
			}
			
			return base.CreateActionResult (controllerContext, actionDescriptor, actionReturnValue);
		}
	}
}
