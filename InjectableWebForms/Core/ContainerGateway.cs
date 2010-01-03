namespace InjectableWebForms.Core {
    using Castle.Windsor;

    public static class ContainerGateway {
        public static IWindsorContainer WindsorContainer { get; private set; }

        public static void Initialize() {
            WindsorContainer = new WindsorContainer();
        }
    }
}