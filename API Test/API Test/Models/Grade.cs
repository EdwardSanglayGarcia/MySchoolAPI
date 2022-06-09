using API_Test.Models.Base_Class;

namespace API_Test.Models
{
    public class Grade : Entity
    {
        public string? Subject { get; set; }
        public double? Score { get; set; }
        public virtual int GradeListId { get; set; }
    }
}
