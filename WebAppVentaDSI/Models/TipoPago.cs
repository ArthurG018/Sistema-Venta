using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebAppVentaDSI.Models
{
    public class TipoPago
    {
        [Key]
        [Display(Name = "ID")]
        public int IdTipoPago { get; set; }

        [Display(Name = "Tipo Pago")]
        [Required(ErrorMessage = "Debe ingresar el nombre del Tipo de Pago")]
        [MaxLength(60, ErrorMessage = "El campo no debe tener mas de 60 caracteres")]
        public string NombreTipoPago { get; set; }

        public virtual ICollection<DetalleTipoPago> DetalleTipoPago { get; set; }
    }
}
