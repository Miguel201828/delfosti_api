using delfosti.tracking.api.Interfaces;
using delfosti.tracking.data.Interface;
using delfosti.tracking.entities;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace delfosti.tracking.api.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;
        public UsuarioService(IUsuarioRepository usuarioRepository, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Usuario>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Usuario entidad)
        {
            throw new NotImplementedException();
        }

        public LoginSession ObtenerDatosSession(String correo, String clave)
        {
            var retorna = _usuarioRepository.ObtenerDatosSession(correo, clave);

            return retorna;
        }

        public Task Update(int id, Usuario entidad)
        {
            throw new NotImplementedException();
        }
    }
}
