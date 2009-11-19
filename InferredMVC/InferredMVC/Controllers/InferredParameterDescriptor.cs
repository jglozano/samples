namespace InferredMVC.Controllers
{
    using System;
    using System.Web.Mvc;

    public class InferredParameterDescriptor : ParameterDescriptor
    {
        private readonly ActionDescriptor descriptor;

        public InferredParameterDescriptor(ActionDescriptor descriptor)
        {
            this.descriptor = descriptor;
        }

        public override ActionDescriptor ActionDescriptor
        {
            get { return descriptor; }
        }

        public override string ParameterName
        {
            get { return "actionName"; }
        }

        public override Type ParameterType
        {
            get { return typeof (string); }
        }
    }
}