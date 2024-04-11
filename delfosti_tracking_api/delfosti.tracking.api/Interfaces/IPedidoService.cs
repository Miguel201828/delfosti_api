using delfosti.tracking.api.Generic;
using delfosti.tracking.entities;

namespace delfosti.tracking.api.Interfaces
{
    public interface IPedidoService : IGeneric<Pedido>
    {
        Task<String> CambiarEstadoPedido(CambioEstado cambioEstado);
    }
}
