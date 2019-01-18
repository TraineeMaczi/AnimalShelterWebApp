using Model.Entities;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class ItemRepository : BaseRepository, IItemRepository
    {
        public async Task<bool> DeleteItemAsync(Item item)
        {
            if (item == null) return false;

            context.Items.Remove(item);

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

        public async Task<Item> GetItemAsync(int id)
        {
            var item = await context.Items.FirstOrDefaultAsync(x => x.Id == id);
            return item;
        }

        public async Task<List<Item>> GetItemsAsync()
        {
            var items = await context.Items.ToListAsync();

            return items;
        }

        public async Task<bool> SaveItemAsync(Item item)
        {
            if (item == null)
                return false;

            try
            {
                context.Entry(item).State = item.Id == default(int) ? EntityState.Added : EntityState.Modified;
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
