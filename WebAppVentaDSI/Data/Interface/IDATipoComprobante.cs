using WebAppVentaDSI.Models;

namespace WebAppVentaDSI.Data.Interface
{
    public interface IDATipoComprobante
    {
        public IEnumerable<TipoComprobante> GetTipoComprobante();
    }
}
