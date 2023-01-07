using ASP.NET_webAPi.Models;
using ASP.NET_webAPi.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_webAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>>GetAll()
        {
            List<Usuario>usuarios = await _usuarioRepositorio.GetUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            Usuario usuario = await _usuarioRepositorio.GetById(id);
            return Ok(usuario);
        }
        [HttpPost]
        public async Task<ActionResult<Usuario>> Insert([FromBody]Usuario user)
        {
            Usuario usuario = await _usuarioRepositorio.Insert(user);
            return Ok(usuario);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Update([FromBody] Usuario user, int id)
        {
            user.Id= id;
            Usuario usuario = await _usuarioRepositorio.Update(user, id);
            return Ok(usuario);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> Delete(int id)
        {
            bool deletado = await _usuarioRepositorio.Delete(id);
            return Ok(deletado);
        }
    }
}