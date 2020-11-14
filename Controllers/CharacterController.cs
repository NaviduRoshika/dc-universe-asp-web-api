using System.Threading.Tasks;
using alone_mysql_dc_comics.Dto.Character;
using alone_mysql_dc_comics.Dto.User;
using alone_mysql_dc_comics.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace alone_mysql_dc_comics.Controllers
{
    [Authorize(Roles = "Fan,Admin")]
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;

        }
        
        // [AllowAnonymous]
        [HttpGet("Getall")]
        public async Task<IActionResult> GetAllCharacters(){
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacterById(int id){
            return Ok(await _characterService.GetCharacterById(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<IActionResult> AddCharacter(AddCharacterDto newCharacter){
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto toUpdate){
            return Ok(await _characterService.UpdateCharacter(toUpdate));
        }
        
         [Authorize(Roles = "Admin")]
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCharacter(DeleteCharacterDto toDelete){
            return Ok(await _characterService.DeleteCharacter(toDelete));
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost("NewPower")]
        public async Task<IActionResult> AddNewPower(AddCharacterPowerDto newPower){
            return Ok(await _characterService.AddCharacterPower(newPower));
        }

        [Authorize(Roles = "Fan")]
        [HttpPost("Rate")]
        public async Task<IActionResult> Addrating(UserRatingDto rating){
            return Ok(await _characterService.AddUserRating(rating));
        }

        
    }
} 