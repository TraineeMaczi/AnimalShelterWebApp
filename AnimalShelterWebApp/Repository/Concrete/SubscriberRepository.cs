using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;
using Repository.Abstract;

namespace Repository.Concrete
{
    public class SubscriberRepository : BaseRepository, ISubscriberRepository
    {
        public async Task<bool> DeleteSubscriberAsync(Subscriber subscriber)
        {
            if (subscriber == null)
                return false;

            context.Subscribers.Remove(subscriber);

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

        public async Task<Subscriber> GetSubscriberAsync(int id)
        {
            var subscriber = await context.Subscribers.FirstOrDefaultAsync(x => x.Id == id);
            return subscriber;
        }

        public async Task<List<Subscriber>> GetSubscribersAsync()
        {
            var subscribers = await context.Subscribers.ToListAsync();
            return subscribers;
        }

        public async Task<bool> SaveSubscriberAsync(Subscriber subscriber)
        {
            if (subscriber == null)
                return false;

            try
            {
                context.Entry(subscriber).State = subscriber.Id == default(int) ? EntityState.Added : EntityState.Modified;
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

       
    }
}
