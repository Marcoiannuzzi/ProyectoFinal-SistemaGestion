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

        // GET api/<VentasController>
        [HttpGet("byIdDeUsuario")]
        public IEnumerable<Venta> Get(long id)
        {
            var listaVentas = VentaRepository.GetVentas(id);
            return listaVentas;
        }

        // POST api/<VentasController>
        [HttpPost("Crear")]
        public string Post([FromBody] Venta venta)
        {
            var resp = VentaRepository.CreateVenta(venta);

            if (resp == 1)
            {
                return $" La Venta se ha creado correctamente";
            }
            else
            {
                return "Ha ocurrido un error";
            }
        }

        // POST api/<VentasController>
        [HttpPost("CargarVenta")]
        public string Post(long idUsuario, [FromBody] List<Producto> productos )
        {
            var resp = VentaRepository.CargarVenta(idUsuario, productos);

            if (resp == 1)
            {
                return $" La Venta se ha cargado correctamente";
            }
            else
            {
                return "Ha ocurrido un error";
            }
        }

        // PUT api/<VentasController>
        [HttpPut("Actualizar")]
        public string Put([FromBody] Venta venta)
        {
            var resp = VentaRepository.UpdateVenta(venta);

            if (resp == 1)
            {
                return $" La Venta se ha actualizado correctamente";
            }
            else
            {
                return "Ha ocurrido un error";
            }
        }

        // DELETE api/<VentasController>
        [HttpDelete("Borrar")]
        public string Delete(long id)
        {
            var resp = VentaRepository.DeleteVenta(id);

            if (resp == 1)
            {
                return $" La Venta se ha borrado correctamente";
            }
            else
            {
                return "Ha ocurrido un error";
            }
        }
    }
}
