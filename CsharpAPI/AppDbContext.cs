using CsharpAPI.Class;
using Microsoft.EntityFrameworkCore;

namespace CsharpAPI
{
    public class AppDbContext : DbContext
    {
        public DbSet<Personnes> Personnes { get; set; }
        public DbSet<Localites> Localites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                //.UseLazyLoadingProxies()
                .UseSqlServer("Server=PC-AXEL;Database=DB_TECHNOFUTUR;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=true;");
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            // Exemples de localités
            modelBuilder.Entity<Localites>().HasData(
                new Localites { IdLocalite = 1, Nom = "Paris" },
                new Localites { IdLocalite = 2, Nom = "Lyon" },
                new Localites { IdLocalite = 3, Nom = "Marseille" }
            );

            // Exemples de personnes
            modelBuilder.Entity<Personnes>().HasData(
                new Personnes { IdPersonne = 1, Nom = "Alice", LocaliteId = 1 },
                new Personnes { IdPersonne = 2, Nom = "Bob", LocaliteId = 2 },
                new Personnes { IdPersonne = 3, Nom = "Charlie", LocaliteId = 3 }
            );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            SeedData(modelBuilder);
        }

    }
}
