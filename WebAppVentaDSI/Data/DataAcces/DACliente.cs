using Microsoft.EntityFrameworkCore;
using WebAppVentaDSI.Data.Interface;
using WebAppVentaDSI.Models;

namespace WebAppVentaDSI.Data.DataAcces
{
    public class DACliente:IDACliente
    {
        public IEnumerable<Cliente> GetCliente()
        {
            var listado = new List<Cliente>();
            using (var db = new ApplicationDbContext())
            {
                listado = db.Cliente.Include(item => item.Comprobante).ToList();
            }
            return listado;
        }

        public int InsertCliente(Cliente cliente)
        {
            var resultado = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(cliente);
                db.SaveChanges();
                resultado = cliente.IdCliente;
            }
            return resultado;
        }

        //BUSCAR ID
        public Cliente GetIdCliente(int id)
        {
            var resultado = new Cliente();
            using (var db = new ApplicationDbContext())
            {
                resultado = db.Cliente.Where(item => item.IdCliente == id).
                    Include(item => item.Comprobante).FirstOrDefault();
            }
            return resultado;
        }

        public bool UpdatCliente(Cliente cliente)//devuelve un valor bool (ACTUALIZA)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                db.Cliente.Attach(cliente);//REFERENCIAMOS A LA ENTIDAD
                db.Entry(cliente).State = EntityState.Modified;//se da un estado que se puede modificar
                resultado = db.SaveChanges() != 0;
            }
            return resultado;
        }

        public Boolean DeleteCliente(int id)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                var entidad = new Cliente()
                {
                    IdCliente = id
                };
                db.Cliente.Attach(entidad);
                db.Cliente.Remove(entidad);
                resultado = db.SaveChanges() != 0;
            }
            return resultado;
        }
    }
}
