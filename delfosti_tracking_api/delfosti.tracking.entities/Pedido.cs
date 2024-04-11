using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delfosti.tracking.entities
{
    public class Pedido
    {
        public Int32 nro_pedido { get; set; }
        public String fecha_pedido { get; set; }
        public String fecha_recepcion { get; set; }
        public String fecha_despacho { get; set; }
        public String fecha_entrega { get; set; }
        public String codigo_vendedor { get; set; }
        public String codigo_repartidor { get; set; }
        public Int32 id_estado_pedido { get; set; }
        public Decimal total_pedido { get; set; }
        public UserCrea usr { get; set; }
        public List<DetPedido> detalle {  get; set; }
    }
    public class UserCrea 
    {
        public String codigo_usuario { get; set;}
        public String token { get; set;}
    }
    public class DetPedido
    {
        public Int32 nro_item { get; set;}
        public String sku { get; set;}
        public Int32 cantidad { get; set;}
        public Decimal precio_unitario { get; set;}
        public Decimal total_detalle { get; set; }
    }
    public class CambioEstado
    {
        public Int32 nro_pedido { get; set; }
        public Int32 nuevo_estado { get; set; }
        public String fecha {  get; set;}
        public UserCrea usr { get; set; }
    }
}
