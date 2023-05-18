﻿// <auto-generated />
using System;
using ApiRestMvcParking.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiRestMvcParking.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    partial class AplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiRestMvcParking.Models.Vehiculo", b =>
                {
                    b.Property<int>("IdVehiculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVehiculo"));

                    b.Property<bool>("AplicaDescuento")
                        .HasColumnType("bit");

                    b.Property<DateTime>("HoraIngreso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("HoraSalida")
                        .HasColumnType("datetime2");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Plaza")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdVehiculo");

                    b.ToTable("Vehiculos");

                    b.HasData(
                        new
                        {
                            IdVehiculo = 1,
                            AplicaDescuento = true,
                            HoraIngreso = new DateTime(2023, 5, 17, 8, 0, 20, 367, DateTimeKind.Local).AddTicks(4413),
                            HoraSalida = new DateTime(2023, 5, 17, 8, 0, 20, 367, DateTimeKind.Local).AddTicks(4431),
                            Placa = "HRO11E",
                            Plaza = 2,
                            Tipo = "Motocicleta"
                        },
                        new
                        {
                            IdVehiculo = 2,
                            AplicaDescuento = false,
                            HoraIngreso = new DateTime(2023, 5, 17, 8, 0, 20, 367, DateTimeKind.Local).AddTicks(4434),
                            HoraSalida = new DateTime(2023, 5, 17, 8, 0, 20, 367, DateTimeKind.Local).AddTicks(4434),
                            Placa = "FTO13R",
                            Plaza = 4,
                            Tipo = "Automovil"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
