using AnimalShelterWebApp.Models.InputModels;
using Model.Entities;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Subscribe(SubscriberInputModel subscriberInputModel)
        {
            if (subscriberInputModel != null)
            {
                Subscriber subscriber = new Subscriber();
                subscriber.Email = subscriberInputModel.Email;
                _subscriberRepository.SaveSubscriberAsync(subscriber);
            }
            return View("Index");
        }
    }
}