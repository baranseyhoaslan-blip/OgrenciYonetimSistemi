using Microsoft.EntityFrameworkCore;

namespace VizeTekrar.Models
{
    public class VeritabaniBaglantisi:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;" + "Database=VizeTekrar;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;MultipleActiveResultSets=True;Connect Timeout=120;", options => options.EnableRetryOnFailure());
            
        }
        
        public DbSet<Ogrenciler> Ogrenciler { get; set; }
        public DbSet<Bolumler> Bolumler { get; set; }
    }   

}
