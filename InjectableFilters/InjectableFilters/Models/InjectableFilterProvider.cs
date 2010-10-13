namespace InjectableFilters.Models
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Ninject;

    public class InjectableFilterProvider : FilterAttributeFilterProvider
    {
        public IKernel Kernel { get; private set; }

        public InjectableFilterProvider(IKernel kernel)
        {
            Kernel = kernel;
        }

        public override IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(controllerContext, actionDescriptor);

            foreach (var filter in filters)
            {
                Kernel.Inject(filter.Instance);
            }

            return filters;
        }
    }
}