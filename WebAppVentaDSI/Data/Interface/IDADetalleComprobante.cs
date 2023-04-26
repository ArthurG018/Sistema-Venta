using WebAppVentaDSI.Models;

namespace WebAppVentaDSI.Data.Interface
{
    public interface IDADetalleComprobante
    {
        public IEnumerable<DetalleComprobante> GetDetalleComprobante();
        public int InsertDetalleComprobanteDet(DetalleComprobante detallComprobante);
        public DetalleComprobante GetIdDetalleComprobante(int id);
        public bool UpdateDetalleComprobante(DetalleComprobante detalleComprobante);
        public Boolean DeleteDetalleComprobante(int id);
    }
}
