﻿using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IResidentRepository
    {
        Task<Resident> GetResidentAsync(int id);
        Task<List<Resident>> GetResidentsAsync();
        List<Resident> GetResidentsInfos();
        Task<bool> SaveResidentAsync(Resident resident);
        Task<bool> DeleteResidentAsync(Resident resident);
    }
}
