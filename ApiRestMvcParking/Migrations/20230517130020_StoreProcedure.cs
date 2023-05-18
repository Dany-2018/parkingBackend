using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRestMvcParking.Migrations
{
    /// <inheritdoc />
    public partial class StoreProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE PROCEDURE SP_TOTAL_VENTAS
            AS
            SELECT Tipo, SUM(TotalVehiculo - (CASE WHEN AplicaDescuento = 1 THEN TotalVehiculo * 0.25 ELSE 0 END)) AS TotalVehiculo 
            FROM (
            SELECT Tipo, AplicaDescuento, DATEDIFF(HOUR, HoraIngreso, HoraSalida) * CONVERT(FLOAT, (CASE WHEN Tipo = 'Automovil' THEN 120 ELSE 62 END)) AS TotalVehiculo 
            FROM Vehiculos
            ) AS Q GROUP BY Tipo

            EXECUTE SP_TOTAL_VENTAS;
            
            ");

            migrationBuilder.Sql(@"CREATE PROCEDURE SP_VALOR_TOTAL_VEHICULO
            @idVehiculo int = NULL
            AS
            SELECT Tipo, AplicaDescuento, DATEDIFF(HOUR, HoraIngreso, HoraSalida) * CONVERT(FLOAT, (CASE WHEN Tipo = 'Automovil' THEN 120 ELSE 62 END)) AS TotalVehiculo 
            FROM Vehiculos 
            WHERE IdVehiculo = @idVehiculo ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
