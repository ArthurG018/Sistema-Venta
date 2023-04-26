using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebAppVentaDSI.Models
{
    public class DetalleTipoPago
    {
        [Key]
        [Display(Name = "ID")]
        public int IdDetalleTipoPago { get; set; }

        [Display(Name = "Pago")]
        public double PagoDetallePago { get; set; }

        public int IdComprobante { get; set; }

        public int IdTipoPago { get; set; }

        [ForeignKey("IdComprobante")]
        public virtual Comprobante Comprobante { get; set; }

        [ForeignKey("IdTipoPago")]
        public virtual TipoPago TipoPago { get; set; }
    }
}
