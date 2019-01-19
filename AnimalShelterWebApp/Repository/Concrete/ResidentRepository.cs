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
    public class ResidentRepository : BaseRepository, IResidentRepository
    {
        public async Task<bool> DeleteResidentAsync(Resident resident)
        {
            if (resident == null)
                return false;

            //context.Residents.Remove(resident);

            try
            {
                context.Residents.Attach(resident);
                context.Entry(resident).State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<Resident> GetResidentAsync(int id)
        {
            var resident = await context.Residents.FirstOrDefaultAsync(x => x.Id == id);
            return resident;
        }

        public List<Resident> GetResidentsInfos()
        {
            var infos = context.Residents.ToList();
            return infos;
        }

        public async Task<List<Resident>> GetResidentsAsync()
        {
            var residents = await context.Residents.ToListAsync();
            return residents;
        }

        public async Task<bool> SaveResidentAsync(Resident resident)
        {
            if (resident == null)
                return false;

            try
            {
                context.Entry(resident).State = resident.Id == default(int) ? EntityState.Added : EntityState.Modified;
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
