using alone_mysql_dc_comics.Models;

namespace alone_mysql_dc_comics.Dto.Character
{
    public class AddCharacterDto
    {
        public string Name { get; set; } = "unknown";
        public string CodeName { get; set; } = "unknown";
        public string Origin { get; set; } = "unknown";
        public HeroType Type { get; set; } = HeroType.Hero;
    }
}