using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebAppVentaDSI.Models
{
    public class DetalleEmpleado
    {
        [Key]
        [Display(Name = "ID")]
        public int IdDetalleEmpleado { get; set; }

        [Display(Name = "Fecha")]
        public DateTime FechaDetalleEmpleado { get; set; }

        public int IdEmpleado { get; set; }

        public int IdEstado { get; set; }

        [ForeignKey("IdEmpleado")]
        public virtual Empleado Empleado { get; set; }

        [ForeignKey("IdEstado")]
        public virtual Estado Estado { get; set; }
    }
}
