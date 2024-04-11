using delfosti.tracking.api.Generic;
using delfosti.tracking.entities;

namespace delfosti.tracking.api.Interfaces
{
    public interface IUsuarioService: IGeneric<Usuario>
    {
        LoginSession ObtenerDatosSession(String correo, String clave);
    }
}
