using System.Threading.Tasks;
using alone_mysql_dc_comics.Dto.Family;
using alone_mysql_dc_comics.Services.FamilyService;
using Microsoft.AspNetCore.Mvc;

namespace alone_mysql_dc_comics.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamilyController : ControllerBase
    {
        private readonly IFamilyService _familyService;
        public FamilyController(IFamilyService familyService)
        {
            _familyService = familyService;

        }

        [HttpGet("Getall")]
        public async Task<IActionResult> GetAllFamilies(){
            return Ok(await _familyService.GetAllFamilies());
        }

        [HttpPost("Create")]
        public async Task<IActionResult> AddFamily(AddFamilyDto newFamily){
            return Ok(await _familyService.AddFamily(newFamily));
        }
    }
}