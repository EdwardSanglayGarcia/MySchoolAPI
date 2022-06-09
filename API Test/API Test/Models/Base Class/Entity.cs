using System.ComponentModel.DataAnnotations.Schema;

namespace API_Test.Models.Base_Class
{
    public class Entity
    {
        [Column(Order = 0)]
        public int Id { get; set; }
        [Column(Order = 1)]
        public DateTime? Created { get; set; } = DateTime.UtcNow;
        [Column(Order = 2)]
        public DateTime Updated { get; set; } = DateTime.UtcNow;
    }
}
