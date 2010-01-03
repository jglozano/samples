namespace InjectableWebForms.Core {
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Compilation;
    using System.Web.UI;
    using Castle.Core;
    using Castle.Windsor;

    public class InjectableHandlerFactory : IHttpHandlerFactory {
        #region IHttpHandlerFactory Members

        public virtual IHttpHandler GetHandler(HttpContext context, string requestType, string virtualPath, string path) {
            var page = BuildManager.CreateInstanceFromVirtualPath(virtualPath, typeof (Page)) as IHttpHandler;

            return page == null ? null : ResolveInjectableProperties(page, ContainerGateway.WindsorContainer);
        }

        public void ReleaseHandler(IHttpHandler handler) {
            ReleaseInjectedProperties(handler, ContainerGateway.WindsorContainer);
        }

        #endregion

        public virtual IHttpHandler ResolveInjectableProperties(IHttpHandler instance, IWindsorContainer container) {
            if (instance == null) {
                return null;
            }

            Type instanceType = instance.GetType();
            instanceType.GetProperties()
                .Where(property => property.CanWrite && container.Kernel.HasComponent(property.PropertyType))
                .ForEach(property => property.SetValue(instance, container.Resolve(property.PropertyType), null));

            return instance;
        }

        public virtual void ReleaseInjectedProperties(IHttpHandler instance, IWindsorContainer container) {
            if (instance == null) {
                return;
            }

            Type instanceType = instance.GetType();

            instanceType.GetProperties()
                .Where(property => container.Kernel.HasComponent(property.PropertyType))
                .ForEach(property => container.Release(property.GetValue(instance, null)));
        }
    }
}