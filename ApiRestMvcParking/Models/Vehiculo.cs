using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestMvcParking.Models
{
    public class Vehiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVehiculo { get; set; }

        [Required]
        public string Placa { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public int Plaza { get; set; }

        [Required]  
        public bool AplicaDescuento { get; set; }

        [Required]
        public DateTime HoraIngreso { get; set; }

        public DateTime? HoraSalida { get; set; }

    }
}
