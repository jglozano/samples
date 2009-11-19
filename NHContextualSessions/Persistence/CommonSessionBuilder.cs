namespace Persistence {
    using System.Web;
    using NHibernate;

    public class CommonSessionBuilder : SessionBuilderBase {
        public override ISession CurrentSession {
            get {
                //Handle the ISession from the context
                var currentContext = HttpContext.Current;
                var session = currentContext.Items[Constants.SessionKey] as ISession;

                //HACK: Here to support the calling of sessions from the HttpApplication start                
                if (session == null) {
                    session = OpenSession();
                    currentContext.Items[Constants.SessionKey] = session;
                }

                return session;
            }
        }
    }
}