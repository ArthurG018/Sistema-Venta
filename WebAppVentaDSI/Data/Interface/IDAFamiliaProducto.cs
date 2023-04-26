using WebAppVentaDSI.Models;

namespace WebAppVentaDSI.Data.Interface
{
    public interface IDAFamiliaProducto
    {
        public IEnumerable<FamiliaProducto> GetFamiliaProducto();
    }
}
