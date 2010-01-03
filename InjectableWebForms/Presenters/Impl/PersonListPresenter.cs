#region License

//
// Author: Javier Lozano <javier@lozanotek.com>
// Copyright (c) 2009-2010, lozanotek, inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

#endregion

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