using System.Threading.Tasks;
using alone_mysql_dc_comics.Services;
using Microsoft.AspNetCore.Mvc;

namespace alone_mysql_dc_comics.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;

        }

        [HttpGet("Getall")]
        public async Task<IActionResult> GetAllCharacters(){
            return Ok(await _characterService.GetAllCharacters());
        }
    }
}