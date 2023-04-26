using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebAppVentaDSI.Models
{
    public class Estado
    {
        [Key]
        [Display(Name = "ID")]
        public int IdEstado { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Dese ingresar el nombre del estado")]
        [MaxLength(100, ErrorMessage = "El campo no debe de tener mas de 100 caracteres")]
        public string NombreEstado { get; set; }

        public virtual ICollection<DetalleEmpleado> DetalleEmpleado { get; set; }
    }
}
