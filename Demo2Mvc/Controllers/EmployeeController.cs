using Demo2Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo2Mvc.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            var data = new DemoModel() { Message= "Hello World from Index page DATA 1" ,EmpId=22};
            var data2 = new DemoModel() { Message= "Hello World from Index page DATA 2" ,EmpId=23};

            var bar = new List<DemoModel>();
            bar.Add(data);
            bar.Add(data2);

            ViewBag.Data = bar;

            return View("~/Views/Employee/MyIndex.cshtml");
        }
        public ActionResult Contact()
        {
            var data = new DemoModel() { Message = "Hello World from Contact page", EmpId = 22 };
            return View("~/Views/Employee/MyIndex.cshtml",data);
        }
    }
}