using delfosti.tracking.api.Interfaces;
using delfosti.tracking.entities;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;


namespace delfosti.tracking.api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILogger<UsuarioController> _logger;
        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioService usuarioService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        [HttpPost("login/{correo}/{clave}")]
        public async Task<IActionResult> Login(String correo, String clave)
        {

            var usuario = (LoginSession) await _usuarioService.ObtenerDatosSession(correo, clave);

            if (usuario == null)
            {
                //return Unauthorized();
                return BadRequest(new { message = "Error buscando al usuario" });
            }
            if(usuario.nombre == null)
            {
                return NotFound(new { message = "No se encontro el usuario, revise sus credenciales" });
            }

            return Ok(usuario);
        }
    }
}
