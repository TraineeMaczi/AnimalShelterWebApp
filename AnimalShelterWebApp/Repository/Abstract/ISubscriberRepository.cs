using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    interface ISubscriberRepository
    {
        Task<Subscriber> GetSubscriberAsync(int id);
        Task<List<Subscriber>> GetSubscriberAsync();
        Task<bool> SaveSubscriberAsync(Item item);
        Task<bool> DeleteSubscriberAsync(Item item);
    }
}
