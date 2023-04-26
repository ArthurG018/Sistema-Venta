using WebAppVentaDSI.Models;

namespace WebAppVentaDSI.Data.Interface
{
    public interface IDACargoEmpleado
    {
        public IEnumerable<CargoEmpleado> GetCargoEmpleado();
    }
}
