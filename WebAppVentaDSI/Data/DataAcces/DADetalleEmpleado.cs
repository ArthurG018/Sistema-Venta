using Microsoft.EntityFrameworkCore;
using WebAppVentaDSI.Data.Interface;
using WebAppVentaDSI.Models;

namespace WebAppVentaDSI.Data.DataAcces
{
    public class DADetalleEmpleado : IDADetalleEmpleado
    {
        public IEnumerable<DetalleEmpleado> GetDetalleEmpleado()
        {
            var listado = new List<DetalleEmpleado>();
            using (var db = new ApplicationDbContext())
            {
                listado = db.DetalleEmpleado
                    .Include(item => item.Empleado)
                    .Include(item => item.Estado).ToList();
            }
            return listado;
        }


        public int InsertDetalleEmpleado(DetalleEmpleado detalleEmpleado)
        {
            var resultado = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(detalleEmpleado);
                db.SaveChanges();
                resultado = detalleEmpleado.IdDetalleEmpleado;
            }
            return resultado;
        }
    }
}
