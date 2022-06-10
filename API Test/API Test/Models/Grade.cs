using API_Test.Models.Base_Class;
using System.ComponentModel.DataAnnotations;

namespace API_Test.Models
{
    public class Grade : Entity
    {
        [Required]
        public string? Subject { get; set; }
        [Required]
        [Range(60,100, ErrorMessage = "Number can only between 60 - 100")]
        public double? Score { get; set; }
        [Required]
        [Range(1,int.MaxValue, ErrorMessage = "Parameter of type Number is needed")]
        public virtual int GradeListId { get; set; }
    }
}
