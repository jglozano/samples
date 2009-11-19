namespace CustomSessions {
    using Persistence;
    using Web;

    public class Global : NHSessionApplication {
        protected override ISessionBuilder GetSessionBuilder() {
            return SessionBuilderFactory.GetBuilder(false);
        }
    }
}