using CsharpAPI.Class;
using Microsoft.EntityFrameworkCore;

namespace CsharpAPI
{
    public class AppDbContext : DbContext
    {
        public DbSet<Localite> Localite { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        private static readonly object lockObject = new object();
        private static long lastTimestamp = DateTime.MinValue.Ticks;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var csvFilePath = "Csv/code-postaux-belge.csv";
            ReadCsvAndCreateLocalites(modelBuilder, csvFilePath);
        }

        public static Guid NewSequentialGuid()
        {
            lock (lockObject)
            {
                // Obtient le timestamp actuel en utilisant les ticks de DateTime en temps universel
                var timestamp = DateTime.UtcNow.Ticks;

                // Vérifie si le timestamp actuel est inférieur ou égal au dernier timestamp
                if (timestamp <= lastTimestamp)
                {
                    // S'il est inférieur ou égal, incrémente le timestamp d'une unité
                    timestamp = lastTimestamp + 1;
                }

                // Met à jour le dernier timestamp avec le nouveau timestamp généré
                lastTimestamp = timestamp;

                // Convertit le timestamp en tableau de bytes et inverse l'ordre des bytes pour être compatible avec le format GUID
                var timestampBytes = BitConverter.GetBytes(timestamp);
                Array.Reverse(timestampBytes);

                // Obtient les bytes d'un nouveau GUID généré
                var guidBytes = Guid.NewGuid().ToByteArray();

                // Copie les 6 derniers bytes du timestamp inversé dans les bytes du GUID à partir de l'index 10
                Array.Copy(timestampBytes, timestampBytes.Length - 6, guidBytes, 10, 6);

                // Crée un nouveau GUID à partir des bytes modifiés
                return new Guid(guidBytes);
            }
        }

        private void ReadCsvAndCreateLocalites(ModelBuilder modelBuilder, string csvFilePath)
        {
            var localites = new List<Localite>();

            using (var reader = new StreamReader(csvFilePath))
            {
                // Ignore the header line if it exists
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    if (values.Length >= 5)
                    {
                        int cp;
                        if (int.TryParse(values[0], out cp))
                        {
                            double longitude;
                            if (double.TryParse(values[2], out longitude))
                            {
                                double latitude;
                                if (double.TryParse(values[3], out latitude))
                                {
                                    var localite = new Localite
                                    {
                                        IdLocalite = NewSequentialGuid(),
                                        CP = cp,
                                        Ville = values[1],
                                        Longitude = longitude,
                                        Latitude = latitude,
                                    };

                                    localites.Add(localite);
                                }
                            }
                        }
                    }
                }
            }

            // Sort localites by Ville in ascending order
            localites = localites.OrderBy(l => l.Ville).ToList();

            // Add localites to modelBuilder in the sorted order
            foreach (var localite in localites)
            {
                modelBuilder.Entity<Localite>().HasData(localite);
            }
        }
    }
}

