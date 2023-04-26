using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebAppVentaDSI.Models
{
    public class DetalleComprobante
    {
        [Key]
        [Display(Name = "ID")]
        public int IdDetalleComprobante { get; set; }

        [Display(Name = "Cantidad")]
        public int CantidadDetalleComprobante { set; get; }

        public int IdProducto { get; set; }

        public int IdComprobante { get; set; }

        [ForeignKey("IdProducto")]
        public virtual Producto Producto { get; set; }

        [ForeignKey("IdComprobante")]
        public virtual Comprobante Comprobante { get; set; }
    }
}
