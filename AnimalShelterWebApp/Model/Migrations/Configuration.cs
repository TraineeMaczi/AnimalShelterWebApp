using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Migrations
{
    internal sealed class Configuration: DbMigrationsConfiguration<Model.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}


