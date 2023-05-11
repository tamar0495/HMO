using Microsoft.AspNetCore.Mvc;
using Entities;
using Services;
using Entities.DBModels;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinationController : ControllerBase
    { 
                
        private readonly IVaccinationService _vaccinationService;
        public VaccinationController(IVaccinationService vaccinationService)
        {
            _vaccinationService = vaccinationService;
        }


        // GET: api/<Vaccination>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vaccination>>> Get()
        {
            IEnumerable<Vaccination> vaccinations = await _vaccinationService.GetVaccinations();
            return vaccinations == null ? NoContent() : Ok(vaccinations);
        }

    }
}
