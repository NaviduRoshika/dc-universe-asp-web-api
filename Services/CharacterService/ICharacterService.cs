using System.Collections.Generic;
using System.Threading.Tasks;
using alone_mysql_dc_comics.Dto.Character;
using alone_mysql_dc_comics.Models;

namespace alone_mysql_dc_comics.Services
{
    public interface ICharacterService
    {
         Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
    }
}