using Demo2Mvc.Models;
using Demo2Mvc.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Demo2Mvc.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            DemoDbContext db = new DemoDbContext();

            var data = (from user in db.Employees.Include("Department").ToList()
                        select new EmployeeDepartment
                        {
                            EmployeeId = user.EmployeeId,
                            Age = user.Age,
                            EmailAddress = user.EmailAddress,
                            FullName = user.FullName,
                            DepartmentName = user.Department?.DepartmentName ?? "N/A",
                            Location = user.Department?.Location??"N/A"
                        }).ToList();


            return View("~/Views/Employee/MyIndex.cshtml", data);
        }
        public ActionResult Contact()
        {
            var data = new DemoModel() { Message = "Hello World from Contact page", EmpId = 22 };
            return View("~/Views/Employee/MyIndex.cshtml", data);
        }

        //[HttpPost]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveNewEmployee(AddEmpVM model)
        {
            return View("~/Views/Employee/AddEmpployee");
        }
    }
}