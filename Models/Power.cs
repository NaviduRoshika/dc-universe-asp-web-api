using System.Collections.Generic;

namespace alone_mysql_dc_comics.Models
{
    public class Power
    {
        public int PowerId { get; set; }
        public string PowerName { get; set; }
        public List<CharacterPower> CharacterPowers { get; set; }

    }
}