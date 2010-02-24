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

namespace InjectableWebForms {
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using DTO;
    using Presenters;
    using Views;

    public partial class DefaultPage : Page, IPersonCreateView, IPersonListView {
        public IPersonListPresenter ListPresenter { get; set; }
        public IPersonCreatorPresenter CreatorPresenter { get; set; }

        #region IPersonCreatorView Section

        public string FirstName {
            get { return personFirstName.Text; }
            set { personFirstName.Text = value; }
        }

        public string LastName {
            get { return personLastName.Text; }
            set { personLastName.Text = value; }
        }

        #endregion

        #region IPersonListView Section

        public IList<PersonDTO> PersonList {
            get { return personGrid.DataSource as IList<PersonDTO>; }
            set {
                personGrid.DataSource = value;
                personGrid.DataBind();
            }
        }

        #endregion

        protected void Page_Init(object sender, EventArgs e) {
            // Manually wire up the presenters for the page to use
            ListPresenter.Associate(this);
            CreatorPresenter.Associate(this);
        }

        protected void Page_Load(object sender, EventArgs e) {
            LoadPersonList();
        }

        protected void personCreate_Click(object sender, EventArgs e) {
            CreatePerson();
            LoadPersonList();
        }

        protected virtual void CreatePerson() {
            CreatorPresenter.Create();
        }

        private void LoadPersonList() {
            ListPresenter.LoadList();
        }
    }
}
