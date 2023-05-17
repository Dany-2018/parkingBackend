namespace ApiRestMvcParking.Models.Dto
{
    public class TotalVentasResultado
    {
        public decimal Automovil { get; set; }
        public decimal Motocicleta { get; set; }
        public decimal Total { get { return Automovil + Motocicleta; } }
    }

    public class VentasResultado
    {
        public string Tipo { get; set; } = "";
        public decimal TotalVehiculo { get; set; }
    }
}
