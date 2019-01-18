using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface ISubscriberRepository
    {
        Task<Subscriber> GetSubscriberAsync(int id);
        Task<List<Subscriber>> GetSubscribersAsync();
        Task<bool> SaveSubscriberAsync(Subscriber subscriber);
        Task<bool> DeleteSubscriberAsync(Subscriber subscriber);
    }
}
