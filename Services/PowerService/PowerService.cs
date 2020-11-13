using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alone_mysql_dc_comics.Data;
using alone_mysql_dc_comics.Dto.Power;
using alone_mysql_dc_comics.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace alone_mysql_dc_comics.Services.PowerService
{
    public class PowerService : IPowerService
    {
        private readonly DcDbContext _context;
        private readonly IMapper _mapper;
        public PowerService(DcDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }
        public async Task<ServiceResponse<List<GetPowerDto>>> AddPower(AddPowerDto newPower)
        {
            ServiceResponse<List<GetPowerDto>> response = new ServiceResponse<List<GetPowerDto>>();
            try
            {
                Power power = _mapper.Map<Power>(newPower); 
                await _context.Powers.AddAsync(power);
                await _context.SaveChangesAsync();
                response.Data = await (_context.Powers.Include(cs => cs.CharacterPowers).ThenInclude(c => c.Character)
                                                          .Select(p => _mapper.Map<GetPowerDto>(p)))
                                                          .ToListAsync();
            }
            catch (System.Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetPowerDto>>> GetAllPowers()
        {
            ServiceResponse<List<GetPowerDto>> response = new ServiceResponse<List<GetPowerDto>>();
            try
            {
                List<GetPowerDto> powers = await (_context.Powers
                                                          .Include(cs => cs.CharacterPowers).ThenInclude(c => c.Character)
                                                          .Select(p => _mapper.Map<GetPowerDto>(p)))
                                                          .ToListAsync();
                response.Data = powers;
            }
            catch (System.Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetPowerDto>> GetPowerById(int id)
        {
            ServiceResponse<GetPowerDto> response = new ServiceResponse<GetPowerDto>();
            try
            {
                Power power = await _context.Powers
                                            .Include(cp => cp.CharacterPowers)
                                            .ThenInclude(c => c.Character)
                                            .FirstOrDefaultAsync(p => p.PowerId == id);
                if(power != null){
                    response.Data = _mapper.Map<GetPowerDto>(power);
                }
                else
                {
                    response.Success = false;
                    response.Message = "Power not found";
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}