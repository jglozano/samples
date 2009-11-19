namespace WebFormClient
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using Common;

    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var autoWire = Context.ApplicationInstance as AutowireApplication;
            if (autoWire == null) return;

            RegisteredModules(autoWire);

            ModuleMessages(autoWire);
        }

        private void ModuleMessages(HttpApplication application)
        {
            var list = application.Context.Items["ModuleData"] as List<string>;
            var messageList = new List<ModuleMessage>();

            list.ForEach(msg => messageList.Add(new ModuleMessage { Value = msg }));

            moduleMessage.DataSource = messageList;
            moduleMessage.DataBind();
        }

        private void RegisteredModules(AutowireApplication autoWire)
        {
            List<IHttpModule> modules = autoWire.ServiceLocator.ResolveServices<IHttpModule>();

            var list = new List<WebModule>();
            modules.ForEach(module => list.Add(new WebModule { Name = module.GetType().Name }));

            moduleCount.Text = modules.Count.ToString();
            moduleList.DataSource = list;
            moduleList.DataBind();
        }
    }
}