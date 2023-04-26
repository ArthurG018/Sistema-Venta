using Microsoft.EntityFrameworkCore;
using WebAppVentaDSI.Data.Interface;
using WebAppVentaDSI.Models;

namespace WebAppVentaDSI.Data.DataAcces
{
    public class DADetalleComprobante:IDADetalleComprobante
    {
        public IEnumerable<DetalleComprobante> GetDetalleComprobante()
        {
            var listado = new List<DetalleComprobante>();
            using (var db = new ApplicationDbContext())
            {
                listado = db.DetalleComprobante
                    .Include(item => item.Comprobante)
                        .ThenInclude(item => item.Cliente)
                    //comprobante
                    .Include(item => item.Comprobante)
                        .ThenInclude(item => item.TipoComprobante)
                    .Include(item => item.Comprobante)
                        .ThenInclude(item => item.Empleado)
                    .Include(item => item.Producto)
                        .ThenInclude(item => item.MarcaProducto).ToList();
            }
            return listado;
        }

        //INSERTAR
        public int InsertDetalleComprobanteDet(DetalleComprobante detallComprobante)
        {
            var resultado = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(detallComprobante);
                db.SaveChanges();
                resultado = detallComprobante.IdDetalleComprobante;
            }
            return resultado;
        }

        //BUSCAR ID
        public DetalleComprobante GetIdDetalleComprobante(int id)
        {
            var resultado = new DetalleComprobante();
            using (var db = new ApplicationDbContext())
            {
                resultado = db.DetalleComprobante.Where(item => item.IdDetalleComprobante == id).Include(item => item.Comprobante)
                        .ThenInclude(item => item.Cliente)
                    //comprobante
                    .Include(item => item.Comprobante)
                        .ThenInclude(item => item.TipoComprobante)
                    .Include(item => item.Comprobante)
                        .ThenInclude(item => item.Empleado)
                    .Include(item => item.Producto)
                        .ThenInclude(item => item.FamiliaProducto).FirstOrDefault();
            }
            return resultado;
        }

        public bool UpdateDetalleComprobante(DetalleComprobante detalleComprobante)//devuelve un valor bool (ACTUALIZA)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                db.DetalleComprobante.Attach(detalleComprobante);//REFERENCIAMOS A LA ENTIDAD
                db.Entry(detalleComprobante).State = EntityState.Modified;//se da un estado que se puede modificar
                db.Entry(detalleComprobante).Property(item => item.IdComprobante).IsModified = false;
                resultado = db.SaveChanges() != 0;
            }
            return resultado;
        }

        public Boolean DeleteDetalleComprobante(int id)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                var entidad = new DetalleComprobante()
                {
                    IdDetalleComprobante = id
                };
                db.DetalleComprobante.Attach(entidad);
                db.DetalleComprobante.Remove(entidad);
                resultado = db.SaveChanges() != 0;
            }
            return resultado;
        }
    }
}
