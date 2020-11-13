using System.Linq;
using alone_mysql_dc_comics.Dto.Character;
using alone_mysql_dc_comics.Dto.Family;
using alone_mysql_dc_comics.Dto.Power;
using alone_mysql_dc_comics.Dto.Team;
using alone_mysql_dc_comics.Models;
using AutoMapper;

namespace alone_mysql_dc_comics
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
           CreateMap<Character,GetCharacterDto>()
                    .ForMember(des => des.CharacterPowers,src => src.MapFrom(src => src.CharacterPowers.Select(cp => cp.Power)));
           CreateMap<AddCharacterDto,Character>();  
           CreateMap<Power,CharacterPowersDto>();
        //    .ForMember(des => des.PowerStatus,src  => src.MapFrom(src => src.CharacterPowers.Select(src => src.PowerStatus)));
           
           CreateMap<AddCharacterPowerDto,CharacterPower>();
        
           
           CreateMap<Family,GetFamilyDto>();  
           CreateMap<AddFamilyDto,Family>();  

           CreateMap<Team,GetTeamDto>();
           CreateMap<AddTeamDto,Team>();

           CreateMap<Power,GetPowerDto>()
                    .ForMember(des => des.Characters,src => src.MapFrom(src => src.CharacterPowers.Select(src => src.Character)));
                    // .ForMember(des => des.Characters.Select(d => d.PowerStatus),src => src.MapFrom(src => src.CharacterPowers.Select(s => s.PowerStatus)));
           CreateMap<AddPowerDto,Power>();
           CreateMap<Character,GetPowerHolderDto>();
        //    CreateMap<CharacterPower,GetPowerHolderDto>()
        //             .ForMember(des => des.PowerStatus,src => src.MapFrom(src => src.PowerStatus));  
      
           

        }
        
    }
}