using Entities.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly HmoContext _HMOContext;
        public MemberRepository(HmoContext hmoContext)
        {
            _HMOContext = hmoContext;
        }
        public async Task<Member> AddMember(Member member)
        {
            await _HMOContext.Members.AddAsync(member);
            await _HMOContext.SaveChangesAsync();
            return member;
        }

        public async Task<Member> GetMember(int id)
        {
            var list = (from member in _HMOContext.Members
                        where member.Id == id 
                        select member).ToArray<Member>();
            return list.FirstOrDefault();
        }

        public async Task<IEnumerable<Member>> GetMembers()
        {
            IEnumerable<Member> members = await _HMOContext.Members.ToArrayAsync();
            return members;
            
        }
         public async Task<IEnumerable<Member>> GetNotVaccinated()
        {

        var membersWithoutVaccinations = _HMOContext.Members
        .Where(m => !_HMOContext.VaccinationsDates.Select(v => v.MemberId).Distinct().Contains(m.Id))
        .ToList();
            return membersWithoutVaccinations;

        }
        public async Task<IEnumerable<Member>> GetSickPeople()
        {
            IEnumerable<Member> membersWithRecentPositiveTests = _HMOContext.Members
            .Where(m => m.PositiveResultDate >= DateTime.Today.AddDays(-14))
            .ToList();
            return membersWithRecentPositiveTests;

        }
        public Task<Dictionary<DateTime,int>> GetSickInMonth()
        {
            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime endDate = startDate.AddMonths(1);
            var dates = Enumerable.Range(0, 1 + endDate.Subtract(startDate).Days)
                                  .Select(offset => startDate.AddDays(offset))
                                  .ToList();

            var result = from d in dates
                         join v in _HMOContext.VaccinationsDates
                            on new
                            {
                                Date = d,
                                MemberIds = _HMOContext.Members
                                                              .Where(m => m.PositiveResultDate >= d.AddDays(-14) && m.PositiveResultDate <= d)
                                                              .Select(m => m.Id)
                                                              .ToList()
                            }
                            equals new { Date = v.Date, MemberIds = new List<int> { v.MemberId } } into gj
                         from v in gj.DefaultIfEmpty()
                         group v by d into g
                         select new { Date = g.Key, Sum = g.Count(x => x != null) };
            Dictionary<DateTime, int> dict = result.ToDictionary(x => x.Date, x => x.Sum);
            return Task.FromResult(dict);


        }

    }
}
