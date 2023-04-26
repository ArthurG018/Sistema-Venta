using WebAppVentaDSI.Models;

namespace WebAppVentaDSI.Data.Interface
{
    public interface IDADetalleEmpleado
    {
        public IEnumerable<DetalleEmpleado> GetDetalleEmpleado();
        public int InsertDetalleEmpleado(DetalleEmpleado detalleEmpleado);
    }
}
