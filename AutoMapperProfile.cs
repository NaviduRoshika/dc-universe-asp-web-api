using alone_mysql_dc_comics.Dto.Character;
using alone_mysql_dc_comics.Models;
using AutoMapper;

namespace alone_mysql_dc_comics
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
           CreateMap<Character,GetCharacterDto>();    
        }
        
    }
}