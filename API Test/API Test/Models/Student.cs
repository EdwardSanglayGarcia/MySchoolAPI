using API_Test.Models.Base_Class;
using System.Collections;
using API_Test.Enums;

namespace API_Test.Models
{
    public class Student : Entity
    {
        public virtual StudentYear StudentYear { get; set; }
        public virtual Person? Person { get; set; }
        public virtual GradeList? GradeList { get; set; }
    }
}

