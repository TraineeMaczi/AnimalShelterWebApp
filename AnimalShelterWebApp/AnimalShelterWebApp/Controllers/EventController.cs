using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalShelterWebApp.Controllers
{
    public class EventController : Controller
    {
      
        public ActionResult Index()
        {
            return View();
        }
        public String AddEvent()
        {
            return "to do";
        }
        public String DeleteEvent()
        {
            return "to do";
        }
        public String NotifySubscribers()
        {
            return "to do";
        }
    }
}