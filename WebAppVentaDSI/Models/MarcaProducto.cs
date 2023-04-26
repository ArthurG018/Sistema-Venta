using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebAppVentaDSI.Models
{
    public class MarcaProducto
    {
        [Key]
        [Display(Name = "ID")]
        public int IdMarcaProducto { get; set; }

        [Display(Name = "Marca")]
        [Required(ErrorMessage = "Se debe ingresar el nombre de la marca del producto")]
        [MaxLength(60, ErrorMessage = "El campo no debe tener mas de 60 caracteres")]
        public string NombreMarcaProducto { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
