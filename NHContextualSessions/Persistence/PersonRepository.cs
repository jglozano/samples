namespace Persistence {
    using Domain;

    public class PersonRepository : RepositoryBase<Person> {
        public PersonRepository(ISessionBuilder sessionFactory)
            : base(sessionFactory) {
        }
    }
}
