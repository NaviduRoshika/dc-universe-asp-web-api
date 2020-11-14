using System.Collections.Generic;

namespace alone_mysql_dc_comics.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }

    }
}