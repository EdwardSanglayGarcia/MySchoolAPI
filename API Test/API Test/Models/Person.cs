using API_Test.Models.Base_Class;
using System.ComponentModel.DataAnnotations;
namespace API_Test.Models
{
    public class Person : Entity
    {
        [Required(AllowEmptyStrings = true)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [Phone(ErrorMessage = "")]
        public string PhoneNumber { get; set; }
    }
}
