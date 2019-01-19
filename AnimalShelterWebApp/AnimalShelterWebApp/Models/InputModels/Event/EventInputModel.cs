using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalShelterWebApp.Models.InputModels.Event
{
    public class EventInputModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Date { get; set; }
        public String Time { get; set; }
        public String About { get; set; }
    }
}