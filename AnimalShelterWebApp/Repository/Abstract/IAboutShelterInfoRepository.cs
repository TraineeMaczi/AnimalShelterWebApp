using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IAboutShelterInfoRepository
    {
        Task<AboutShelterInfo> GetAboutShelterInfoAsync(int id);
        Task<List<AboutShelterInfo>> GetAboutShelterInfosAsync();
        Task<bool> SaveAboutShelterInfoAsync(AboutShelterInfo aboutShelterInfo);
        Task<bool> DeleteAboutShelterInfoAsync(AboutShelterInfo aboutShelterInfo);
    }
}
