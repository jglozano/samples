namespace Web {
    using System;
    using System.Web;
    using NHibernate;
    using Persistence;

    public class CommonSessionModule : IHttpModule {

        public void Init(HttpApplication context) {
            context.BeginRequest += context_BeginRequest;
            context.EndRequest += context_EndRequest;
        }

        public void Dispose() {
        }

        private static void context_BeginRequest(object sender, EventArgs e) {
            var application = (HttpApplication)sender;
            var context = application.Context;

            var sessionBuilder = SessionBuilderFactory.CurrentBuilder;
            context.Items[Constants.SessionKey] = sessionBuilder.OpenSession();
        }

        private static void context_EndRequest(object sender, EventArgs e) {
            var application = (HttpApplication)sender;
            var context = application.Context;

            var session = context.Items[Constants.SessionKey] as ISession;
            if (session != null) {
                session.Flush();
                session.Close();
            }

            context.Items[Constants.SessionKey] = null;
        }
    }
}