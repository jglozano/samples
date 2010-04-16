namespace JSONMvcSample.Models {
    using System;
    using System.ComponentModel.DataAnnotations;

    [Serializable]
    public class PersonInputModel {
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
    }
}