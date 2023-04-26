using WebAppVentaDSI.Models;

namespace WebAppVentaDSI.Data.Interface
{
    public interface IDACliente
    {
        public IEnumerable<Cliente> GetCliente();
        public int InsertCliente(Cliente cliente);
        public Cliente GetIdCliente(int id);
        public bool UpdatCliente(Cliente cliente);
        public Boolean DeleteCliente(int id);
    }
}
