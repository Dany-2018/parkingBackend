using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiRestMvcParking.Migrations
{
    /// <inheritdoc />
    public partial class AlimentarTablaVehiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vehiculos",
                columns: new[] { "IdVehiculo", "AplicaDescuento", "HoraIngreso", "HoraSalida", "Placa", "Plaza", "Tipo" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 5, 16, 16, 19, 51, 170, DateTimeKind.Local).AddTicks(9694), new DateTime(2023, 5, 16, 16, 19, 51, 170, DateTimeKind.Local).AddTicks(9713), "HRO11E", 2, "Motocicleta" },
                    { 2, false, new DateTime(2023, 5, 16, 16, 19, 51, 170, DateTimeKind.Local).AddTicks(9715), new DateTime(2023, 5, 16, 16, 19, 51, 170, DateTimeKind.Local).AddTicks(9716), "FTO13R", 4, "Automovil" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "IdVehiculo",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "IdVehiculo",
                keyValue: 2);
        }
    }
}
