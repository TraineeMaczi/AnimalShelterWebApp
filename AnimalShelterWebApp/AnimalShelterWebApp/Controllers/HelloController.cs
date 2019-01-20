using AnimalShelterWebApp.Models.InputModels;
using AnimalShelterWebApp.Models.InputModels.Hello;
using AnimalShelterWebApp.Models.OutputModels.Hello;
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
    public class HelloController : Controller
    {
        private readonly ISubscriberRepository _subscriberRepository;
        private readonly IAboutShelterInfoRepository _aboutShelterInfoRepository;
        public HelloController(ISubscriberRepository subscriberRepository,IAboutShelterInfoRepository aboutShelterInfoRepository)
        {
            _subscriberRepository = subscriberRepository;
            _aboutShelterInfoRepository = aboutShelterInfoRepository;
        }

        public ViewResult Index()
        {
            List<AboutShelterInfo> l = _aboutShelterInfoRepository.GetAboutShelterInfos();
            if (l.Count() != 1) return View();
            else
            {
                AboutShelterInfoOutputModel about = new AboutShelterInfoOutputModel();
                about.AboutShelter = l.First().Desc;
                ViewBag.Message = about.AboutShelter;
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/Hello/Subscribe")]
        public async Task<ActionResult>Subscribe(SubscriberInputModel model)
        {
            if (model != null)
            {
                var subscriber = new Subscriber();
                subscriber.Email = model.Email;
                await _subscriberRepository.SaveSubscriberAsync(subscriber);
            }
            return Redirect("/Hello");
        }

    }
}