﻿// <auto-generated />
using System;
using ClinicaMedica.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClinicaMedica.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250130014756_Add-Entitie-Turno")]
    partial class AddEntitieTurno
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ClinicaMedica.Entities.CitasMedicas", b =>
                {
                    b.Property<int>("CitaMedicaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CitaMedicaId"), 1L, 1);

                    b.Property<float>("Descuento")
                        .HasColumnType("real");

                    b.Property<int>("MedicoId")
                        .HasColumnType("int");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.HasKey("CitaMedicaId");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("CitasMedicas");
                });

            modelBuilder.Entity("ClinicaMedica.Entities.DetalleCitas", b =>
                {
                    b.Property<int>("CitaMedicaId")
                        .HasColumnType("int");

                    b.Property<int>("ServicioId")
                        .HasColumnType("int");

                    b.HasKey("CitaMedicaId", "ServicioId");

                    b.HasIndex("ServicioId");

                    b.ToTable("DetalleCitas");
                });

            modelBuilder.Entity("ClinicaMedica.Entities.Especialidades", b =>
                {
                    b.Property<int>("EspecialidadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EspecialidadId"), 1L, 1);

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("EspecialidadId");

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("ClinicaMedica.Entities.Horarios", b =>
                {
                    b.Property<int>("HorarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HorarioId"), 1L, 1);

                    b.Property<TimeSpan>("HorarioFin")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HorarioInicio")
                        .HasColumnType("time");

                    b.HasKey("HorarioId");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("ClinicaMedica.Entities.Medicos", b =>
                {
                    b.Property<int>("MedicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicoId"), 1L, 1);

                    b.Property<int>("EspecialidadId")
                        .HasColumnType("int");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.Property<float>("Sueldo")
                        .HasColumnType("real");

                    b.HasKey("MedicoId");

                    b.HasIndex("EspecialidadId");

                    b.HasIndex("PersonaId");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("ClinicaMedica.Entities.MediosPago", b =>
                {
                    b.Property<int>("MedioPagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedioPagoId"), 1L, 1);

                    b.Property<bool>("EstaActivo")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MedioPagoId");

                    b.ToTable("MedioPagos");
                });

            modelBuilder.Entity("ClinicaMedica.Entities.Pacientes", b =>
                {
                    b.Property<int>("PacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PacienteId"), 1L, 1);

                    b.Property<bool>("ObraSocial")
                        .HasColumnType("bit");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.HasKey("PacienteId");

                    b.HasIndex("PersonaId");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("ClinicaMedica.Entities.Pagos", b =>
                {
                    b.Property<int>("PagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PagoId"), 1L, 1);

                    b.Property<int>("MedioPagoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PagoId");

                    b.HasIndex("MedioPagoId");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("ClinicaMedica.Entities.Personas", b =>
                {
                    b.Property<int>("PersonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonaId"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dni")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("PersonaId");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("ClinicaMedica.Entities.Servicios", b =>
                {
                    b.Property<int>("ServicioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServicioId"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.HasKey("ServicioId");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("ClinicaMedica.Entities.Usuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"), 1L, 1);

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ClinicaMedica.Entities.CitasMedicas", b =>
                {
                    b.HasOne("ClinicaMedica.Entities.Medicos", "Medicos")
                        .WithMany()
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ClinicaMedica.Entities.Pacientes", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Medicos");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("ClinicaMedica.Entities.DetalleCitas", b =>
                {
                    b.HasOne("ClinicaMedica.Entities.CitasMedicas", "CitaMedica")
                        .WithMany("DetalleCitas")
                        .HasForeignKey("CitaMedicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicaMedica.Entities.Servicios", "Servicio")
                        .WithMany("DetalleCitas")
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CitaMedica");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("ClinicaMedica.Entities.Medicos", b =>
                {
                    b.HasOne("ClinicaMedica.Entities.Especialidades", "Especialidades")
                        .WithMany("Medicos")
                        .HasForeignKey("EspecialidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicaMedica.Entities.Personas", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialidades");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("ClinicaMedica.Entities.Pacientes", b =>
                {
                    b.HasOne("ClinicaMedica.Entities.Personas", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("ClinicaMedica.Entities.Pagos", b =>
                {
                    b.HasOne("ClinicaMedica.Entities.MediosPago", "Pago")
                        .WithMany("Pagos")
                        .HasForeignKey("MedioPagoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pago");
                });

            modelBuilder.Entity("ClinicaMedica.Entities.CitasMedicas", b =>
                {
                    b.Navigation("DetalleCitas");
                });

            modelBuilder.Entity("ClinicaMedica.Entities.Especialidades", b =>
                {
                    b.Navigation("Medicos");
                });

            modelBuilder.Entity("ClinicaMedica.Entities.MediosPago", b =>
                {
                    b.Navigation("Pagos");
                });

            modelBuilder.Entity("ClinicaMedica.Entities.Servicios", b =>
                {
                    b.Navigation("DetalleCitas");
                });
#pragma warning restore 612, 618
        }
    }
}
