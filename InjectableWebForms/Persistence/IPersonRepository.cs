namespace InjectableWebForms.Persistence {
    using System.Collections.Generic;
    using Domain;

    public interface IPersonRepository {
        IList<Person> Retrieve();
        void Create(Person person);
    }
}