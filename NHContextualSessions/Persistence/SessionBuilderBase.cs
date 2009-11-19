namespace Persistence {
    using NHibernate;
    using NHibernate.Cfg;

    public abstract class SessionBuilderBase : ISessionBuilder {
        public const string NHibernateConfigFilename = @"nhibernate.config";
        private static ISessionFactory _sessionFactory;

        public ISession OpenSession() {
            ISessionFactory factory = GetSessionFactory();
            return factory.OpenSession();
        }

        public IStatelessSession OpenStatelessSession() {
            var factory = GetSessionFactory();
            return factory.OpenStatelessSession();
        }

        public abstract ISession CurrentSession { get; }

        public Configuration GetConfiguration() {
            var configuration = new Configuration();
            string filePath = GetConfigFilePath();
            configuration.Configure(filePath);
            return configuration;
        }

        public ISessionFactory GetSessionFactory() {
            if (_sessionFactory == null) {
                Configuration configuration = GetConfiguration();
                _sessionFactory = configuration.BuildSessionFactory();
            }

            return _sessionFactory;
        }

        private static string GetConfigFilePath() {
            return ConfigFileFinder.GetConfigFilePath("nhibernate", NHibernateConfigFilename);
        }
    }
}
