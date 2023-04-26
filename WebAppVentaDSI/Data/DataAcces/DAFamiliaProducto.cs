using Microsoft.EntityFrameworkCore;
using WebAppVentaDSI.Data.Interface;
using WebAppVentaDSI.Models;

namespace WebAppVentaDSI.Data.DataAcces
{
    public class DAFamiliaProducto:IDAFamiliaProducto
    {
        public IEnumerable<FamiliaProducto> GetFamiliaProducto()
        {
            var listado = new List<FamiliaProducto>();
            using (var db = new ApplicationDbContext())
            {
                listado = db.FamiliaProducto.Include(item => item.Producto).ToList();
            }
            return listado;
        }
    }
}
