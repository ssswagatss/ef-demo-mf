using Demo2Mvc.Models;
using Demo2Mvc.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Demo2Mvc.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult All()
        {
            DemoDbContext db = new DemoDbContext();
            var employees = (from e in db.Employees.Include("Department").Include("Languages")
                                                    .Where(x=>x.Languages.Any()).ToList()
                             select new EmployeeVM
                             {
                                 EmpId = e.EmployeeId,
                                 EmployeeName = e.FullName,
                                 DeptId = e.Department?.DepartmentId,
                                 DepartmentName = e.Department?.DepartmentName,
                                 Languages = e.Languages.Select(x => x.LanguageName).ToArray()
                             });
            return View(employees);

        }

        // GET: Employee
        public ActionResult Index()
        {
            DemoDbContext db = new DemoDbContext();




            //var data = (from user in db.Employees.Include("Department").ToList()
            //            select new EmployeeDepartment
            //            {
            //                EmployeeId = user.EmployeeId,
            //                Age = user.Age,
            //                EmailAddress = user.EmailAddress,
            //                FullName = user.FullName,
            //                DepartmentName = user.Department?.DepartmentName ?? "N/A",
            //                Location = user.Department?.Location??"N/A"
            //            }).ToList();

            var departments = db.Departments.ToList();
            ViewBag.Departments = departments;
            ViewBag.Languages = db.Languages.ToList();
            return View("~/Views/Employee/MyIndex.cshtml");
        }

        public ActionResult GetEmployees()
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
                            Location = user.Department?.Location ?? "N/A"
                        }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetEmployeesById(int id)
        {
            DemoDbContext db = new DemoDbContext();
            var user = db.Employees.Include("Department").FirstOrDefault(x => x.EmployeeId == id);
            var emp = new EmployeeDepartment
            {
                EmployeeId = user.EmployeeId,
                Age = user.Age,
                EmailAddress = user.EmailAddress,
                FullName = user.FullName,
                DepartmentName = user.Department?.DepartmentName ?? "N/A",
                Location = user.Department?.Location ?? "N/A",
                DepartmentId = user.DepartmentId
            };
            return Json(emp, JsonRequestBehavior.AllowGet);
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
            DemoDbContext db = new DemoDbContext();
            var emp = new Employee()
            {
                FullName = model.EmployeeName,
                EmailAddress = model.EmailAddress,
                Age = model.Age,
                DepartmentId = model.DepartmentId
            };

            if(model.LanguageIds.Any())
            {
                var languages = db.Languages.Where(x => model.LanguageIds.Contains(x.LanguageId)).ToList();
                emp.Languages.AddRange(languages);
            }


            db.Employees.Add(emp);
            db.SaveChanges();
            return Json("Success");
        }
        [HttpPost]
        public ActionResult UpdateEmployee(int employeeId, AddEmpVM model)
        {
            DemoDbContext db = new DemoDbContext();
            var employee = db.Employees.Include("Languages").FirstOrDefault(x => x.EmployeeId == employeeId);

            employee.FullName = model.EmployeeName;
            employee.EmailAddress = model.EmailAddress;
            employee.Age = model.Age; ;
            employee.DepartmentId = model.DepartmentId;
            

            db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Json("Success");
        }
        [HttpPost]
        public ActionResult DeleteEmployee(int employeeId)
        {
            //Logic to delete employee
            DemoDbContext db = new DemoDbContext();
            var emp = db.Employees.FirstOrDefault(x => x.EmployeeId == employeeId);
            if (emp != null)
            {
                db.Employees.Remove(emp);
                db.SaveChanges();
                return Json("Successfully Deleted");
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpPost]
        public ActionResult SaveCustomEmployee(EditCustomEmployeeViewModel model)
        {
            //Save your data
            return Json(new
            {
                Id = 23,
                Name = model.Name
            });
        }
    }
}