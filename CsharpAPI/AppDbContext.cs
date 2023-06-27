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
            optionsBuilder.UseSqlServer("Server=PC-AXEL;Database=DB_TECHNOFUTUR;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=true;");
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
                new Personnes { IdPersonnes = 1, Nom = "Alice", IdLocalite = 1 },
                new Personnes { IdPersonnes = 2, Nom = "Bob", IdLocalite = 2 },
                new Personnes { IdPersonnes = 3, Nom = "Charlie", IdLocalite = 3 }
            );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ...

            SeedData(modelBuilder);
        }

    }
}
