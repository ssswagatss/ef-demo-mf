using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2Mvc.Models
{
    public class DemoDbContext:DbContext
    {
        public DemoDbContext():base("Server=SWAGATS8;Initial Catalog=MindfireDB;Integrated Security = SSPI;")
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
