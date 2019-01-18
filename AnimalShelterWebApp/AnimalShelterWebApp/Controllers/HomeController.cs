using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalShelterWebApp.Controllers
{
    public class HomeController : Controller
    {
        // Pod /Home/Index i pod / po nazwie po prostu jest default jakby był DomowyController to by nie weszło 
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SetAbout()
        {
            //to do
            return RedirectPermanent("/Home/Index");
        }
        
    }
}