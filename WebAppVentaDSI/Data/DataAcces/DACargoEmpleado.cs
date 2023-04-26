using Microsoft.EntityFrameworkCore;
using WebAppVentaDSI.Data.Interface;
using WebAppVentaDSI.Models;

namespace WebAppVentaDSI.Data.DataAcces
{
    public class DACargoEmpleado : IDACargoEmpleado
    {
        public IEnumerable<CargoEmpleado> GetCargoEmpleado()
        {
            var listado = new List<CargoEmpleado>();
            using (var db = new ApplicationDbContext())
            {
                listado = db.CargoEmpleado
                    .Include(item => item.Empleado).ToList();
            }
            return listado;
        }
    }
}
