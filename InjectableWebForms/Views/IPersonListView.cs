namespace InjectableWebForms.Views {
    using System.Collections.Generic;
    using DTO;

    public interface IPersonListView {
        IList<PersonDTO> PersonList { get; set; }
    }
}