using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_SistemaGestion.Models;
using ProyectoFinal_SistemaGestion.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoFinal_SistemaGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        // GET: api/<UsuariosController>
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            var listaUsuario = UsuarioRepository.GetUsuarios();
            return listaUsuario;
        }

        // GET api/<UsuariosController>/5
        [HttpGet("byUsusarioyContraseña")]
        public Usuario Get(string user, string pass)
        {
            var usuario = UsuarioRepository.GetUsuario(user, pass);
            return usuario;
        }

        // GET api/<UsuariosController>/5
        [HttpGet("byId")]
        public Usuario Get(long id)
        {
            var usuario = UsuarioRepository.GetUsuario(id);
            return usuario;
        }

        // POST api/<UsuariosController>
        [HttpPost("Crear")]
        public void Post([FromBody] Usuario usuario)
        {
            UsuarioRepository.CreateUsuario(usuario);
        }

        // PUT api/<UsuariosController>
        [HttpPut("Editar")]
        public void Put([FromBody] Usuario usuario)
        {
            UsuarioRepository.UpdateUsuario(usuario);
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("Borrar")]
        public void Delete(long id)
        {
            UsuarioRepository.DeleteUsuario(id);
        }
    }
}
