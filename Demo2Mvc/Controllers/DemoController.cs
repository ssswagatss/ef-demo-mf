using Demo2Mvc.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo2Mvc.Controllers
{
    public class DemoController : Controller
    {
        public ActionResult Abc()
        {
            return View();
        }
        public ActionResult Xyz(DemoVm model)
        {
           
            return View(model);
        }
    }
}