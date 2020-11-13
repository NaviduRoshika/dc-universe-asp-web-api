namespace alone_mysql_dc_comics.Models
{
    public class CharacterPower
    {
        public int CharacterId { get; set; }
        public Character Character { get; set; }

        public int PowerId { get; set; }
        public Power Power { get; set; }
        public int PowerStatus { get; set; }
    }
}