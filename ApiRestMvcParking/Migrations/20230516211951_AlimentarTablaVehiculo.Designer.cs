﻿// <auto-generated />
using System;
using ApiRestMvcParking.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiRestMvcParking.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20230516211951_AlimentarTablaVehiculo")]
    partial class AlimentarTablaVehiculo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("HoraSalida")
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
                            HoraIngreso = new DateTime(2023, 5, 16, 16, 19, 51, 170, DateTimeKind.Local).AddTicks(9694),
                            HoraSalida = new DateTime(2023, 5, 16, 16, 19, 51, 170, DateTimeKind.Local).AddTicks(9713),
                            Placa = "HRO11E",
                            Plaza = 2,
                            Tipo = "Motocicleta"
                        },
                        new
                        {
                            IdVehiculo = 2,
                            AplicaDescuento = false,
                            HoraIngreso = new DateTime(2023, 5, 16, 16, 19, 51, 170, DateTimeKind.Local).AddTicks(9715),
                            HoraSalida = new DateTime(2023, 5, 16, 16, 19, 51, 170, DateTimeKind.Local).AddTicks(9716),
                            Placa = "FTO13R",
                            Plaza = 4,
                            Tipo = "Automovil"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
