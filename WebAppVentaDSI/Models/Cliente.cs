using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebAppVentaDSI.Models
{
    public class Cliente
    {
        [Key]
        [Display(Name = "ID")]
        public int IdCliente { get; set; }

        public string NombreCliente { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Debe ingresar los Apellidos del Cliente")]
        [MaxLength(90, ErrorMessage = "El campo no debe de tener más de 90 caracteres")]
        public string ApellidosCliente { get; set; }

        [Display(Name = "DNI")]
        [Required(ErrorMessage = "Debe ingresar el DNI del Cliente")]
        [MaxLength(20, ErrorMessage = "El campo no debe de tener más de 20 caracteres")]
        public string DNICliente { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Debe ingresar el Sexo del Cliente")]
        [MaxLength(1, ErrorMessage = "El campo no debe de tener más de 1 caracter")]
        public string SexoCliente { get; set; }

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "Debe ingresar el Número de Telefono del Cliente")]
        [MaxLength(9, ErrorMessage = "El campo no debe de tener más de 9 caracteres")]
        public string TelefonoCliente { get; set; }

        public DateTime FechaNacCliente { get; set; }

        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "Debe ingresar la Direccion del Cliente")]
        [MaxLength(60, ErrorMessage = "El campo no debe de tener más de 60 caracteres")]
        public string DireccionCliente { get; set; }


        //FK
        public virtual ICollection<Comprobante> Comprobante { get; set; }
        //Nombres completos
        [NotMapped]
        public string NombresCompletos { get { return NombreCliente.ToUpper() + " " + ApellidosCliente.ToUpper(); } }
    }
}
