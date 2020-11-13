using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alone_mysql_dc_comics.Data;
using alone_mysql_dc_comics.Dto.Team;
using alone_mysql_dc_comics.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace alone_mysql_dc_comics.Services.TeamService
{
    public class TeamService : ITeamService
    {
        private readonly DcDbContext _context;
        private readonly IMapper _mapper;
        public TeamService(DcDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }
        public async Task<ServiceResponse<List<GetTeamDto>>> AddTeam(AddTeamDto newCharacter)
        {
           ServiceResponse<List<GetTeamDto>> response = new ServiceResponse<List<GetTeamDto>>();
           try
           {
               Team newTeam = _mapper.Map<Team>(newCharacter);
               await _context.Teams.AddAsync(newTeam);
               await _context.SaveChangesAsync();
               response.Data = (_context.Teams.Select(t => _mapper.Map<GetTeamDto>(t))).ToList();
           }
           catch (Exception ex)
           {
                response.Success = false;
                response.Message = ex.Message;
           }
           return response;
        }

        public async Task<ServiceResponse<List<GetTeamDto>>> GetAllTeams()
        {
            ServiceResponse<List<GetTeamDto>> response = new ServiceResponse<List<GetTeamDto>>();
            try
            {
                List<Team> teams = await _context.Teams.ToListAsync();
                foreach (var team in teams)
                {
                    team.Members = _context.Characters.Where(c => c.TeamId == team.TeamId).ToList();
                }
                response.Data = (teams.Select(t => _mapper.Map<GetTeamDto>(t))).ToList();
            }
            catch (System.Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetTeamDto>> GetTeamById(int teamId)
        {
            ServiceResponse<GetTeamDto> response = new ServiceResponse<GetTeamDto>();
            try
            {
                Team team = await _context.Teams.FirstOrDefaultAsync(t => t.TeamId == teamId);
                team.Members = await _context.Characters.Where(c => c.TeamId == team.TeamId).ToListAsync();
                response.Data = _mapper.Map<GetTeamDto>(team);
            }
            catch (System.Exception ex)
            {
                response.Message = ex.Message;;
                response.Success = false;
            }
            return response;
        }
    }
}