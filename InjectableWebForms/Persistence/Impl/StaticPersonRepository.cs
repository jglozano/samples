namespace InjectableWebForms.Persistence.Impl {
    using System;
    using System.Collections.Generic;
    using Domain;

    public class StaticPersonRepository : IPersonRepository {
        private static readonly IList<Person> personList = new List<Person>();

        static StaticPersonRepository() {
            LoadList();
        }

        #region IPersonRepository Members

        public IList<Person> Retrieve() {
            return personList;
        }

        public void Create(Person person) {
            if (person == null) throw new ArgumentNullException("person");
            personList.Add(person);
        }

        #endregion

        private static void LoadList() {
            for (int i = 0; i < 5; i++) {
                var person = new Person {FirstName = (i%2 == 0) ? "John" : "James", LastName = "Smith"};
                personList.Add(person);
            }
        }
    }
}