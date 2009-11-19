namespace CustomSessions {
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using Domain;
    using Persistence;

    public partial class _Default : Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                BindPeople();
            }
        }

        private void BindPeople() {
            ISessionBuilder builder = SessionBuilderFactory.CurrentBuilder;
            var repository = new PersonRepository(builder);

            IList<Person> list = repository.RetrieveAll();
            personGrid.DataSource = list;
            personGrid.DataBind();
        }
    }
}