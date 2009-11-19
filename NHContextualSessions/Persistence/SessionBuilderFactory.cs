namespace Persistence {
    using System.Web;

    public static class SessionBuilderFactory {
        private static readonly ISessionBuilder commonBuilder = new CommonSessionBuilder();
        private static readonly ISessionBuilder contextualBuilder = new ContextualSessionBuilder();

        public static ISessionBuilder GetBuilder(bool isContextual) {
            return isContextual ? contextualBuilder : commonBuilder;
        }

        public static ISessionBuilder CurrentBuilder {
            get { return HttpContext.Current.Application[Constants.BuilderKey] as ISessionBuilder; }
        }
    }
}