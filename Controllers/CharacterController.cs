using System.Threading.Tasks;
using alone_mysql_dc_comics.Dto.Character;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacterById(int id){
            return Ok(await _characterService.GetCharacterById(id));
        }


        [HttpPost("Create")]
        public async Task<IActionResult> AddCharacter(AddCharacterDto newCharacter){
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto toUpdate){
            return Ok(await _characterService.UpdateCharacter(toUpdate));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCharacter(DeleteCharacterDto toDelete){
            return Ok(await _characterService.DeleteCharacter(toDelete));
        }

        [HttpPost("NewPower")]
        public async Task<IActionResult> AddNewPower(AddCharacterPowerDto newPower){
            return Ok(await _characterService.AddCharacterPower(newPower));
        }
    }
}