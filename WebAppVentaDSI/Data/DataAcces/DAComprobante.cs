using Microsoft.EntityFrameworkCore;
using WebAppVentaDSI.Data.Interface;
using WebAppVentaDSI.Models;

namespace WebAppVentaDSI.Data.DataAcces
{
    public class DAComprobante:IDAComprobante
    {
        public IEnumerable<Comprobante> GetComprobante()
        {
            var listado = new List<Comprobante>();
            using (var db = new ApplicationDbContext())
            {
                listado = db.Comprobante.Include(item => item.DetalleComprobante)
                    .Include(item => item.DetalleTipoPago).Include(item => item.Cliente)
                    .Include(item => item.TipoComprobante).ToList();
            }
            return listado;
        }
        public int InsertComprobante(Comprobante comprobante)
        {
            var resultado = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(comprobante);
                db.SaveChanges();
                resultado = comprobante.IdComprobante;
            }
            return resultado;
        }

        //BUSCAR ID
        public Comprobante GetIdComprobante(int id)
        {
            var resultado = new Comprobante();
            using (var db = new ApplicationDbContext())
            {
                resultado = db.Comprobante.Where(item => item.IdComprobante == id).
                    Include(item => item.DetalleComprobante).Include(item => item.DetalleTipoPago).
                    Include(item => item.Cliente).Include(item => item.TipoComprobante).Include(item => item.Empleado).FirstOrDefault();
            }
            return resultado;
        }

        public bool UpdatComprobante(Comprobante comprobante)//devuelve un valor bool (ACTUALIZA)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                db.Comprobante.Attach(comprobante);//REFERENCIAMOS A LA ENTIDAD
                db.Entry(comprobante).State = EntityState.Modified;//se da un estado que se puede modificar
                db.Entry(comprobante).Property(item => item.FechaEmisionComprobante).IsModified = false;
                resultado = db.SaveChanges() != 0;
            }
            return resultado;
        }

        public Boolean DeleteComprobante(int id)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                var entidad = new Comprobante()
                {
                    IdComprobante = id
                };
                db.Comprobante.Attach(entidad);
                db.Comprobante.Remove(entidad);
                resultado = db.SaveChanges() != 0;
            }
            return resultado;
        }
    }
}
