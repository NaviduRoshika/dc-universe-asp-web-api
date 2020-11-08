using alone_mysql_dc_comics.Models;
using Microsoft.EntityFrameworkCore;

namespace alone_mysql_dc_comics.Data
{
    public class DcDbContext :DbContext  
    {
        public DcDbContext(DbContextOptions<DcDbContext> options) : base(options)
        {
            
        }

        public DbSet<Character> Characters {get; set;}
    }
}