using delfosti.tracking.api.Generic;
using delfosti.tracking.entities;

namespace delfosti.tracking.api.Interfaces
{
    public interface IUsuarioService: IGeneric<Usuario>
    {
        Task<LoginSession> ObtenerDatosSession(String correo, String clave);
        Task<Boolean> PuedeAcceder(String codigo, String token);
    }
}
