using AnimalShelterWebApp.Models.InputModels.Event;
using Model.Entities;
using Repository;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AnimalShelterWebApp.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly ISubscriberRepository _subcriberRepository;

        public EventController(IEventRepository eventRepository, ISubscriberRepository subscriberRepository)
        {
            _eventRepository = eventRepository;
            _subcriberRepository = subscriberRepository;
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
                var item = new Event
                {
                    Name = model.Name,
                    Date = model.Date,
                    Time = model.Time,
                    About = model.About
                };

                await _eventRepository.SaveEventAsync(item);
            }
            return Redirect("/Event");
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/Event/EventDelete")]
        public async Task<ActionResult> EventDelete(string delete)
        {
            var _event = await _eventRepository.GetEventAsync(Int32.Parse(delete));
            await _eventRepository.DeleteEventAsync(_event);
            return Redirect("/Event");
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/Event/EventSend")]
        public async Task<ActionResult> EventSend()
        {
            List<Subscriber> subscribers = await _subcriberRepository.GetSubscribersAsync();
            List<Event> events = await _eventRepository.GetEventsAsync();

            string password = "Tutej dej hasło!";

            SmtpClient smtpClient = new SmtpClient()
            {
                Credentials = new System.Net.NetworkCredential("animalshelterwebapp@gmail.com", password),
                EnableSsl = true,
                Port = 587,
                Host = "smtp.gmail.com"
            };

            MailMessage mail = new MailMessage
            {
                From = new MailAddress("animalshelterwebapp@gmail.com", "Animal Shelter", System.Text.Encoding.UTF8),
                Subject = "Animal Shelter Events Buletin",
                BodyEncoding = System.Text.Encoding.UTF8
            };

            // dodajemy odbiorców z bazy
            foreach (var x in subscribers)
            {
                mail.Bcc.Add(x.Email);
            }

            StringBuilder body = new StringBuilder();

            body.AppendLine("<html>");
            body.AppendLine("<head>");
            body.AppendLine("<style>");
            body.AppendLine("th, td { padding: 10px; }");
            body.AppendLine("</style>");
            body.AppendLine("</head>");
            body.AppendLine("<body>");
            body.AppendLine("<h1>Upcoming events:</h1>");
            body.AppendLine("<table border=\"0\" style=\"border: none;\">");
            body.AppendLine("<tr><th> Name </th><th> Date </th><th> Time </th><th> About </th></tr>");

            foreach (var y in events)
            {
                body.Append("<tr><td>");
                body.Append(y.Name);
                body.Append("</td><td>");
                body.Append(y.Date);
                body.Append("</td><td>");
                body.Append(y.Time);
                body.Append("</td><td>");
                body.Append(y.About);
                body.Append("</td></tr>");
                body.AppendLine();
            }
            body.AppendLine("</table>");
            body.AppendLine("</body>");
            body.AppendLine("</html>");

            mail.Body = body.ToString();
            mail.IsBodyHtml = true;

            try
            {
                await smtpClient.SendMailAsync(mail);
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.ToString();
            }
            
            return Redirect("/Event");
        }
    }
}