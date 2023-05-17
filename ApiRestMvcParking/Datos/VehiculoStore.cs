using ApiRestMvcParking.Models.Dto;

namespace ApiRestMvcParking.Datos
{
    public static class VehiculoStore
    {
        public static List<VehiculoDto> vehiculoList = new List<VehiculoDto>
        {
            
            new VehiculoDto {IdVehiculo=1, Placa="HRO11E", AplicaDescuento = true, Tipo = "Motocicleta", Plaza = 2, HoraIngreso=DateTime.Now},
            new VehiculoDto {IdVehiculo=2, Placa="FTO13R", AplicaDescuento = false, Tipo = "Automovil", Plaza = 4, HoraIngreso=DateTime.Now}
        };
     }
}
