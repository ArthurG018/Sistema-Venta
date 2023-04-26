using Microsoft.EntityFrameworkCore;
using WebAppVentaDSI.Data.Interface;
using WebAppVentaDSI.Models;

namespace WebAppVentaDSI.Data.DataAcces
{
    public class DAMarcaProducto:IDAMarcaProducto
    {
        public IEnumerable<MarcaProducto> GetMarcaProducto()
        {
            var listado = new List<MarcaProducto>();
            using (var db = new ApplicationDbContext())
            {
                listado = db.MarcaProducto
                    .Include(item => item.Producto).ToList();
            }
            return listado;
        }
    }
}
