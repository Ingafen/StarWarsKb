using Microsoft.EntityFrameworkCore;
using StarWarsKb.Infrastructure.Model;
using StarWarsKb.Infrastructure.Services;

namespace StarWarsKb.Back.Model
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IParamService _paramService;
        public DbSet<Character> Characters { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Planet> Planets { get; set; }        
        public DbSet<Starship> Starships { get; set; }
        public DbSet<StarshipsCharacters> StarshipsCharacters { get; set; }

        public ApplicationDbContext(IParamService paramService)
        {
            _paramService = paramService;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(_paramService.GetParam("SWKB-back-cs"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Character>().HasKey(x => x.StarWarId);
                
            modelBuilder.Entity<StarshipsCharacters>().HasKey(sc => new {sc.CharacterId, sc.StarshipId});
            modelBuilder.Entity<StarshipsCharacters>()
                .HasOne<Starship>(sc1 => sc1.Starship)
                .WithMany(s => s.StarshipsCharacters)
                .HasForeignKey(sc => sc.StarshipId);
            modelBuilder.Entity<StarshipsCharacters>()
                .HasOne<Character>(sc1 => sc1.Character)
                .WithMany(s => s.StarshipCharacters)
                .HasForeignKey(c => c.CharacterId);

            modelBuilder.Entity<Character>()
                .HasOne<Planet>(ch => ch.HomeWorld)
                .WithMany(p => p.Residents)
                .HasForeignKey(ch1 => ch1.HomeWorldId);
            
            modelBuilder.Entity<Film>().HasKey(x => x.StarWarId);
            
            modelBuilder.Entity<Planet>().HasKey(x => x.StarWarId);
            modelBuilder.Entity<Planet>()
                .HasMany<Character>(pl => pl.Residents)
                .WithOne(ch => ch.HomeWorld)
                .HasForeignKey(ch1 => ch1.HomeWorldId);
            
            modelBuilder.Entity<Starship>().HasKey(x => x.StarWarId);
        }
    }
}