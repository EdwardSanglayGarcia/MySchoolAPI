using Microsoft.EntityFrameworkCore;
using API_Test.Models;

namespace API_Test.Data
{
    public class MySchoolDBContext : DbContext
    {
        public MySchoolDBContext(DbContextOptions<MySchoolDBContext> options) : base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        public DbSet<GradeList> GradeList { get; set; }
        public DbSet<Person> People{ get; set; }
    }
}
