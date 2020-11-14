using System.ComponentModel.DataAnnotations;

namespace alone_mysql_dc_comics.Models
{
    public class UserRating
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int CharacterId { get; set; }
        public Character Character { get; set; }
        
        [Range(1, 10)]
        public int Rating { get; set; }
    }
}