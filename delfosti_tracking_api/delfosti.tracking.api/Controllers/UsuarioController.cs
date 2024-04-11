using delfosti.tracking.api.Interfaces;
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

            var usuario = _usuarioService.ObtenerDatosSession(correo, clave);

            if (usuario == null)
            {
                //return Unauthorized();
                return BadRequest(new { message = "Credenciales invalidas" });
            }

            return Ok(usuario);
        }
    }
}
