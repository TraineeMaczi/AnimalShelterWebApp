using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalShelterWebApp.Controllers
{
    public class HelloController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Subscribe()
        {
            //to do
            return View("Index");
        }
    }
}