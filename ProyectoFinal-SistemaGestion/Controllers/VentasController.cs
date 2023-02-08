using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_SistemaGestion.Models;
using ProyectoFinal_SistemaGestion.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoFinal_SistemaGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        // GET: api/<VentasController>
        [HttpGet]
        public IEnumerable<Venta> Get()
        {
            var listaVentas = VentaRepository.GetVentas();
            return listaVentas;
        }

        // GET api/<VentasController>/5
        [HttpGet("byId")]
        public IEnumerable<Venta> Get(long id)
        {
            var listaVentas = VentaRepository.GetVentas(id);
            return listaVentas;
        }

        // POST api/<VentasController>
        [HttpPost("Crear")]
        public void Post([FromBody] Venta venta)
        {
            VentaRepository.CreateVenta(venta);
        }

        // PUT api/<VentasController>/5
        [HttpPut("Actualizar")]
        public void Put([FromBody] Venta venta)
        {
            VentaRepository.UpdateVenta(venta);
        }

        // DELETE api/<VentasController>/5
        [HttpDelete("Borrar")]
        public void Delete(long id)
        {
            VentaRepository.DeleteVenta(id);
        }
    }
}
