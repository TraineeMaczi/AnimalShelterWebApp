using AnimalShelterWebApp.Models.InputModels.Home;
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
    public class HomeController : Controller
    {
        // Pod /Home/Index i pod / po nazwie po prostu jest default jakby był DomowyController to by nie weszło 
        private readonly IAboutShelterInfoRepository _aboutShelterInfoRepository;
        public HomeController(IAboutShelterInfoRepository aboutShelterInfo)
        {
            _aboutShelterInfoRepository = aboutShelterInfo;
        }
        public ActionResult Index()
        {
           

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("/Home/SetAbout")]
        public async Task<ActionResult>SetAbout(AboutShelterInfoInputModel model)
        {
            if (model != null)
            {
                var about = new AboutShelterInfo();
                about.Desc = model.Desc;
                List<AboutShelterInfo> l=await _aboutShelterInfoRepository.GetAboutShelterInfosAsync();
                foreach (var x in l)
                {
                    await _aboutShelterInfoRepository.DeleteAboutShelterInfoAsync(x);
                }
                await _aboutShelterInfoRepository.SaveAboutShelterInfoAsync(about);
            }
            return Redirect("/Home");
        }
        
    }
}