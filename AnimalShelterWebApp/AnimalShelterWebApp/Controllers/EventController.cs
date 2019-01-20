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

            string password = "Tutej wklej prawdziwe hasło";

            SmtpClient smtpClient = new SmtpClient()
            {
                Credentials = new System.Net.NetworkCredential("animalshelterwebapp@gmail.com", password),
                //UseDefaultCredentials = true,
                //DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true,
                Port = 587,
                Host = "smtp.gmail.com"
            };

            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
                        System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                        System.Security.Cryptography.X509Certificates.X509Chain chain,
                        System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };

            MailMessage mail = new MailMessage
            {
                From = new MailAddress("animalshelterwebapp@gmail.com", "Animal Shelter", System.Text.Encoding.UTF8),
                Subject = "Test Events Mail",
                BodyEncoding = System.Text.Encoding.UTF8
            };

            // dodajemy odbiorców z bazy
            foreach (var x in subscribers)
            {
                mail.To.Add(x.Email);
            }

            StringBuilder body = new StringBuilder();

            body.Append("Upcoming events: ");
            body.AppendLine();
            foreach (var y in events)
            {
                body.Append(y.Name);
                body.Append("\t");
                body.Append(y.Date);
                body.Append("\t");
                body.Append(y.Time);
                body.Append("\t");
                body.Append(y.About);
                body.AppendLine();
            }

            mail.Body = body.ToString();
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