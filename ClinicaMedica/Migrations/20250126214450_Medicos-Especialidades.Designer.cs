﻿// <auto-generated />
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
    [Migration("20250126214450_Medicos-Especialidades")]
    partial class MedicosEspecialidades
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

            modelBuilder.Entity("ClinicaMedica.Entities.Pacientes", b =>
                {
                    b.HasOne("ClinicaMedica.Entities.Personas", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });
#pragma warning restore 612, 618
        }
    }
}
