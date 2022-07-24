using API_Test.Models.Base_Class;
using System.Collections;
using API_Test.Enums;
using System.ComponentModel.DataAnnotations;

namespace API_Test.Models
{
    public class Student : Entity
    {
        [Required]
        public virtual StudentYear StudentYear { get; set; }
        public virtual Person? Person { get; set; }
        public virtual GradeList? GradeList { get; set; }
    }
}