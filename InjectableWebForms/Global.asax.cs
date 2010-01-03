namespace InjectableWebForms {
    using System;
    using System.Web;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Core;
    using Persistence;
    using Persistence.Impl;
    using Presenters;
    using Presenters.Impl;

    public class Global : HttpApplication {
        protected void Application_Start(object sender, EventArgs e) {
            ContainerGateway.Initialize();

            RegisterComponents();
        }

        protected void Application_End(object sender, EventArgs e) {
            if (ContainerGateway.WindsorContainer != null) {
                ContainerGateway.WindsorContainer.Dispose();
            }
        }

        private static void RegisterComponents() {
            IWindsorContainer container = ContainerGateway.WindsorContainer;

            container.Register(Component.For<IPersonRepository>()
                                   .ImplementedBy<StaticPersonRepository>()
                                   .LifeStyle.Transient,
                                   
                               Component.For<IPersonListPresenter>()
                                   .ImplementedBy<PersonListPresenter>()
                                   .LifeStyle.Transient,
                                   
                               Component.For<IPersonCreatorPresenter>()
                                   .ImplementedBy<PersonCreatorPresenter>()
                                   .LifeStyle.Transient);
        }
    }
}