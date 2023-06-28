using CsharpAPI.Class;
using Microsoft.EntityFrameworkCore;

namespace CsharpAPI
{
    public class AppDbContext : DbContext
    {
        public DbSet<Personnes> Personnes { get; set; }
        public DbSet<Localites> Localites { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var localite1Id = Guid.NewGuid();
            var localite2Id = Guid.NewGuid();
            var localite3Id = Guid.NewGuid();
            modelBuilder.Entity<Localites>().HasData(
                new Localites { IdLocalite = localite1Id, Nom = "Paris" },
                new Localites { IdLocalite = localite2Id, Nom = "Lyon" },
                new Localites { IdLocalite = localite3Id, Nom = "Marseille" }
            );

            // Exemples de personnes
            modelBuilder.Entity<Personnes>().HasData(
                new Personnes { IdPersonne = Guid.NewGuid(), Nom = "Alice", LocaliteId = localite1Id },
                new Personnes { IdPersonne = Guid.NewGuid(), Nom = "Bob", LocaliteId = localite2Id },
                new Personnes { IdPersonne = Guid.NewGuid(), Nom = "Charlie", LocaliteId = localite3Id }
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
        }
    }
}
