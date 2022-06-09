using API_Test.Models.Base_Class;

namespace API_Test.Models
{
    public class Person : Entity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
