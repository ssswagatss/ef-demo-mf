using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo2Mvc.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Location { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}
