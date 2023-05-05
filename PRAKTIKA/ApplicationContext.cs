using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PRAKTIKA
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Kliyent> Kliyent => Set<Kliyent>();
        public DbSet<Aptechnyye_punkty> Aptechnyye_punkty => Set<Aptechnyye_punkty>();
        public DbSet<Dolzhnosti> Dolzhnosti => Set<Dolzhnosti>();
        public DbSet<Sotrudniki> Sotrudniki => Set<Sotrudniki>();
        public DbSet<Gruppa_medikamentov> Gruppa_medikamentov => Set<Gruppa_medikamentov>();
        public DbSet<Medikamenty> Medikamenty => Set<Medikamenty>();
        public DbSet<Prodazha> Prodazha => Set<Prodazha>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Username=postgres;Password=123098;Database=Apteki");
        }
    }
}
