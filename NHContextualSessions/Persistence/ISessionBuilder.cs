namespace Persistence {
    using NHibernate;
    using NHibernate.Cfg;

    public interface ISessionBuilder {
        ISession CurrentSession { get; }
        ISession OpenSession();
        IStatelessSession OpenStatelessSession();
        ISessionFactory GetSessionFactory();
        Configuration GetConfiguration();
    }
}