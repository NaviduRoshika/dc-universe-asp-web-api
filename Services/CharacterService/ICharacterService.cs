using System.Collections.Generic;
using System.Threading.Tasks;
using alone_mysql_dc_comics.Dto.Character;
using alone_mysql_dc_comics.Models;

namespace alone_mysql_dc_comics.Services
{
    public interface ICharacterService
    {
         Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
         Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
         Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto toUpdate);
         Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(DeleteCharacterDto toDelete);
         Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
         Task<ServiceResponse<GetCharacterDto>> AddCharacterPower(AddCharacterPowerDto newPower);
    }
}