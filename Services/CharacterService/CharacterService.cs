using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alone_mysql_dc_comics.Data;
using alone_mysql_dc_comics.Dto.Character;
using alone_mysql_dc_comics.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace alone_mysql_dc_comics.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly DcDbContext _context;
        private readonly IMapper _mapper;
        public CharacterService(DcDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            ServiceResponse<List<GetCharacterDto>> response = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                 List<Character> characters = await _context.Characters.ToListAsync();
                 response.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            }
            catch (Exception ex)
            {
               response.Success = false;
               response.Message = ex.Message;
            }
            return response;
            
        }
    }
}