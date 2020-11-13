using alone_mysql_dc_comics.Models;

namespace alone_mysql_dc_comics.Dto.Team
{
    public class AddTeamDto
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public HeroType TeamType {get; set;}
    }
}