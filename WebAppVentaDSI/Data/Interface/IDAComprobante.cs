using WebAppVentaDSI.Models;

namespace WebAppVentaDSI.Data.Interface
{
    public interface IDAComprobante
    {
        public IEnumerable<Comprobante> GetComprobante();
        public int InsertComprobante(Comprobante comprobante);
        public Comprobante GetIdComprobante(int id);
        public bool UpdatComprobante(Comprobante comprobante);
        public Boolean DeleteComprobante(int id);

    }
}
