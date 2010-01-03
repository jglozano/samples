namespace InjectableWebForms.Presenters.Impl {
    using System;
    using System.Collections.Generic;
    using Domain;
    using DTO;
    using Persistence;
    using Views;

    public class PersonListPresenter : IPersonListPresenter {
        public PersonListPresenter(IPersonRepository repository) {
            Repository = repository;
        }

        public IPersonRepository Repository { get; private set; }
        public IPersonListView View { get; private set; }

        #region IPersonListPresenter Members

        public void Associate(IPersonListView view) {
            if (view == null) {
                throw new ArgumentNullException("view");
            }
            View = view;
        }

        public void LoadList() {
            IList<Person> personList = Repository.Retrieve();

            var resultList = new List<PersonDTO>();
            foreach (Person person in personList) {
                resultList.Add(person.ToDTO());
            }

            View.PersonList = resultList;
        }

        #endregion
    }
}