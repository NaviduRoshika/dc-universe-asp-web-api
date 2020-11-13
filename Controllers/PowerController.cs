using System.Threading.Tasks;
using alone_mysql_dc_comics.Dto.Power;
using alone_mysql_dc_comics.Services.PowerService;
using Microsoft.AspNetCore.Mvc;

namespace alone_mysql_dc_comics.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PowerController : ControllerBase
    {
        private readonly IPowerService _powerService;
        public PowerController(IPowerService powerService)
        {
            _powerService = powerService;
        }

        [Route("Create")]
        public async Task<IActionResult> AddTeam(AddPowerDto newPower){
            return Ok(await _powerService.AddPower(newPower));
        }
        
        [Route("GetAll")]
        public async Task<IActionResult> GetAll(){
            return Ok(await _powerService.GetAllPowers());
        }

        [Route("{id}")]
        public async Task<IActionResult> GetPowerById(int id){
            return Ok(await _powerService.GetPowerById(id));
        }

    }
}