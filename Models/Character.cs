namespace alone_mysql_dc_comics.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Unknown";
        public string CodeName { get; set; } = "Unknown";
        public string Origin { get; set; } = "Unknown";
        public HeroType Type { get; set; } = HeroType.Hero;

    }
}