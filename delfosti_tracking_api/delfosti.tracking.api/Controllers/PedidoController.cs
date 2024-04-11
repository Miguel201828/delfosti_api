using delfosti.tracking.api.Interfaces;
using delfosti.tracking.api.Services;
using delfosti.tracking.entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace delfosti.tracking.api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PedidoController : Controller
    {
        private readonly IPedidoService _pedidoService;
        private readonly IUsuarioService _usuarioService;
        private readonly ILogger<PedidoController> _logger;
        public PedidoController(ILogger<PedidoController> logger, IPedidoService pedidoService, IUsuarioService usuarioService)
        {
            _logger = logger;
            _pedidoService = pedidoService;
            _usuarioService = usuarioService;
        }
        [HttpPost("NuevoPedido")]
        public async Task<IActionResult> GenerarNuevoPedido(Pedido ped)
        {
            Boolean tieneAcceso;
            tieneAcceso = await _usuarioService.PuedeAcceder(ped.usr.codigo_usuario, ped.usr.token);

            if (tieneAcceso)
            {
                Boolean pedidoCreado = false;
                pedidoCreado = await _pedidoService.Insert(ped);

                if (pedidoCreado)
                {
                    return Ok("Pedido Creado satisfactoriamente");
                }
                else
                {
                    return BadRequest("Error en la creacion del Pedido");
                }
            }
            else
            {
                return Unauthorized("No tiene Permiso para realizar esta accion");
            }
        }
        [HttpPut("CambiarEstadoPedido")]
        public async Task<IActionResult> CambiarEstadoPedido(CambioEstado cambioEstado)
        {
            Boolean tieneAcceso;
            tieneAcceso = await _usuarioService.PuedeAcceder(cambioEstado.usr.codigo_usuario, cambioEstado.usr.token);

            if (tieneAcceso)
            {
                String msje = "";
                msje = await _pedidoService.CambiarEstadoPedido(cambioEstado);
                return Ok(msje);
            }
            else
            {
                return Unauthorized("No tiene Permiso para realizar esta accion");
            }
        }
    }
}