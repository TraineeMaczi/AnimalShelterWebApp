using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalShelterWebApp.Models.InputModels.Hotel
{
    public class ResidentInputModel
    {
        public String Name { get; set; }            // imie zwierzaka
        public String From { get; set; }            // od kiedy
        public String To { get; set; }              // do kiedy
        public String Type { get; set; }            // rasa chyba
        public String OwnerEmail { get; set; }      // mail właściciela do newslettera
        public String Desc { get; set; }            // opis jakis pewnie dla diety itp
    }
}