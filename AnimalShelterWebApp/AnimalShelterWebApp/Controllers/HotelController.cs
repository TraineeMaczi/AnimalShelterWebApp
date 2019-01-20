using AnimalShelterWebApp.Models.InputModels.Hotel;
using Model.Entities;
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
                            "<button type=\"submit\" class=\"btn bg-mainGreen text-center text-white m-0\" name=\"animal\" value=\"send" + x.Id + "\">Send</button>" +
                        "</td>" +
                        "<td>" +
                            "<button type=\"submit\" class=\"btn bg-mainGreen text-center text-white m-0\" name=\"animal\" value=\"" + x.Id + "\">Delete</button>" +
                        "</td>" +
                    "</tr>";
                }
            }
           
            ViewData["table"] = table;

            return View();
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
        [Route("/Hotel/ResidentAnimal")]
        public async Task<ActionResult> ResidentAnimal(string animal)
        {
            if (animal.Substring(0, 4) == "send")
            {
                // tutaj cała hochsztaplerka żeby wydobyć z bazy odpowiednie zwirze po ID
                int id = Int32.Parse(animal.Substring(4, animal.Length - 4));
                List<Resident> l = _residentRepository.GetResidentsInfos();
                Resident res = l.Where<Resident>( x => x.Id == id).Single<Resident>();

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
                    Subject = "Animal Shelter: Your " + res.Type.ToString() + " is ready to come back home",
                    BodyEncoding = System.Text.Encoding.UTF8                    
                };

                mail.Bcc.Add(res.OwnerEmail.ToString());

                StringBuilder body = new StringBuilder();

                body.AppendLine("<html>");
                body.AppendLine("<head>");
                body.AppendLine("</head>");
                body.AppendLine("<body>");
                body.AppendLine("<h1>Your " + res.Type.ToString() + ", " + res.Name.ToString() + " is ready to come back home</h1>");
                body.AppendLine("<h3>" + res.Name.ToString() + " was staying here from: " + res.From.ToString() + " to: " + res.To.ToString() + "</h3>");
                body.AppendLine("</body>");
                body.AppendLine("</html>");

                mail.Body = body.ToString();
                mail.IsBodyHtml = true;

                try
                {
                    await smtpClient.SendMailAsync(mail);
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.ToString();
                }
            }
            else
            {
                Resident resident = new Resident { Id = Int32.Parse(animal) };
                await _residentRepository.DeleteResidentAsync(resident);
            }
            
            return Redirect("/Hotel");
        }
    }
}