using Entities.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IMemberRepository
    {
        public Task<Member> GetMember(int id);
        public Task<IEnumerable<Member>> GetMembers();

        public Task<Member> AddMember(Member member);
        public Task<IEnumerable<Member>> GetNotVaccinated();
        public Task<IEnumerable<Member>> GetSickPeople();
        public Task<Dictionary<DateTime, int>> GetSickInMonth();
    }
}
