using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace alone_mysql_dc_comics.Models
{
    public class User
    {
        public int Id{get; set;}
        public string UserName { get; set; }
        public byte[] PasswordHash{get; set;}
        public byte[] PaswordSalt { get; set; }
        public List<UserRating> UserRatings { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}