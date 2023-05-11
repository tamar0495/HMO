using Entities.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Entities;
namespace Services
{
    public class MemberService:IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<Member> GetMember(int id)
        {
            return await _memberRepository.GetMember(id);
        }

        public async Task<IEnumerable<Member>> GetMembers()
        {
            return await _memberRepository.GetMembers();
        }

        public async Task<Member> AddMember(Member member)
        {
            return await _memberRepository.AddMember(member);  
        }
        public async Task<IEnumerable<Member>> GetNotVaccinated()
        {
            return await _memberRepository.GetNotVaccinated();
        }
        public async Task<IEnumerable<Member>> GetSickPeople()
        {
            return await _memberRepository.GetSickPeople();
        }

        public async Task<Dictionary<DateTime, int>> GetSickInMonth()
        {
            return await _memberRepository.GetSickInMonth();
        }


    }
}
