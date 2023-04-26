using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebAppVentaDSI.Models
{
    public class Empleado
    {
        [Key]
        [Display(Name = "ID")]
        public int IdEmpleado { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar el Nombre del Empleado")]
        [MaxLength(60, ErrorMessage = "El campo no debe de tener más de 60 caracteres")]
        public string NombreEmpleado { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Debe ingresar los Apellidos del Empleado")]
        [MaxLength(90, ErrorMessage = "El campo no debe de tener más de 90 caracteres")]
        public string ApellidosEmpleado { get; set; }

        [Display(Name = "DNI")]
        [Required(ErrorMessage = "Debe ingresar el DNI del Empleado")]
        [MaxLength(20, ErrorMessage = "El campo no debe de tener más de 20 caracteres")]
        public string DNIEmpleado { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Debe ingresar el Sexo del Empleado")]
        [MaxLength(1, ErrorMessage = "El campo no debe de tener más de 1 caracteres")]
        public string SexoEmpleado { get; set; }

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "Debe ingresar el Numero de Telefono del Empleado")]
        [MaxLength(9, ErrorMessage = "El campo no debe de tener más de 9 caracteres")]
        public string TelefonoEmpleado { get; set; }

        public DateTime FechaNacEmpleado { get; set; }

        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "Debe ingresar la Direccion del Empleado")]
        [MaxLength(60, ErrorMessage = "El campo no debe de tener más de 60 caracteres")]
        public string DireccionEmpleado { get; set; }

        //FK
        public int IdCargoEmpleado { get; set; }
        //FK VIRTUAL PARA RELACIONAR
        [ForeignKey("IdCargoEmpleado")]
        public virtual CargoEmpleado CargoEmpleado { get; set; }
        public virtual ICollection<Comprobante> Comprobante { get; set; }
        public virtual ICollection<DetalleEmpleado> DetalleEmpleado { get; set; }

        //NOMBRES COMPLETOS NO SE MIGRA A LA BD
        [NotMapped]
        public string NombresCompletos { get { return NombreEmpleado.ToUpper() + " " + ApellidosEmpleado.ToUpper(); } }
    }
}
