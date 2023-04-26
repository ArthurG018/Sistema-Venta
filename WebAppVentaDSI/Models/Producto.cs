using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebAppVentaDSI.Models
{
    public class Producto
    {
        [Key]
        [Display(Name = "ID")]
        public int IdProducto { get; set; }

        [Display(Name = "Producto")]
        [Required(ErrorMessage = "Debe ingresar el Nombre del Producto")]
        [MaxLength(60, ErrorMessage = "El campo no debe de tener más de 60 caracteres")]
        public string NombreProducto { get; set; }

        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "Debe ingresar el Modelo del Producto")]
        [MaxLength(60, ErrorMessage = "El campo no debe de tener más de 60 caracteres")]
        public string ModeloProducto { get; set; }

        [Display(Name = "Precio Compra")]
        [Required(ErrorMessage = "Debe ingresar el Precio Compra del Producto")]
        public double PrecioCompraProducto { get; set; }

        [Display(Name = "Precio Venta")]
        [Required(ErrorMessage = "Debe ingresar el Precio Venta del Producto")]
        public double PrecioVentaProducto { get; set; }

        [Display(Name = "Stock")]
        [Required(ErrorMessage = "Debe ingresar el Stock del Producto")]
        public int StockProducto { get; set; }

        [Display(Name = "Descripcion")]
        [MaxLength(100, ErrorMessage = "El campo no debe de tener más de 100 caracteres")]
        public string? DescripcionProducto { get; set; }//NULL
        public int IdMarcaProducto { get; set; }
        public int IdFamiliaProducto { get; set; }

        [ForeignKey("IdFamiliaProducto")]
        public virtual FamiliaProducto FamiliaProducto { get; set; }
        [ForeignKey("IdMarcaProducto")]
        public virtual MarcaProducto MarcaProducto { get; set; }

        public virtual ICollection<DetalleComprobante> DetalleComprobante { get; set; }

        //Nombre + Precio
        [NotMapped]
        public string NombrePrecio { get { return NombreProducto.ToUpper() + " - S/" + PrecioVentaProducto+".00"; } }
    }
}
