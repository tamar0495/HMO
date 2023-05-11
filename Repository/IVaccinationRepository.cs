﻿using Entities.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IVaccinationRepository
    {
        public Task<IEnumerable<Vaccination>> GetVaccinations();

    }
}
