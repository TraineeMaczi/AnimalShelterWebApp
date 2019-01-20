using AnimalShelterWebApp.Models.InputModels.Event;
using Model.Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AnimalShelterWebApp.Controllers
{
    public class EventController : Controller
    {
     
        private readonly IEventRepository _eventRepository;
        
        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public ActionResult Index()
        {

            string table = "";

            List<Event> listOfEvents = _eventRepository.GetEventsInfos();

            if (listOfEvents.Count() < 1) return View();
            else
            {
                foreach (var x in listOfEvents)
                {
                    table +=
                    "<tr>" +
                        "<td>" +
                            x.Name +
                        "</td>" +
                        "<td>" +
                            x.Date +
                        "</td>" +
                        "<td>" +
                            x.Time +
                        "</td>" +
                           "<td>" +
                            x.About +
                        "</td>"+
                         "<td>" +
                            "<button type=\"submit\" class=\"btn bg-mainGreen text-center text-white m-0\" name=\"delete\" value=\"" + x.Id + "\">Delete</button>" +
                        "</td>" +
                    "</tr>";
                }
            }

            ViewData["table"] = table;

            return View();
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("/Event/AddEvent")]
        public async Task<ActionResult> AddEvent(EventInputModel model)
        {
            if (model != null)
            {
                var item = new Event();
                item.Name = model.Name;
                item.Date = model.Date;
                item.Time = model.Time;
                item.About = model.About;

                await _eventRepository.SaveEventAsync(item);
            }
            return Redirect("/Event");
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/Event/AddEvent")]
        public async Task<ActionResult> EventDelete(string delete)
        {
            var _event = await _eventRepository.GetEventAsync(Int32.Parse(delete));
            await _eventRepository.DeleteEventAsync(_event);
            return Redirect("/Event");
        }
    }
}