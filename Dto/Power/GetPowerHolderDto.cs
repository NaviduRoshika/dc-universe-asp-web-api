using alone_mysql_dc_comics.Models;

namespace alone_mysql_dc_comics.Dto.Power
{
    public class GetPowerHolderDto
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string CodeName { get; set; }
        // public string Origin { get; set; }
        public HeroType Type { get; set; }
        public int PowerStatus { get; set; }
    }
}