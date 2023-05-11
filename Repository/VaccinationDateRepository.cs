using Entities.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class VaccinationDateRepository : IVaccinationDateRepository
    {
        private readonly HmoContext _hmoContext;
        public VaccinationDateRepository(HmoContext hmoContext)
        {
            _hmoContext = hmoContext;
        }
        public async Task<IEnumerable<VaccinationsDate>> GetVaccinationDateByMemberId(int memberId)
        {
            var list = (from vaccinatoinsDate in _hmoContext.VaccinationsDates
                        where vaccinatoinsDate.MemberId == memberId
                        select vaccinatoinsDate).ToArray<VaccinationsDate>();
            return list;
        }

        public async Task<IEnumerable<VaccinationsDate>> GetVaccinationsDates()
        {
            IEnumerable<VaccinationsDate> vaccinationDates = await _hmoContext.VaccinationsDates.ToArrayAsync();
            return vaccinationDates;
        }

        public async Task<VaccinationsDate> AddVaccinationDate(VaccinationsDate vaccinationsDate)
        {
            Member member = _hmoContext.Members.FirstOrDefault(m => m.IdNumber == vaccinationsDate.MemberId.ToString());
            vaccinationsDate.MemberId = member.Id;
            await _hmoContext.VaccinationsDates.AddAsync(vaccinationsDate);
            await _hmoContext.SaveChangesAsync();
            return vaccinationsDate;
        }


    }
}
