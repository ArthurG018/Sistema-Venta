using WebAppVentaDSI.Models;

namespace WebAppVentaDSI.Data.Interface
{
    public interface IDAProducto
    {
        public IEnumerable<Producto> GetProducto();
        public int InsertarProducto(Producto producto);
        public Producto GetIdProducto(int id);
        public bool UpdateProducto(Producto producto);
        public Boolean DeleteProducto(int id);
    }
}
