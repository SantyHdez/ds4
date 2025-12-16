using System.Data.Entity;
using AdopcionMascotas.Models;

namespace AdopcionMascotas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
            // Deshabilitar el inicializador de base de datos
            Database.SetInitializer<ApplicationDbContext>(null);
        }

        // Tablas de la base de datos
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Refugio> Refugios { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Mapear las tablas con sus nombres en la BD
            modelBuilder.Entity<Usuario>().ToTable("SO_Usuarios");
            modelBuilder.Entity<Refugio>().ToTable("SO_Refugios");
            modelBuilder.Entity<Mascota>().ToTable("SO_Mascotas");
            modelBuilder.Entity<Solicitud>().ToTable("SO_Solicitudes");

            base.OnModelCreating(modelBuilder);
        }
    }
}