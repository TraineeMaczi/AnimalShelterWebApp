using AnimalShelterWebApp.Models.InputModels;
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
        public HelloController(ISubscriberRepository subscriberRepository)
        {
            _subscriberRepository = subscriberRepository;
        }

        public ActionResult Index()
        {
            return View();
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