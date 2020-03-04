using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2Mvc.Models.ViewModels
{
    public class AddEmpVM
    {
        public string EmployeeName { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
    }
}
