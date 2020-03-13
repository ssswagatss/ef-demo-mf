using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2Mvc.Models
{
    public class Employee
    {
        //[Key]
        public int EmployeeId { get; set; }

        [MaxLength(50)]
        [Required]
        public string FullName { get; set; }

        [MaxLength(50)]
        [Required]
        public string EmailAddress { get; set; }
        public int? Age { get; set; }

        public int? DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }


        public virtual List<Language> Languages { get; set; }
    }
}
