namespace WebFormClient.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Web;

    public class CustomModule : IHttpModule
    {
        public CustomModule(ModuleDependency dependency)
        {
            Dependency = dependency;
        }

        public ModuleDependency Dependency { get; set; }

        public void AddMessage(HttpApplication application, string eventName)
        {
            var messageList = (application.Context.Items["ModuleData"] as List<string>) ??
                new List<string>();

            var message = Dependency.GetMessage(eventName);
            messageList.Add(message);

            application.Context.Items["ModuleData"] = messageList;
        }

        #region IHttpModule Members

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
            context.AuthenticateRequest += context_AuthenticateRequest;
            context.PreRequestHandlerExecute += context_PreRequestExecute;
        }

        public void Dispose()
        {
        }

        #endregion

        private void context_AuthenticateRequest(object sender, EventArgs e)
        {
            var application = sender as HttpApplication;
            AddMessage(application, "AuthenticateRequest");    
        }
        
        private void context_PreRequestExecute(object sender, EventArgs e)
        {
            var application = sender as HttpApplication;
            AddMessage(application, "PreRequestExecute");
        }

        private void context_BeginRequest(object sender, EventArgs e)
        {
            var application = sender as HttpApplication;
            AddMessage(application, "BeginRequest");
        }
    }
}