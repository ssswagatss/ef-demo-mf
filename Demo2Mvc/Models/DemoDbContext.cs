using System.Data.Entity;

namespace Demo2Mvc.Models
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext() : base()
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Language> Languages { get; set; }
    }
}
