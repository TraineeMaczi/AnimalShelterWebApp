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
            string table = "";

            List<Resident> l = _residentRepository.GetResidentsInfos();
            if (l.Count() < 1) return View();
            else
            {
                foreach (var x in l)
                {
                    table +=
                    "<tr>" +
                        "<td>" +
                            x.Name +
                        "</td>" +
                        "<td>" +
                            x.Type +
                        "</td>" +
                        "<td>" +
                            x.From +
                        "</td>" +
                        "<td>" +
                            x.To +
                        "</td>" +
                        "<td>" +
                            x.OwnerEmail +
                        "</td>" +
                        "<td>" +
                            x.Desc +
                        "</td>" +
                        "<td>" +
                            "<button type=\"submit\" class=\"btn bg-mainGreen text-center text-white m-0\" name=\"delete\" value=\"" + x.Id + "\">Delete</button>" +
                        "</td>" +
                    "</tr>";
                }
            }
           
            ViewData["table"] = table;

            return View();
        }

        public String NotifyAnimalOwner()
        {
            //Nie za bardzo wiem jak to zaimplementować w najprostrzym przypdaku można by przy 
            //stacie app stwierdzać czy data mineła czy nie 
            return "to do";
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/Hotel/ResidentAdd")]
        public async Task<ActionResult> ResidentAdd(ResidentInputModel model)
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

        [HttpPost]
        [AllowAnonymous]
        [Route("/Hotel/ResidentAdd")]
        public async Task<ActionResult> ResidentDelete(string delete)
        {
            Resident resident = new Resident { Id = Int32.Parse(delete) };

            await _residentRepository.DeleteResidentAsync(resident);

            //await _residentRepository.DeleteResidentAsync(resident);

            return Redirect("/Hotel");
        }
    }
}