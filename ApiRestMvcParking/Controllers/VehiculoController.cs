using ApiRestMvcParking.Datos;
using ApiRestMvcParking.Models;
using ApiRestMvcParking.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRestMvcParking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly AplicationDbContext _db;

        public VehiculoController(AplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VehiculoDto>> GetVehiculo()
        {
            return Ok(_db.Vehiculos.Where(w => w.HoraSalida == null).ToList());
        }

        [HttpGet("id:int", Name = "GetVehiculo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VehiculoDto> GetVehiculo(int id)
        {
            if (id == 0)
            {
                return BadRequest();

            }
            // var vehiculo = VehiculoStore.vehiculoList.FirstOrDefault(v => v.IdVehiculo == id);

            var vehiculo = _db.Vehiculos.FirstOrDefault(v => v.IdVehiculo == id);

            if (vehiculo == null)
            {
                return NotFound();
            }

            return Ok(_db.Vehiculos.ToList());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VehiculoDto> CreateVehiculo([FromBody] VehiculoDto vehiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_db.Vehiculos.FirstOrDefault(v => v.Placa.ToLower() == vehiculo.Placa.ToLower()) != null)
            {
                ModelState.AddModelError("PlacaExiste", "La placa ya existe! ");

                return BadRequest(ModelState);
            }

            if (vehiculo == null)
            {
                return BadRequest();
            }

            if (vehiculo.IdVehiculo > 0)
            {
                Vehiculo vehiculoModel = _db.Vehiculos.Find(vehiculo.IdVehiculo)!;
                vehiculoModel.Placa = vehiculo.Placa;
                vehiculoModel.Tipo = vehiculo.Tipo;
                vehiculoModel.AplicaDescuento = vehiculo.AplicaDescuento;
                vehiculoModel.Plaza = vehiculo.Plaza;
                _db.Vehiculos.Update(vehiculoModel);
            }
            else
            {
                Vehiculo model = new()
                {
                    Placa = vehiculo.Placa,
                    Tipo = vehiculo.Tipo,
                    AplicaDescuento = vehiculo.AplicaDescuento,
                    Plaza = vehiculo.Plaza,
                    HoraIngreso = DateTime.Now
                };
                _db.Vehiculos.Add(model);
            }

            _db.SaveChanges();

            return CreatedAtRoute("GetVehiculo", new { id = vehiculo.IdVehiculo }, vehiculo);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteVehiculo(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var vehiculo = _db.Vehiculos.FirstOrDefault(v => v.IdVehiculo == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            _db.Vehiculos.Remove(vehiculo);
            _db.SaveChanges();

            return NoContent();
        }


        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialVehiculo(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var vehiculo = _db.Vehiculos.FirstOrDefault(v => v.IdVehiculo == id)!;
            vehiculo.HoraSalida = DateTime.Now;

            _db.Vehiculos.Update(vehiculo);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpGet("TotalVentas")]
        public IActionResult TotalVentas()
        {
            TotalVentasResultado total = new TotalVentasResultado();
            var ventas = _db.Database.SqlQuery<VentasResultado>($"SELECT Tipo, SUM(TotalVehiculo - (CASE WHEN AplicaDescuento = 1 THEN TotalVehiculo * 0.25 ELSE 0 END)) AS TotalVehiculo FROM (SELECT Tipo, AplicaDescuento, DATEDIFF(HOUR, HoraIngreso, HoraSalida) * CONVERT(FLOAT, (CASE WHEN Tipo = 'Automovil' THEN 120 ELSE 62 END)) AS TotalVehiculo FROM Vehiculos) AS Q GROUP BY Tipo").ToList();
            total.Automovil = ventas.Where(w => w.Tipo == "Automovil").DefaultIfEmpty(new VentasResultado()).FirstOrDefault()!.TotalVehiculo;
            total.Motocicleta = ventas.Where(w => w.Tipo == "Motocicleta").DefaultIfEmpty(new VentasResultado()).FirstOrDefault()!.TotalVehiculo;
            return Ok(total);
        }
    }
}
