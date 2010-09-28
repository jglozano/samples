namespace inferredPoco {
	using System;
	using System.Web.Mvc;
	using System.Web.Routing;
	
	public class InferredControllerFactory : DefaultControllerFactory {
		protected override IController GetControllerInstance (RequestContext requestContext, Type controllerType) {
			if (controllerType == null) {
                // this will make sure that the MVC framework throws the corresponding
                // exception for a non-registered controller
                return base.GetControllerInstance(requestContext, controllerType);
            }

			var instance = base.GetControllerInstance(requestContext, controllerType);
            var controller = instance as Controller;

            // If you inherit from controller, supply our own invoker
            if (controller != null) {
                controller.ActionInvoker = new PocoInvoker();
            }

            return controller;
		}
	}
}
