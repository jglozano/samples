namespace InjectableWebForms.Presenters.Impl {
    using System;
    using Domain;
    using Persistence;
    using Views;

    public class PersonCreatorPresenter : IPersonCreatorPresenter {
        public PersonCreatorPresenter(IPersonRepository repository) {
            Repository = repository;
        }

        public IPersonRepository Repository { get; private set; }
        public IPersonCreateView View { get; private set; }

        #region IPersonCreatorPresenter Members

        public void Associate(IPersonCreateView view) {
            if (view == null) {
                throw new ArgumentNullException("view");
            }

            View = view;
        }

        public void Create() {
            var domain = new Person {FirstName = View.FirstName, LastName = View.LastName};
            Repository.Create(domain);
        }

        #endregion
    }
}