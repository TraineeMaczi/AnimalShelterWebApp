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
    public class AboutShelterInfoRepository : BaseRepository, IAboutShelterInfoRepository
    {
        public async Task<bool> DeleteAboutShelterInfoAsync(AboutShelterInfo aboutShelterInfo)
        {
            if (aboutShelterInfo == null) return false;

            context.AboutShelterInfos.Remove(aboutShelterInfo);

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

        public async Task<AboutShelterInfo> GetAboutShelterInfoAsync(int id)
        {

            var info = await context.AboutShelterInfos.FirstOrDefaultAsync(x => x.Id == id);
            return info;
        }

        public List<AboutShelterInfo> GetAboutShelterInfos()
        {
            var infos = context.AboutShelterInfos.ToList();
            return infos;
        }

        public async Task<List<AboutShelterInfo>> GetAboutShelterInfosAsync()
        {
            var infos= await context.AboutShelterInfos.ToListAsync();
            return infos;
        }

        public async Task<bool> SaveAboutShelterInfoAsync(AboutShelterInfo aboutShelterInfo)
        {
            if (aboutShelterInfo == null)
                return false;

            try
            {
                context.Entry(aboutShelterInfo).State = aboutShelterInfo.Id == default(int) ? EntityState.Added : EntityState.Modified;
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
