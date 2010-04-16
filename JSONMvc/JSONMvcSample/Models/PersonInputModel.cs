namespace JSONMvcSample.Models {
    using System;

    [Serializable]
    public class PersonInputModel {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
