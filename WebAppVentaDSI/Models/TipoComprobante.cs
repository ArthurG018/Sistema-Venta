using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebAppVentaDSI.Models
{
    public class TipoComprobante
    {
        [Key]
        [Display(Name = "ID")]
        public int IdTipoComprobante { get; set; }

        [Display(Name = "Tipo Comprobante")]
        [Required(ErrorMessage = "Debe ingresar el nombre del Tipo de Comprobante")]
        [MaxLength(60, ErrorMessage = "El campo no debe tener mas de 60 caracteres")]
        public string NombreTipoComprobante { get; set; }

        public virtual ICollection<Comprobante> Comprobante { get; set; }
    }
}
