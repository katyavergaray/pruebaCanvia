

namespace Entity
{
    public class DetallePedidoModel
    {
        public long idDetallePedido { get; set; }
        public long idPedido { get; set; }
        public string nombreProducto { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal subTotal { get; set; }
    }
    public class DetallePedidoInsertModel
    {
        public long idPedido { get; set; }
        public long idProducto { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal subTotal { get; set; }
    }
    public class DetallePedidoUpdateModel
    {
        public long idPedido { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal subTotal { get; set; }
    }
}
