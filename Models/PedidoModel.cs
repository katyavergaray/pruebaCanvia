
using System;

namespace Entity
{
    public class PedidoModel
    {
        public long idPedido { get; set; }
        public DateTime fechaEmision { get; set; }
        public decimal total { get; set; }
        public string observaciones { get; set; }
        public string codigo { get; set; }
        public long idEstadoPedido { get; set; }
    }
    public class PedidoInsertModel
    {
        public decimal total { get; set; }
        public string observaciones { get; set; }
        public long idEstadoPedido { get; set; }
    }
    public class PedidoUpdateModel
    {
        public long idPedido { get; set; }
        public string observaciones { get; set; }
    }
}
