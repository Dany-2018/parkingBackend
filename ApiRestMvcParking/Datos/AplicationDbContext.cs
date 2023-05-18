using ApiRestMvcParking.Models;
using ApiRestMvcParking.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace ApiRestMvcParking.Datos
{
    public class AplicationDbContext : DbContext
    {

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) 
        { 
        
        }
        public DbSet<Vehiculo> Vehiculos { get; set; }

        public DbSet<VentasResultado> SP_TOTAL_VENTAS { get; set; }

        public DbSet<PagarResultado> SP_VALOR_TOTAL_VEHICULO { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehiculo>().HasData(
                new Vehiculo()
                {           
                    IdVehiculo = 1,
                    Placa =  "HRO11E",
                    Tipo = "Motocicleta",
                    Plaza = 2,
                    AplicaDescuento = true,
                    HoraIngreso = DateTime.Now,
                    HoraSalida = DateTime.Now
                },
                new Vehiculo(){
                    IdVehiculo =  2,
                    Placa = "FTO13R",
                    Tipo = "Automovil",
                    Plaza = 4,
                    AplicaDescuento = false,
                    HoraIngreso = DateTime.Now,
                    HoraSalida = DateTime.Now
                }
            );
        }
    }
}
