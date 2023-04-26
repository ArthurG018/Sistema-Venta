using WebAppVentaDSI.Models;

namespace WebAppVentaDSI.Data.Interface
{
    public interface IDADetalleTipoPago
    {
        public IEnumerable<DetalleTipoPago> GetDetalleTipoPago();
        public int InsertarDetalleTipoPago(DetalleTipoPago detalletipopago);
    }
}
