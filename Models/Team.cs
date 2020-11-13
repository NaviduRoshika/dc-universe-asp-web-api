using System.Collections.Generic;

namespace alone_mysql_dc_comics.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public HeroType TeamType {get; set;}
        public List<Character> Members { get; set; }
    }
}