namespace ApiRestMvcParking.Models
{
    public class Vehiculo
    {
        public int IdVehiculo { get; set; }

        public string Placa { get; set; }

        public string Tipo { get; set; }

        public int Plaza { get; set; }

        public bool AplicaDescuento { get; set; }

        public DateTime HoraIngreso { get; set; }

        public DateTime HoraSalida { get; set; }

    }
}
