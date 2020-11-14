using System.Threading.Tasks;
using alone_mysql_dc_comics.Dto.Team;
using alone_mysql_dc_comics.Services.TeamService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace alone_mysql_dc_comics.Controllers
{
    [Authorize(Roles = "Fan,Admin")]
    [ApiController]
    [Route("[controller]")]
    public class TeamController:ControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
            
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<IActionResult> AddNewTeam(AddTeamDto newTeam){
            return Ok(await _teamService.AddTeam(newTeam));
        }

        [HttpGet("Getall")]
        public async Task<IActionResult> GetAllTeams(){
            return Ok(await _teamService.GetAllTeams());
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamById(int id){
            return Ok(await _teamService.GetTeamById(id));
        }

        
    }
}