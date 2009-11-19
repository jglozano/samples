namespace Web {
    using System;
    using System.Web;
    using Domain;
    using NHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;
    using Persistence;

    public abstract class NHSessionApplication : HttpApplication {

        protected abstract ISessionBuilder GetSessionBuilder();

        protected void Application_Start(object sender, EventArgs e) {
            ISessionBuilder builder = GetSessionBuilder();
            HttpContext.Current.Application[Constants.BuilderKey] = builder;

            BuildDatabase(builder);
            PopulateDatabase(builder);
        }

        private static void BuildDatabase(ISessionBuilder builder) {
            Configuration config = builder.GetConfiguration();
            var export = new SchemaExport(config);
            export.Drop(false, false);
            export.Create(true, true);
        }

        private static void PopulateDatabase(ISessionBuilder builder) {
            var repository = new PersonRepository(builder);

            for (int i = 0; i < 10; i++) {
                var p = new Person
                            {
                                FirstName = ((i % 2 == 0) ? "John" : "Mary"),
                                LastName = "Smith"
                            };
                repository.Create(p);
            }
        }
    }
}