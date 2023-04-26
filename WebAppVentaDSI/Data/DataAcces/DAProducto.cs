using Microsoft.EntityFrameworkCore;
using WebAppVentaDSI.Data.Interface;
using WebAppVentaDSI.Models;

namespace WebAppVentaDSI.Data.DataAcces
{
    public class DAProducto:IDAProducto
    {
        public IEnumerable<Producto> GetProducto()
        {
            var listado = new List<Producto>();
            using (var db = new ApplicationDbContext())
            {
                listado = db.Producto.Include(item => item.FamiliaProducto).Include(item=>item.MarcaProducto).ToList();
            }
            return listado;
        }
        public int InsertarProducto(Producto producto)
        {
            var resultado = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(producto);
                db.SaveChanges();
                resultado = producto.IdProducto;
            }
            return resultado;
        }

        //BUSCAR ID
        public Producto GetIdProducto(int id)
        {
            var resultado = new Producto();
            using (var db = new ApplicationDbContext())
            {
                resultado = db.Producto.Where(item => item.IdProducto == id).Include(item => item.FamiliaProducto)
                        .Include(item => item.MarcaProducto).FirstOrDefault();
            }
            return resultado;
        }

        public bool UpdateProducto(Producto producto)//devuelve un valor bool (ACTUALIZA)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                db.Producto.Attach(producto);//REFERENCIAMOS A LA ENTIDAD
                db.Entry(producto).State = EntityState.Modified;//se da un estado que se puede modificar
                resultado = db.SaveChanges() != 0;
            }
            return resultado;
        }

        public Boolean DeleteProducto(int id)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                var entidad = new Producto()
                {
                    IdProducto = id
                };
                db.Producto.Attach(entidad);
                db.Producto.Remove(entidad);
                resultado = db.SaveChanges() != 0;
            }
            return resultado;
        }
    }
}
