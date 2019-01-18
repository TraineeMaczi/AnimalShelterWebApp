using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class BaseRepository
    {
        protected Model.AppContext context;
        public BaseRepository()
        {
            context = Model.AppContext.Create();
        }
    }
}
