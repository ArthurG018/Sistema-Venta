using WebAppVentaDSI.Models;

namespace WebAppVentaDSI.Data.Interface
{
    public interface IDAMarcaProducto
    {
        public IEnumerable<MarcaProducto> GetMarcaProducto();
    }
}
