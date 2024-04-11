using delfosti.tracking.data.Interface;
using delfosti.tracking.entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delfosti.tracking.data.Service
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConfiguration _config;
        private SqlDataReader rdr = null;
        public UsuarioRepository(IConfiguration config)
        {
            _config = config;
        }
        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("SQLServerConnection"));
            }
        }
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public LoginSession ObtenerDatosSession(String correo, String clave)
        {
            LoginSession retorna = new LoginSession();
            try
            {
                Connection.Open();

                SqlCommand cmd = new SqlCommand("sp_login", Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = correo;
                cmd.Parameters.Add("@clave", SqlDbType.VarChar).Value = clave;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    retorna.codigo_trabajador = rdr.GetString(0);
                    retorna.nombre = rdr.GetString(1);
                    retorna.telefono = rdr.GetString(2);
                    retorna.codigo_puesto = rdr.GetString(3);
                    retorna.codigo_rol = rdr.GetString(4);
                    retorna.Puesto = rdr.GetString(5);
                    retorna.Rol = rdr.GetString(6);
                }
            }
            catch (Exception ex)
            {
                retorna = null;
            }
            finally
            {
                if (Connection.State != ConnectionState.Closed) Connection.Close();
            }

            return retorna;
        }

        public Task<bool> Update(Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}
