using API_Test.Models.Base_Class;

namespace API_Test.Models
{
    public class GradeList : Entity
    {
        public string? ProfessorName { get; set; }
        public virtual ICollection<Grade>? Grades { get; set; }
    }
}
