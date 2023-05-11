using Entities.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace HMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;
        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        // GET: api/<MembersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>>  Get() 
        {
            IEnumerable<Member> members = await _memberService.GetMembers();
            return members == null ? NoContent()  : Ok(members);
        }


        // GET: MembersController/Details/5
        [HttpGet("{id}")]
    
        public async Task<ActionResult<Member>> Get(int id)
        {
            Member member = await _memberService.GetMember(id);
            return member == null ? NoContent() : Ok(member);
        }

        // POST: MembersController/Create
        [HttpPost]
        public async Task<ActionResult<Member>> Post([FromBody] Member member)
        {
            Member newMember = await _memberService.AddMember(member);
            return CreatedAtAction(nameof(Get), new { Id = newMember.Id }, newMember);
        }
        [HttpGet("GetSickPeople")]
        public async Task<IEnumerable<Member>> GetSickPeople()
        {
            return await _memberService.GetSickPeople();
        }
        [HttpGet("GetNotVaccinated")]
        public async Task<IEnumerable<Member>> GetNotVaccinated()
        {
            return await _memberService.GetNotVaccinated();
        }
        [HttpGet("GetSickInMonth")]
        public async Task<Dictionary<DateTime, int>> GetSickInMonth()
        {
            return await _memberService.GetSickInMonth();
        }


    }
}
