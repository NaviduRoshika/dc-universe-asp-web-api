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
        public DbSet<Family> Families {get; set;}
        public DbSet<Team> Teams {get; set;}
        public DbSet<CharacterPower> CharacterPowers { get; set; }
        public DbSet<Power> Powers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Character>()
                        .HasOne(t => t.Team)
                        .WithMany(c => c.Members)
                        .HasForeignKey(t => t.TeamId);

            modelBuilder.Entity<CharacterPower>().HasKey(cp => new {cp.CharacterId,cp.PowerId});
        }

        
    }
}