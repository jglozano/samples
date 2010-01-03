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

        protected void Page_Init(object sender, EventArgs e) {
            ListPresenter.Associate(this);
            CreatorPresenter.Associate(this);
        }

        protected void Page_Load(object sender, EventArgs e) {
            LoadPersonList();
        }

        private void LoadPersonList() {
            ListPresenter.LoadList();
        }

        public string FirstName {
            get { return personFirstName.Text; }
            set { personFirstName.Text = value; }
        }

        public string LastName {
            get { return personLastName.Text; }
            set { personLastName.Text = value; }
        }

        public IList<PersonDTO> PersonList {
            get { return personGrid.DataSource as IList<PersonDTO>; }
            set {
                personGrid.DataSource = value;
                personGrid.DataBind();
            }
        }

        protected void personCreate_Click(object sender, EventArgs e) {
            CreatePerson();
            LoadPersonList();
        }

        protected virtual void CreatePerson() {
            CreatorPresenter.Create();
        }
    }
}