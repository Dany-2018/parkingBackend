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

        [HttpGet("id:int")]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VehiculoDto> CreateVehiculo([FromBody] VehiculoDto vehiculo) 
        {
            if (vehiculo == null) 
            { 
                return BadRequest(); 
            }
            if(vehiculo.IdVehiculo > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            vehiculo.IdVehiculo = VehiculoStore.vehiculoList.OrderByDescending(v => v.IdVehiculo).FirstOrDefault().IdVehiculo + 1;
            VehiculoStore.vehiculoList.Add(vehiculo);

            return Ok(vehiculo);
        }

    
    }
}
