using Microsoft.EntityFrameworkCore;
using WebAppVentaDSI.Data.Interface;
using WebAppVentaDSI.Models;

namespace WebAppVentaDSI.Data.DataAcces
{
    public class DADetalleTipoPago:IDADetalleTipoPago
    {
        public IEnumerable<DetalleTipoPago> GetDetalleTipoPago()
        {
            var listado = new List<DetalleTipoPago>();
            using (var db = new ApplicationDbContext())
            {
                listado = db.DetalleTipoPago.Include(item => item.TipoPago).Include(item => item.Comprobante).ToList();
            }
            return listado;
        }
        //INSERTAR
        public int InsertarDetalleTipoPago(DetalleTipoPago detalletipopago)
        {
            var resultado = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(detalletipopago);
                db.SaveChanges();
                resultado = detalletipopago.IdDetalleTipoPago;
            }
            return resultado;
        }
    }
}
