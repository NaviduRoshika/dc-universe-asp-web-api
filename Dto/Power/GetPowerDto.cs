using System.Collections.Generic;
using alone_mysql_dc_comics.Dto.Character;

namespace alone_mysql_dc_comics.Dto.Power
{
    public class GetPowerDto
    {
        public int PowerId { get; set; }
        public string PowerName { get; set; }
        public List<GetPowerHolderDto> Characters { get; set; }
    }
}