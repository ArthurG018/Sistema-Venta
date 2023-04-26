using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebAppVentaDSI.Models
{
    public class FamiliaProducto
    {
        [Key]
        [Display(Name = "ID")]
        public int IdFamiliaProducto { get; set; }

        [Display(Name = "Familia")]
        [Required(ErrorMessage = "Debe ingresar el Tipo de Producto")]
        [MaxLength(60, ErrorMessage = "El campo no debe tener mas de 60 caracteres")]
        public string NombreFamiliaProducto { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
