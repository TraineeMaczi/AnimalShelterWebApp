using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    interface IResidentRepository
    {
        Task<Resident> GetResidentAsync(int id);
        Task<List<Resident>> GetResidentsAsync();
        Task<bool> SaveResidentAsync(Item item);
        Task<bool> DeleteResidentAsync(Item item);
    }
}
