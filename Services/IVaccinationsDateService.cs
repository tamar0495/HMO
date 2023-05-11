using Entities.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IVaccinationsDateService
    {
        public Task<IEnumerable<VaccinationsDate>> GetVaccinationsDates();
        public Task<IEnumerable<VaccinationsDate>> GetVaccinationsDatesByMemberId(int memberId);

        public Task<VaccinationsDate> AddVaccinationDate(VaccinationsDate vaccinationDate);
    }
}
