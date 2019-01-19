using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Repository.Concrete
{
    public class EventRepository : BaseRepository, IEventRepository
    {
    
        public async Task<Event> GetEventAsync(int id)
        {
            var _event = await context.Events.FirstOrDefaultAsync(x => x.Id == id);
            return _event;
        }

        public async Task<List<Event>> GetEventsAsync()
        {
            var events = await context.Events.ToListAsync();

            return events;
        }

        public async Task<bool> SaveEventAsync(Event eventInstance)
        {
            if (eventInstance == null)
                return false;

            try
            {
                context.Entry(eventInstance).State = eventInstance.Id == default(int) ? EntityState.Added : EntityState.Modified;
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteEventAsync(Event _event)
        {
            if (_event == null) return false;

            context.Events.Remove(_event);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public List<Event> GetEventsInfos()
        {
            var infos = context.Events.ToList();
            return infos;
        }
    }
}
