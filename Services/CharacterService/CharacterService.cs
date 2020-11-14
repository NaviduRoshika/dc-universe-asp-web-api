using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using alone_mysql_dc_comics.Data;
using alone_mysql_dc_comics.Dto.Character;
using alone_mysql_dc_comics.Dto.User;
using alone_mysql_dc_comics.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace alone_mysql_dc_comics.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly DcDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CharacterService(DcDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            ServiceResponse<List<GetCharacterDto>> response = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                Character character = _mapper.Map<Character>(newCharacter);
                await _context.Characters.AddAsync(character);
                await _context.SaveChangesAsync();
                response.Data = await _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;

        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(DeleteCharacterDto toDelete)
        {
            ServiceResponse<List<GetCharacterDto>> response = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                Character character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == toDelete.Id);
                if (character != null)
                {
                    _context.Characters.Remove(character);
                    await _context.SaveChangesAsync();
                    response.Data = await (_context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            ServiceResponse<List<GetCharacterDto>> response = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                List<Character> characters = await _context.Characters.Include(cp => cp.CharacterPowers)
                                                                      .ThenInclude(p => p.Power).ToListAsync();
                response.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;

        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();

            try
            {
                Character character = await _context.Characters
                                                          .Include(cp => cp.CharacterPowers)
                                                          .ThenInclude(p => p.Power)
                                                          .FirstOrDefaultAsync(c => c.Id == id);

                if (character != null)
                {
                    response.Data = _mapper.Map<GetCharacterDto>(character);
                }
                else
                {
                    response.Success = false;
                    response.Message = "Character not found";
                }
            }
            catch (System.Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto toUpdate)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == toUpdate.Id);
                if (character != null)
                {
                    character.Name = toUpdate.Name.Equals("nochange") ? character.Name : toUpdate.Name;
                    character.CodeName = toUpdate.CodeName.Equals("nochange") ? character.CodeName : toUpdate.CodeName;
                    character.Origin = toUpdate.Origin.Equals("nochange") ? character.Origin : toUpdate.Origin;
                    character.Type = toUpdate.Type == 0 ? character.Type : toUpdate.Type;

                    _context.Characters.Update(character);
                    await _context.SaveChangesAsync();
                    response.Data = _mapper.Map<GetCharacterDto>(character);
                    response.Message = "character updated";
                }
                else
                {
                    response.Success = false;
                    response.Message = "character not found";
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> AddCharacterPower(AddCharacterPowerDto newPower)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            try
            {
                CharacterPower characterPower = _mapper.Map<CharacterPower>(newPower);
                await _context.CharacterPowers.AddAsync(characterPower);
                await _context.SaveChangesAsync();
                Character character = await _context.Characters
                                                        .Include(cp => cp.CharacterPowers)
                                                        .ThenInclude(p => p.Power)
                                                        .FirstOrDefaultAsync(c => c.Id == newPower.CharacterId);

                response.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (System.Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<int>> AddUserRating(UserRatingDto rating)
        {
           
           ServiceResponse<int> response = new ServiceResponse<int>();
           try
           {
               int userId = GetUserId();
               UserRating rating1 = new UserRating{
                   UserId = userId,
                   CharacterId = rating.CharacterId,
                   Rating = rating.Rating
               };
                bool isRated = await _context.UserRatings.AnyAsync(ur => 
                                                     ur.CharacterId == rating.CharacterId 
                                                     && ur.UserId == userId);

                System.Console.WriteLine(isRated);
                if(isRated){
                    UserRating ur = await _context.UserRatings.FirstOrDefaultAsync(ur =>
                                                      ur.CharacterId == rating.CharacterId
                                                      && ur.UserId == userId);
                    _context.UserRatings.Remove(ur);
                     await _context.SaveChangesAsync();
                    response.Message = "Rating removed";
                }else{
                    await _context.UserRatings.AddAsync(rating1);
                    await _context.SaveChangesAsync();
                    response.Message = "Rating added";
                }
                
                List<UserRating> ratings = await (_context.UserRatings.Where(ur => ur.CharacterId == rating.CharacterId)
                                                    .ToListAsync());
               response.Data = ratings.Count;
           }
           catch (System.Exception ex)
           {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}