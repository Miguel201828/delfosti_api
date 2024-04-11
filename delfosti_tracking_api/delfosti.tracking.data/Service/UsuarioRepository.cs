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

        public async Task<LoginSession> GrabarToken(LoginSession obj)
        {
            try
            {
                var conn = Connection;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_GUARDAR_TOKEN_USUARIO", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@codigo_usuario", SqlDbType.VarChar).Value = obj.codigo_trabajador;
                cmd.Parameters.Add("@token_desc", SqlDbType.VarChar).Value = obj.token;
                rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    obj.respuesta = rdr.GetString(0);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                obj.respuesta = ex.Message;
            }
            finally
            {
                if (Connection.State != ConnectionState.Closed) Connection.Close();
            }

            return obj;
        }

        public Task<bool> Insert(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginSession> ObtenerDatosSession(String correo, String clave)
        {
            LoginSession retorna = new LoginSession();
            try
            {
                var conn = Connection;

                conn.Open();

                SqlCommand cmd = new SqlCommand("sp_login", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = correo;
                cmd.Parameters.Add("@clave", SqlDbType.VarChar).Value = clave;
                rdr = await cmd.ExecuteReaderAsync();
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
                conn.Close();
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

        public async Task<Boolean> PuedeAcceder(String codigo, String token)
        {
            Boolean retorna = false;
            try
            {
                var conn = Connection;

                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_VALIDAR_TOKEN_USER", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@codigo_usuario", SqlDbType.VarChar).Value = codigo;
                cmd.Parameters.Add("@token_desc", SqlDbType.VarChar).Value = token;
                rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    retorna = rdr.GetBoolean(0);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                retorna = false;
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
