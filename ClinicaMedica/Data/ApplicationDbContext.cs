using ClinicaMedica.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Xml;

namespace ClinicaMedica.Data
{
    public class ApplicationDbContext : DbContext
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
        public DbSet<Horarios> Horarios { get; set; }
        public DbSet<Turnos> Turnos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Turnos>(entity =>
            {
                entity.HasKey(t => t.TurnoId);

                entity.Property(t => t.Fecha)
                    .HasColumnType("date")
                    .IsRequired();

                entity.Property(t => t.Asistencia)
                    .IsRequired();

                // Relación con Horarios (corrigiendo WithMany)
                entity.HasOne(t => t.Horario)
                    .WithMany(h => h.Turnos) // Ahora usando la colección de Turnos en Horarios
                    .HasForeignKey(t => t.HorarioId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Relación con Médicos (corrigiendo WithMany)
                entity.HasOne(t => t.Medico)
                    .WithMany(m => m.Turnos) // Ahora usando la colección de Turnos en Médicos
                    .HasForeignKey(t => t.MedicoId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Relación con Pacientes (corrigiendo WithMany)
                entity.HasOne(t => t.Paciente)
                    .WithMany(p => p.Turnos) // Ahora usando la colección de Turnos en Pacientes
                    .HasForeignKey(t => t.PacienteId)
                    .OnDelete(DeleteBehavior.Restrict);

                //DetalleCitas

                modelBuilder.Entity<DetalleCitas>()
                .HasKey(e => new { e.CitaMedicaId, e.ServicioId });

                // Relación entre DetalleCitas y CitasMedicas
                modelBuilder.Entity<DetalleCitas>()
                    .HasOne(d => d.CitaMedica) // Propiedad de navegación
                    .WithMany(c => c.DetalleCitas) // Relación inversa
                    .HasForeignKey(d => d.CitaMedicaId) // Clave foránea
                    .OnDelete(DeleteBehavior.Restrict); // Borrado en cascada

                // Relación entre DetalleCitas y Servicios
                modelBuilder.Entity<DetalleCitas>()
                    .HasOne(d => d.Servicio) // Propiedad de navegación
                    .WithMany(s => s.DetalleCitas) // Relación inversa
                    .HasForeignKey(d => d.ServicioId) // Clave foránea
                    .OnDelete(DeleteBehavior.Restrict); // Borrado en cascada
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
