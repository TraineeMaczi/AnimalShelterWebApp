using AnimalShelterWebApp.Models.InputModels.Hotel;
using Model.Entities;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AnimalShelterWebApp.Controllers
{
    public class HotelController : Controller
    {
        private readonly IResidentRepository _residentRepository;

        public HotelController(IResidentRepository residentRepository)
        {
            _residentRepository = residentRepository;
        }

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

        [HttpPost]
        [AllowAnonymous]
        [Route("/Hotel/Resident")]
        public async Task<ActionResult> Resident(ResidentInputModel model)
        {
            if (model != null)
            {
                var resident = new Resident
                {
                    Name = model.Name,
                    Type = model.Type,
                    From = model.From,
                    To = model.To,
                    OwnerEmail = model.OwnerEmail,
                    Desc = model.Desc
                };
                await _residentRepository.SaveResidentAsync(resident);
            }
            return Redirect("/Hotel");
        }
    }
}