using System;
using System.Collections.Generic;
using alone_mysql_dc_comics.Dto.Character;
using alone_mysql_dc_comics.Models;

namespace alone_mysql_dc_comics.Dto.Team
{
    public class GetTeamDto
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public HeroType TeamType {get; set;}
        public List<GetCharacterDto> Members { get; set; }

        public static implicit operator GetTeamDto(ServiceResponse<List<GetTeamDto>> v)
        {
            throw new NotImplementedException();
        }
    }
}