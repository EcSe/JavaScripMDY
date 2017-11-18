
namespace Entidades
{
    public class ProductoEntidad
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; } 
        public int IdProveedor { get; set; }
        public int IdCategoria { get; set; }
        public decimal PrecioUnitario { get; set; }
        public short Stock { get; set; }
    }
}
