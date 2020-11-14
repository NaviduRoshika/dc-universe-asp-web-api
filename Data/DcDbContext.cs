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
        public DbSet<User> Users { get; set; }
        public DbSet<UserRating> UserRatings { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Character>()
                        .HasOne(t => t.Team)
                        .WithMany(c => c.Members)
                        .HasForeignKey(t => t.TeamId);
            
            
            
            modelBuilder.Entity<Role>().HasData(new Role{RoleId=1, Name="Fan"});

            modelBuilder.Entity<User>()
                        .HasOne(r => r.Role)   //reference navigation
                        .WithMany(u => u.Users) //collection navigation
                        .HasForeignKey(r => r.RoleId); //forignkey
            modelBuilder.Entity<User>().Property(u => u.RoleId).HasDefaultValue(1);
            
            modelBuilder.Entity<CharacterPower>().HasKey(cp => new {cp.CharacterId,cp.PowerId});

            modelBuilder.Entity<UserRating>().HasKey(ur => new{ur.UserId,ur.CharacterId});
        }

        
    }
}