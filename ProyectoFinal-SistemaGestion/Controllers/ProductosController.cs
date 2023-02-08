using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_SistemaGestion.Models;
using ProyectoFinal_SistemaGestion.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoFinal_SistemaGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        // GET: api/<ProductosController>
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            var resp = ProductoRepository.GetProductos();
            return resp;
        }

        // GET api/<ProductosController>/5
        [HttpGet("byUserId")]
        public IEnumerable<Producto> Get(long idUsuario)
        {
            var resp = ProductoRepository.GetProductosbyId(idUsuario);
            return resp;
        }

        // POST api/<ProductosController>
        [HttpPost("Crear")]
        public void Post([FromBody] Producto producto)
        {
            ProductoRepository.CreateProducto(producto);
        }

        // PUT api/<ProductosController>
        [HttpPut("Actualizar")]
        public void Put([FromBody] Producto producto)
        {
            ProductoRepository.UpdateProducto(producto);
        }

        // DELETE api/<ProductosController>
        [HttpDelete("Borrar")]
        public void Delete(int id)
        {
            ProductoRepository.DeleteProducto(id);
        }
    }
}
