using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delfosti.tracking.entities
{
    public class Usuario
    {
        public String codigo_trabajador { get; set; }
        public String nombre { get; set; }
        public String correo { get; set; }
        public String clave { get; set; }
        public String telefono { get; set; }
        public String codigo_puesto { get; set; }
        public String codigo_rol { get; set; }
    }
    public class LoginSession
    {
        public String codigo_trabajador { get; set; }
        public String nombre { get; set; }
        public String telefono { get; set; }
        public String codigo_puesto { get; set; }
        public String codigo_rol { get; set; }
        public String Puesto { get; set; }
        public String Rol { get; set; }

        public String token { get; set; }   
        public String respuesta { get; set; }

    }
}
