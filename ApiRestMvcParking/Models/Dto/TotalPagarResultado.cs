using System.ComponentModel.DataAnnotations;

namespace ApiRestMvcParking.Models.Dto
{
    public class TotalPagarResultado
    {
        public double Automovil { get; set; }
        public double Motocicleta { get; set; }
        public double Total { get; }

    }

    public class PagarResultado
    {
        [Key]
        public double TotalVehiculo { get; set; }
    }
}
