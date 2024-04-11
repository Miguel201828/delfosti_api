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
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IConfiguration _config;
        private SqlDataReader rdr = null;
        public PedidoRepository(IConfiguration config)
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

        public async Task<String> CambiarEstadoPedido(CambioEstado entidad)
        {
            String retorna = "";
            try
            {
                var conn = Connection;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_CAMBIAR_ESTADO_PEDIDO", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nro_pedido", SqlDbType.Int).Value = entidad.nro_pedido;
                cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = DateTime.Parse(entidad.fecha);
                cmd.Parameters.Add("@id_estado_nuevo", SqlDbType.Int).Value = entidad.nuevo_estado;
                rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    retorna = rdr.GetString(0);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                retorna = "Error procesando el Cambio del estado";
            }
            finally
            {
                if (Connection.State != ConnectionState.Closed) Connection.Close();
            }

            return retorna;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pedido>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Pedido> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Boolean> Insert(Pedido entity)
        {
            Boolean retorna = false;
            try
            {
                var conn = Connection;
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_Crear_Pedido", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nro_pedido", SqlDbType.Int).Value = entity.nro_pedido;
                cmd.Parameters.Add("@fecha_pedido", SqlDbType.DateTime).Value = DateTime.Parse(entity.fecha_pedido);
                cmd.Parameters.Add("@codigo_vendedor", SqlDbType.VarChar).Value = entity.codigo_vendedor;
                cmd.Parameters.Add("@codigo_repartidor", SqlDbType.VarChar).Value = entity.codigo_repartidor;
                cmd.Parameters.Add("@id_estado_pedido", SqlDbType.Int).Value = entity.id_estado_pedido;
                cmd.Parameters.Add("@total_pedido", SqlDbType.Decimal).Value = entity.total_pedido;
                cmd.Parameters.Add("@ListaDetalle", SqlDbType.Structured).Value = entity.detalle;
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

        public Task<bool> Update(Pedido entity)
        {
            throw new NotImplementedException();
        }
    }
}
