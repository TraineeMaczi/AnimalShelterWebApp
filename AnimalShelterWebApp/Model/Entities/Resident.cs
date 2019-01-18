using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Resident
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
        public String From { get; set; }
        public String To { get; set; }
        public String OwnerEmail { get; set; }
        public String Desc { get; set; }
    }
}
