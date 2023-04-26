using Microsoft.EntityFrameworkCore;
using WebAppVentaDSI.Data.Interface;
using WebAppVentaDSI.Models;

namespace WebAppVentaDSI.Data.DataAcces
{
    public class DATipoPago: IDATipoPago
    {
        public IEnumerable<TipoPago> GetTipoPago()
        {
            var listado = new List<TipoPago>();
            using (var db = new ApplicationDbContext())
            {
                listado = db.TipoPago.Include(x=>x.DetalleTipoPago).ToList();
            }
            return listado;
        }

        
    }
}
