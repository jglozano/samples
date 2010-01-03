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