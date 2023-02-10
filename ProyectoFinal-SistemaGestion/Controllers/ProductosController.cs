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
            var resp = ProductoRepository.GetProductosbyUserId(idUsuario);
            return resp;
        }

        // POST api/<ProductosController>
        [HttpPost("Crear")]
        public string Post([FromBody] Producto producto)
        {
            var resp = ProductoRepository.CreateProducto(producto);
            if (resp == 1)
            {
                return $"El producto {producto.Descripciones} se ha creado correctamente";
            }
            else
            {
                return "Ha ocurrido un error";
            }

        }

        // PUT api/<ProductosController>
        [HttpPut("Actualizar")]
        public string Put([FromBody] Producto producto)
        {
            var resp = ProductoRepository.UpdateProducto(producto);

            if (resp == 1)
            {
                return $"El producto {producto.Descripciones} se ha actualizado correctamente";
            }
            else
            {
                return "Ha ocurrido un error";
            }
        }

        // DELETE api/<ProductosController>
        [HttpDelete("Borrar")]
        public string Delete(int id)
        {
            var resp = ProductoRepository.DeleteProducto(id);

            if (resp == 1)
            {
                return $"El producto id: {id} se ha borrado correctamente";
            }
            else
            {
                return "Ha ocurrido un error";
            }
        }
    }
}
