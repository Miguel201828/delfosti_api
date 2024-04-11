using delfosti.tracking.data.Generic;
using delfosti.tracking.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delfosti.tracking.data.Interface
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        LoginSession ObtenerDatosSession(String correo, String clave);
    }
}
