namespace Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class AutowireApplication : HttpApplication
    {
        public IServiceLocator ServiceLocator
        {
            get { return Application.Get("serviceLocator") as IServiceLocator; }
            set { Application.Set("serviceLocator", value); }
        }

        protected void Application_Start()
        {
            ServiceLocator = GetServiceLocator();

            RegisterComponents(ServiceLocator);
        }

        public override void Init()
        {
            base.Init();

            // Register all system components
            InitializeModules(ServiceLocator);
            InitializeComponents(ServiceLocator);
        }

        protected virtual void InitializeModules(IServiceLocator locator)
        {
            List<IHttpModule> modules = locator.ResolveServices<IHttpModule>();
            if (modules == null) return;

            foreach (IHttpModule module in modules)
            {
                module.Init(this);
            }
        }

        protected virtual void InitializeComponents(IServiceLocator locator)
        {
        }

        protected virtual void RegisterComponents(IServiceLocator locator)
        {
            Type[] webTypes = typeof (HttpContext).Assembly.GetTypes();
            Type webModule = typeof (IHttpModule);

            List<Type> moduleTypes = (from moduleType in webTypes
                                      where webModule.IsAssignableFrom(moduleType) &&
                                            moduleType != webModule &&
                                            moduleType.IsPublic
                                      select moduleType).ToList();

            foreach (Type moduleType in moduleTypes)
            {
                locator.Register<IHttpModule>(moduleType);
            }
        }

        protected virtual ServiceLocator GetServiceLocator()
        {
            return new ServiceLocator();
        }
    }
}