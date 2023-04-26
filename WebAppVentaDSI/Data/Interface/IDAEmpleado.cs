using WebAppVentaDSI.Models;

namespace WebAppVentaDSI.Data.Interface
{
    public interface IDAEmpleado
    {
        public IEnumerable<Empleado> GetEmpleado();
        public int InsertEmpleado(Empleado empleado);
        public Empleado GetIdEmpleado(int id);
        public bool UpdateEmpleado(Empleado empleado);
        public Boolean DeleteEmpleado(int id);
    }
}
