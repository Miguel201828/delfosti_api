using delfosti.tracking.api.Interfaces;
using delfosti.tracking.data.Interface;
using delfosti.tracking.entities;

namespace delfosti.tracking.api.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IConfiguration _configuration;
        public PedidoService(IPedidoRepository pedidoRepository, IConfiguration configuration)
        {
            _pedidoRepository = pedidoRepository;
            _configuration = configuration;
        }

        public async Task<string> CambiarEstadoPedido(CambioEstado cambioEstado)
        {
            return await _pedidoRepository.CambiarEstadoPedido(cambioEstado);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Pedido>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Pedido> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<Boolean> Insert(Pedido entidad)
        {
            return await _pedidoRepository.Insert(entidad);
        }

        public Task Update(int id, Pedido entidad)
        {
            throw new NotImplementedException();
        }
    }
}
