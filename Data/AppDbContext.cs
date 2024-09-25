using Microsoft.EntityFrameworkCore;
using VidroRoto.Models;

namespace VidroRoto.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Client> Clientes { get; set; }
        public DbSet<Marco> Marcos { get; set; }
        public DbSet<Vidrio> Vidrios { get; set; }
        public DbSet<Herraje> Herrajes { get; set; }
        public DbSet<Cotizacion> Cotizaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de claves primarias
            modelBuilder.Entity<Client>().HasKey(c => c.IdCliente);
            modelBuilder.Entity<Marco>().HasKey(m => m.IdMarco);
            modelBuilder.Entity<Vidrio>().HasKey(v => v.IdVidrio);
            modelBuilder.Entity<Herraje>().HasKey(h => h.IdHerraje);
            modelBuilder.Entity<Cotizacion>().HasKey(c => c.IdCotizacion);

            // Configuración de propiedades con precisión decimal
            modelBuilder.Entity<Cotizacion>().Property(c => c.PrecioTotal).HasPrecision(18, 4);
            modelBuilder.Entity<Herraje>().Property(h => h.Precio).HasPrecision(18, 4);
            modelBuilder.Entity<Marco>().Property(m => m.Precio).HasPrecision(18, 4);
            modelBuilder.Entity<Vidrio>().Property(v => v.Grosor).HasPrecision(18, 4);

            // Configuración de relaciones
            modelBuilder.Entity<Cotizacion>()
                .HasOne(c => c.Cliente)
                .WithMany(c => c.Cotizaciones)
                .HasForeignKey(c => c.IdCliente);

            modelBuilder.Entity<Cotizacion>()
                .HasOne(c => c.Marco)
                .WithMany(m => m.Cotizaciones)
                .HasForeignKey(c => c.IdMarco);

            modelBuilder.Entity<Cotizacion>()
                .HasOne(c => c.Vidrio)
                .WithMany(v => v.Cotizaciones)
                .HasForeignKey(c => c.IdVidrio);

            modelBuilder.Entity<Cotizacion>()
                .HasOne(c => c.Herraje)
                .WithMany(h => h.Cotizaciones)
                .HasForeignKey(c => c.IdHerraje);
        }
    }
}
