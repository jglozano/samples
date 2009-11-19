namespace Persistence {
    using NHibernate;

    public class ContextualSessionBuilder : SessionBuilderBase {
        private static ISession staticSession;

        public override ISession CurrentSession {
            get {

                ISession session;

                try {

                    // Get the default SessionFactory
                    var factory = GetSessionFactory();

                    //Let NH handle the 'churn' for you
                    session = factory.GetCurrentSession();

                    staticSession = null;
                } catch {
                    //HACK: Here to support the calling of sessions from the HttpApplication start
                    if (staticSession == null) {
                        staticSession = OpenSession();
                    }

                    session = staticSession;
                }

                return session;
            }
        }
    }
}
