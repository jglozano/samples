namespace Web {
    using System;
    using System.Web;
    using NHibernate.Context;
    using Persistence;

    public class ContextualSessionModule : IHttpModule {

        public void Init(HttpApplication context) {
            context.BeginRequest += context_BeginRequest;
            context.EndRequest += context_EndRequest;
        }

        public void Dispose() {
        }

        private static void context_BeginRequest(object sender, EventArgs e) {
            var application = (HttpApplication)sender;
            var context = application.Context;

            BindSession(context);
        }

        private static void BindSession(HttpContext context) {
            var sessionBuilder = SessionBuilderFactory.CurrentBuilder;

            // Create a new session (it's the beginning of the request)
            var session = sessionBuilder.OpenSession();

            // Tell NH session context to use it
            ManagedWebSessionContext.Bind(context, session);
        }

        private static void context_EndRequest(object sender, EventArgs e) {
            var application = (HttpApplication)sender;
            var context = application.Context;

            UnbindSession(context);
        }

        private static void UnbindSession(HttpContext context) {
            var sessionBuilder = SessionBuilderFactory.CurrentBuilder;

            // Get the default NH session factory
            var factory = sessionBuilder.GetSessionFactory();

            // Give it to NH so it can pull the right session
            var session = ManagedWebSessionContext.Unbind(context, factory);

            if (session == null) return;
            session.Flush();
            session.Close();
        }
    }
}