using ClinicaMedica.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Xml;

namespace ClinicaMedica.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Personas> Personas { get; set; }
        public DbSet<Pacientes> Pacientes { get; set; }
        public DbSet<Especialidades> Especialidades { get; set; }
        public DbSet<Medicos> Medicos { get; set; } 
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<MediosPago> MedioPagos { get; set; }
        public DbSet<Pagos> Pagos { get; set; }
        public DbSet<CitasMedicas> CitasMedicas { get; set; }
        public DbSet<DetalleCitas> DetalleCitas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CitasMedicas>(entity =>
            {
                // Configurar la relación con Pacientes
                entity.HasOne(c => c.Paciente)
                      .WithMany()
                      .HasForeignKey(c => c.PacienteId)
                      .OnDelete(DeleteBehavior.Restrict); // Deshabilita la eliminación en cascada

                // Configurar la relación con Medicos
                entity.HasOne(c => c.Medicos)
                      .WithMany()
                      .HasForeignKey(c => c.MedicoId)
                      .OnDelete(DeleteBehavior.Restrict); // Deshabilita la eliminación en cascada
            });

            modelBuilder.Entity<DetalleCitas>()
            .HasKey(e => new { e.CitaMedicaId, e.ServicioId });

            // Relación entre DetalleCitas y CitasMedicas
            modelBuilder.Entity<DetalleCitas>()
                .HasOne(d => d.CitaMedica) // Propiedad de navegación
                .WithMany(c => c.DetalleCitas) // Relación inversa
                .HasForeignKey(d => d.CitaMedicaId) // Clave foránea
                .OnDelete(DeleteBehavior.Cascade); // Borrado en cascada

            // Relación entre DetalleCitas y Servicios
            modelBuilder.Entity<DetalleCitas>()
                .HasOne(d => d.Servicio) // Propiedad de navegación
                .WithMany(s => s.DetalleCitas) // Relación inversa
                .HasForeignKey(d => d.ServicioId) // Clave foránea
                .OnDelete(DeleteBehavior.Cascade); // Borrado en cascada

            base.OnModelCreating(modelBuilder);
        }
    }
}
