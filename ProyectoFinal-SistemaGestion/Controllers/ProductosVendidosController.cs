using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_SistemaGestion.Models;
using ProyectoFinal_SistemaGestion.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoFinal_SistemaGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosVendidosController : ControllerBase
    {
        // GET: api/<ProductosVendidosController>
        [HttpGet()]
        public IEnumerable<ProductoVendido> Get()
        {
            var listaProductosVendidos = ProductoVendidoRepository.GetProductosVendidos();
            return listaProductosVendidos;
        }

        // GET api/<ProductosVendidosController>/5
        [HttpGet("byIdDeVenta")]
        public IEnumerable<ProductoVendido> Get(long id)
        {
            var resp = ProductoVendidoRepository.GetProductosVendidos(id);
            return resp;
        }


        // POST api/<ProductosVendidosController>
        [HttpPost("Crear")]
        public void Post([FromBody] ProductoVendido prod)
        {
            ProductoVendidoRepository.Create(prod);
        }

        // PUT api/<ProductosVendidosController>
        [HttpPut("Actualizar")]
        public void Put([FromBody] ProductoVendido prod)
        {
            ProductoVendidoRepository.Update(prod);
        }

        // DELETE api/<ProductosVendidosController>
        [HttpDelete("Eliminar")]
        public void Delete(int id)
        {
            ProductoVendidoRepository.Delete(id);
        }
    }
}
