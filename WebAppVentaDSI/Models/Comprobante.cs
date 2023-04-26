using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebAppVentaDSI.Models
{
    public class Comprobante
    {
        [Key]
        [Display(Name = "ID")]
        public int IdComprobante { get; set; }

        [Display(Name = "Fecha de Emision")]
        public DateTime FechaEmisionComprobante { get; set; }

        public int IdEmpleado { get; set; }

        public int IdCliente { get; set; }

        public int IdTipoComprobante { get; set; }

        [ForeignKey("IdEmpleado")]
        public virtual Empleado Empleado { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Cliente Cliente { get; set; }

        [ForeignKey("IdTipoComprobante")]
        public virtual TipoComprobante TipoComprobante { get; set; }
        //la clase que hereda fk

        public virtual ICollection<DetalleComprobante> DetalleComprobante { get; set; }

        public virtual ICollection<DetalleTipoPago> DetalleTipoPago { get; set; }

        [NotMapped]
        public string CodigoComprobante { get{ return "COMP000" + IdComprobante; } }
    }
}
