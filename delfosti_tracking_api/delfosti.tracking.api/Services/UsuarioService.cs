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

        public Task<bool> Insert(Usuario entidad)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginSession> ObtenerDatosSession(String correo, String clave)
        {
            var retorna = (LoginSession) await _usuarioRepository.ObtenerDatosSession(correo, clave);

            if (retorna != null)
            {
                if(retorna.nombre.Length > 0)
                {
                    var claveSecreta = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
                    var credenciales = new SigningCredentials(claveSecreta, SecurityAlgorithms.HmacSha256);

                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, retorna.nombre),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };
                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:Issuer"],
                        audience: _configuration["JWT:Audience"],
                        claims: claims,
                        expires: DateTime.UtcNow.AddHours(1),
                        signingCredentials: credenciales
                    );
                    retorna.token = new JwtSecurityTokenHandler().WriteToken(token);
                }
            }
            if (retorna.token.Length> 0)
            {
                retorna = (LoginSession)await _usuarioRepository.GrabarToken(retorna);
            }

            return retorna;
        }

        public async Task<Boolean> PuedeAcceder(String codigo, String token)
        {
            return (Boolean) await _usuarioRepository.PuedeAcceder(codigo, token);
        }

        public Task Update(int id, Usuario entidad)
        {
            throw new NotImplementedException();
        }
    }
}
