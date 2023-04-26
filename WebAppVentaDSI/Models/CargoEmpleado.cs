using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebAppVentaDSI.Models
{
    public class CargoEmpleado
    {
        [Key]
        [Display(Name = "ID")]
        public int IdCargoEmpleado { get; set; }

        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "Debe ingresar el Cargo del Empleado")]
        [MaxLength(60, ErrorMessage = "El campo no debe de tener más de 60 caracteres")]
        public string NombreCargoEmpleado { get; set; }
        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}
