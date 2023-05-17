using System.ComponentModel.DataAnnotations;

namespace ApiRestMvcParking.Models.Dto
{
    public class VehiculoDto
    {
        public int IdVehiculo { get; set; }

        [Required]
        [MaxLength(10)]
        public string Placa { get; set; }

        public string Tipo { get; set; }

        public int Plaza { get; set; }

        public bool AplicaDescuento { get; set; }

        public DateTime HoraIngreso { get; set; }

        public DateTime HoraSalida { get; set; }
    }
}
