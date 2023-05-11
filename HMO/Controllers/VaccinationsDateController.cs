using Entities.DBModels;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinationsDateController : ControllerBase
    {
        private readonly IVaccinationsDateService _vaccinationsDateService;
        public VaccinationsDateController(IVaccinationsDateService vaccinationsDateService)
        {
            _vaccinationsDateService = vaccinationsDateService;
        }
        // GET: api/<VaccinationsDateController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VaccinationsDate>>> Get()
        {
            IEnumerable<VaccinationsDate> vaccinationsDate = await _vaccinationsDateService.GetVaccinationsDates();
            return vaccinationsDate == null ? NoContent() : Ok(vaccinationsDate);
        }

        // GET api/<VaccinationsDateController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<VaccinationsDate>>> Get(int id)
        {
            IEnumerable<VaccinationsDate> vaccinationsDates = await _vaccinationsDateService.GetVaccinationsDatesByMemberId(id);
            return vaccinationsDates == null ? NoContent() : Ok(vaccinationsDates);

        }
        [HttpPost]

        public async Task<VaccinationsDate> Post([FromBody ] VaccinationsDate vaccinationsDate)
        {
            return await _vaccinationsDateService.AddVaccinationDate(vaccinationsDate);
        }

    }
}
