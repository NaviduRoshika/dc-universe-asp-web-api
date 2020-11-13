using alone_mysql_dc_comics.Models;

namespace alone_mysql_dc_comics.Dto.Character
{
    public class UpdateCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "nochange";
        public string CodeName { get; set; } = "nochange";
        public string Origin { get; set; } = "nochange";
        public HeroType Type { get; set; } = 0;
    }
}