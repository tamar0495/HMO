using Entities.DBModels;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class VaccinationsDateService : IVaccinationsDateService
    {
        private readonly IVaccinationDateRepository _vaccinationDateRepository;
        public VaccinationsDateService(IVaccinationDateRepository vaccinationDateRepository)
        {
            _vaccinationDateRepository = vaccinationDateRepository;
        }
        public async Task<IEnumerable<VaccinationsDate>> GetVaccinationsDatesByMemberId(int memberId)
        {
            return await _vaccinationDateRepository.GetVaccinationDateByMemberId(memberId);
        }


        public async Task<IEnumerable<VaccinationsDate>> GetVaccinationsDates()
        {
            return await _vaccinationDateRepository.GetVaccinationsDates();
        }

        public async Task<VaccinationsDate> AddVaccinationDate(VaccinationsDate vaccinationsDate)
        {
            return await _vaccinationDateRepository.AddVaccinationDate(vaccinationsDate);
        }

    }
}
