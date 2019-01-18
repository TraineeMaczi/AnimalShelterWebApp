using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    interface IEventRepository
    {
        Task<Event> GetEventAsync(int id);
        Task<List<Event>> GetEventssAsync();
        Task<bool> SaveEventAsync(Event eventInstance);
        Task<bool> DeleteEventAsync(Event eventInstance);
    }
}
