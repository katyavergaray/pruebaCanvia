
namespace Entity
{
    public class ProductoModel
    {
        public long idProducto { get; set; }
        public string nombreProducto { get; set; }
        public int stock { get; set; }
        public decimal precio { get; set; }
        public string nombreCategoria { get; set; }
    }
    public class ProductoInsertModel
    {
        public string nombreProducto { get; set; }
        public int stock { get; set; }
        public decimal precio { get; set; }
        public long idCategoria { get; set; }
    }
    public class ProductoUpdateModel
    {
        public long idProducto { get; set; }
        public string nombreProducto { get; set; }
        public int stock { get; set; }
        public decimal precio { get; set; }
        public long idCategoria { get; set; }
    }
}
