using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2Mvc.Models.ViewModels
{
    public class EmployeeDepartment
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public int? Age { get; set; }
        public string DepartmentName { get; set; }
        public string Location { get; set; }
        public int? DepartmentId { get; set; }

        public int[] LanguageIds { get; set; }
    }
}
