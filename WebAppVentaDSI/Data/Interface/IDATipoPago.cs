using WebAppVentaDSI.Models;

namespace WebAppVentaDSI.Data.Interface
{
    public interface IDATipoPago
    {
        public IEnumerable<TipoPago> GetTipoPago();
    }
}
