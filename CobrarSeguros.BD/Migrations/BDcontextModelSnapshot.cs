﻿// <auto-generated />
using System;
using CobrarSeguros.BD.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CobrarSeguros.BD.Migrations
{
    [DbContext(typeof(BDcontext))]
    partial class BDcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CobrarSeguros.BD.Data.entidades.Clientes", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("DNI")
                        .HasMaxLength(8)
                        .HasColumnType("int");

                    b.Property<string>("Domicilio")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Localidad")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("nroTelfonico")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "DNI" }, "ClienteDNI_UQ")
                        .IsUnique();

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("CobrarSeguros.BD.Data.entidades.Vehiculo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("Año")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Patente")
                        .HasMaxLength(8)
                        .HasColumnType("int");

                    b.Property<int>("Sumasegurada")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<string>("compañiaSeguro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("nroPoliza")
                        .HasMaxLength(30)
                        .HasColumnType("int");

                    b.Property<string>("periodoPoliza")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("tipoSeguro")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<int>("vigenciaPoliza")
                        .HasMaxLength(15)
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "Patente", "nroPoliza" }, "Vehiculo_UQ")
                        .IsUnique();

                    b.ToTable("Vehiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
