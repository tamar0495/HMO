using Entities.DBModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IMemberService
    {
        public Task<IEnumerable<Member>> GetMembers();
        public Task<Member> GetMember(int id);
        public Task<Member> AddMember(Member member);

        public Task<IEnumerable<Member>> GetSickPeople();
        public Task<IEnumerable<Member>> GetNotVaccinated();

        public Task<Dictionary<DateTime, int>> GetSickInMonth();

    }
}
