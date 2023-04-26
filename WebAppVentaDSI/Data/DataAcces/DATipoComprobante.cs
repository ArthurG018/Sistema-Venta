using Microsoft.EntityFrameworkCore;
using WebAppVentaDSI.Data.Interface;
using WebAppVentaDSI.Models;

namespace WebAppVentaDSI.Data.DataAcces
{
    public class DATipoComprobante:IDATipoComprobante
    {
        public IEnumerable<TipoComprobante> GetTipoComprobante()
        {
            var listado = new List<TipoComprobante>();
            using (var db = new ApplicationDbContext())
            {
                listado = db.TipoComprobante.Include(item => item.Comprobante).ToList();
            }
            return listado;
        }
    }
}
