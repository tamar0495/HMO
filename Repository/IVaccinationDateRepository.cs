using Entities.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IVaccinationDateRepository
    {
        public Task<IEnumerable<VaccinationsDate>> GetVaccinationsDates();
        public Task<IEnumerable<VaccinationsDate>> GetVaccinationDateByMemberId(int memberId);
        public Task<VaccinationsDate> AddVaccinationDate(VaccinationsDate vaccinationDate);

    }
}
