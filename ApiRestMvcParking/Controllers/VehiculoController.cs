using ApiRestMvcParking.Datos;
using ApiRestMvcParking.Models;
using ApiRestMvcParking.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestMvcParking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VehiculoDto>> GetVehiculo()
        {
            return Ok(VehiculoStore.vehiculoList);
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
            var vehiculo = VehiculoStore.vehiculoList.FirstOrDefault(v => v.IdVehiculo == id);

            if (vehiculo == null)
            {
                return NotFound();
            }

            return Ok(vehiculo);
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

            if (VehiculoStore.vehiculoList.FirstOrDefault(v => v.Placa.ToLower() == vehiculo.Placa.ToLower()) != null)
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
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            vehiculo.IdVehiculo = VehiculoStore.vehiculoList.OrderByDescending(v => v.IdVehiculo).FirstOrDefault().IdVehiculo + 1;
            VehiculoStore.vehiculoList.Add(vehiculo);

            return CreatedAtRoute("GetVehiculo", new { id = vehiculo.IdVehiculo }, vehiculo);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteVehiculo(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            var vehiculo = VehiculoStore.vehiculoList.FirstOrDefault(v=> v.IdVehiculo == id);
             if(vehiculo == null)
            {
                return NotFound();    
            }

             VehiculoStore.vehiculoList.Remove(vehiculo);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVehiculo(int id, [FromBody] Vehiculo vehiculoDto)
        {
            if(vehiculoDto == null || id!= vehiculoDto.IdVehiculo) 
            {
                return BadRequest();    
            }

            var vehiculo = VehiculoStore.vehiculoList.FirstOrDefault(v => v.IdVehiculo == id);

            vehiculo.Placa = vehiculoDto.Placa;
            vehiculo.Tipo = vehiculoDto.Tipo;
            vehiculo.Plaza = vehiculo.Plaza;
            vehiculo.AplicaDescuento = vehiculo.AplicaDescuento;
            vehiculo.HoraIngreso = vehiculo.HoraIngreso;

            return NoContent(); 


        }


    }
}
