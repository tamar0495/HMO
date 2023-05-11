using Entities.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class VaccinationRepository : IVaccinationRepository
    {
        private readonly HmoContext _HmoContext;
        public VaccinationRepository(HmoContext hmoContext)
        {
            _HmoContext = hmoContext;
        }
        public async Task<IEnumerable<Vaccination>> GetVaccinations()
        {
            IEnumerable<Vaccination> vaccinations = await _HmoContext.Vaccinations.ToArrayAsync();
            return vaccinations;
        }



    }
}
