using System.Collections.Generic;
using System.Threading.Tasks;
using alone_mysql_dc_comics.Dto.Family;
using alone_mysql_dc_comics.Dto.Team;
using alone_mysql_dc_comics.Models;

namespace alone_mysql_dc_comics.Services.TeamService
{
    public interface ITeamService
    {
         Task<ServiceResponse<List<GetTeamDto>>> GetAllTeams();
         Task<ServiceResponse<List<GetTeamDto>>> AddTeam(AddTeamDto newCharacter);
         Task<ServiceResponse<GetTeamDto>> GetTeamById(int id);


         
    }
}