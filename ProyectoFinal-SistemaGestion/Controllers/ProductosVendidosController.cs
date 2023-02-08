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
        [HttpGet("byId")]
        public IEnumerable<ProductoVendido> Get(long id)
        {
            var resp = ProductoVendidoRepository.GetProductosVendidos(id);
            return resp;
        }

        // GET api/<ProductosVendidosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductosVendidosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductosVendidosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductosVendidosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
