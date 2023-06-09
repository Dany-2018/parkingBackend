﻿using System.ComponentModel.DataAnnotations;

namespace ApiRestMvcParking.Models.Dto
{
    public class TotalVentasResultado
    {
        public double Automovil { get; set; }
        public double Motocicleta { get; set; }
        public double Total { get { return Automovil + Motocicleta; } }
    }

    public class VentasResultado
    {
        [Key]
        public string Tipo { get; set; } = "";
        public double TotalVehiculo { get; set; }
    }
}
