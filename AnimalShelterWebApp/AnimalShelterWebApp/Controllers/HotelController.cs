using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalShelterWebApp.Controllers
{
    public class HotelController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        public String AddAnimal()
        {
            return "to do";
        }
        public String DeleteAnimal()
        {
            return "to do";
        }
        public String NotifyAnimalOwner()
        {
            //Nie za bardzo wiem jak to zaimplementować w najprostrzym przypdaku można by przy 
            //stacie app stwierdzać czy data mineła czy nie 
            return "to do";
        }
    }
}