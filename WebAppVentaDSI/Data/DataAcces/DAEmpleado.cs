using Microsoft.EntityFrameworkCore;
using WebAppVentaDSI.Data.Interface;
using WebAppVentaDSI.Models;

namespace WebAppVentaDSI.Data.DataAcces
{
    public class DAEmpleado:IDAEmpleado
    {
        public IEnumerable<Empleado> GetEmpleado()
        {
            var listado = new List<Empleado>();
            using (var db = new ApplicationDbContext())
            {
                listado = db.Empleado.Include(item => item.CargoEmpleado).Include(item=>item.DetalleEmpleado).ThenInclude(item=>item.Estado).ToList();
            }
            return listado;
        }

        public int InsertEmpleado(Empleado empleado)
        {
            var resultado = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(empleado);
                db.SaveChanges();
                resultado = empleado.IdEmpleado;
            }
            return resultado;
        }

        //BUSCAR ID
        public Empleado GetIdEmpleado(int id)
        {
            var resultado = new Empleado();
            using (var db = new ApplicationDbContext())
            {
                resultado = db.Empleado.Where(item => item.IdEmpleado == id).Include(item => item.Comprobante)
                        .Include(item => item.CargoEmpleado).FirstOrDefault();
            }
            return resultado;
        }

        public bool UpdateEmpleado(Empleado empleado)//devuelve un valor bool (ACTUALIZA)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                db.Empleado.Attach(empleado);//REFERENCIAMOS A LA ENTIDAD
                db.Entry(empleado).State = EntityState.Modified;//se da un estado que se puede modificar
                resultado = db.SaveChanges() != 0;
            }
            return resultado;
        }

        public Boolean DeleteEmpleado(int id)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                var entidad = new Empleado()
                {
                    IdEmpleado = id
                };
                db.Empleado.Attach(entidad);
                db.Empleado.Remove(entidad);
                resultado = db.SaveChanges() != 0;
            }
            return resultado;
        }
    }
}
