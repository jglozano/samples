namespace DynamicView.Views {
    using System.Web.Mvc;
    using StructureMap;

    public abstract class DynamicPage<TModel> : WebViewPage<TModel> {
        public dynamic Service {
            get { return new DynamicLocator(ObjectFactory.Container); }
        }
    }

    public abstract class DynamicPage : WebViewPage {
        public dynamic Service {
            get { return new DynamicLocator(ObjectFactory.Container); }
        }
    }
}
