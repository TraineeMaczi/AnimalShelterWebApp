using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IItemRepository
    {
        Task<Item> GetItemAsync(int id);
        Task<List<Item>> GetItemsAsync();
        Task<bool> SaveItemAsync(Item item);
        Task<bool> DeleteItemAsync(Item item);
    }
}
