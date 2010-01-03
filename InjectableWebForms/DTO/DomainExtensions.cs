namespace InjectableWebForms.DTO {
    using Domain;

    public static class DomainExtensions {
        public static PersonDTO ToDTO(this Person person) {
            return new PersonDTO {FirstName = person.FirstName, LastName = person.LastName};
        }

        public static Person ToDomain(this PersonDTO dto) {
            return new Person {FirstName = dto.FirstName, LastName = dto.LastName};
        }
    }
}