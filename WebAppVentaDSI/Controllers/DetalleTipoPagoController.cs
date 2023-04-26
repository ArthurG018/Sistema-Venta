using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppVentaDSI.Data.DataAcces;
using WebAppVentaDSI.Data.Interface;
using WebAppVentaDSI.Models;

namespace WebAppVentaDSI.Controllers
{
    [Authorize]
    public class DetalleTipoPagoController : Controller
    {
        private readonly IDATipoPago DATipoPago;
        private readonly IDAComprobante DAComprobante;
        private readonly IDADetalleTipoPago DADetalleTipoPago;
        private readonly IDADetalleComprobante DADetalleComprobante;

        public DetalleTipoPagoController(IDATipoPago DATipoPago, IDAComprobante DAComprobante, IDADetalleTipoPago DADetalleTipoPago, IDADetalleComprobante DADetalleComprobante)
        {
            this.DATipoPago = DATipoPago;
            this.DAComprobante = DAComprobante;
            this.DADetalleTipoPago = DADetalleTipoPago;
            this.DADetalleComprobante = DADetalleComprobante;
        }

        //Lista de pago pendiente:
        public double PagoTotalReal(int id)
        {
            double resultado=0 ;

            double realizado = PagRealizado(id);
            double pendiente = PagPendiente(id);
            resultado = pendiente - realizado;

            return resultado;
        }






        //Pagos Realizados
        public double PagRealizado(int idComprobante)
        {
            //var resultado = new List<double>();
            var comprobante = DAComprobante.GetComprobante();
            var detallepago = DADetalleTipoPago.GetDetalleTipoPago();
            double total = 0;

            //for (int i = 0; i < comprobante.Count(); i++)
            //{
                for (int j = 0; j < detallepago.Count(); j++)
                {
                    if (idComprobante == detallepago.ElementAt(j).IdComprobante)
                    {
                        total += detallepago.ElementAt(j).PagoDetallePago;
                    }
                }
                //resultado.Add(total);
                //total = 0;
            //}

            return total;
        }

        



        //Lo que debe pagar
        public double PagPendiente(int idComprobante)
        {


            //var resultado = new List<double>();
            var comprobante = DAComprobante.GetComprobante();
            var detallepago = new DADetalleComprobante().GetDetalleComprobante();
            double total = 0;

            //for (int i = 0; i < comprobante.Count(); i++)
            //{
            for (int j = 0; j < detallepago.Count(); j++)
            {
                if (idComprobante == detallepago.ElementAt(j).IdComprobante)
                {
                    total += detallepago.ElementAt(j).CantidadDetalleComprobante*detallepago.ElementAt(j).Producto.PrecioVentaProducto;
                }
            }
            //resultado.Add(total);
            //total = 0;
            //}
            return total;
        }






        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Create(int id)
        {
            if (id == 0)
            {


                var info = DADetalleComprobante.GetDetalleComprobante();
                var idC = (from tbl in info orderby tbl.IdDetalleComprobante descending select tbl).ToList();
                ViewBag.PagRealizado = PagRealizado(idC.ElementAt(0).IdComprobante);

                ViewBag.PagPendiente = PagPendiente(idC.ElementAt(0).IdComprobante);
                ViewBag.PagoReal = PagoTotalReal(idC.ElementAt(0).IdComprobante);

                ViewBag.InfoTipoPago = new DATipoPago().GetTipoPago();


                ViewBag.InfoComprobante = idC.ElementAt(0).IdComprobante;
            }
            else
            {
                ViewBag.PagRealizado = PagRealizado(id);

                ViewBag.PagPendiente = PagPendiente(id);
                ViewBag.PagoReal = PagoTotalReal(id);

                ViewBag.InfoTipoPago = new DATipoPago().GetTipoPago();


                ViewBag.InfoComprobante = id;
            }

            

            return View();
        }

        [HttpPost]
        public IActionResult Create(DetalleTipoPago Entidad)
        {
            Entidad.IdDetalleTipoPago = 0;
            //evaluamos los pagos
            //pago total realizado real
            double pagoRealizado = PagRealizado(Entidad.IdComprobante)+Entidad.PagoDetallePago;
            //el total que debe pagar
            double pagoTotal = PagPendiente(Entidad.IdComprobante);
            //evaluar el pago
            double Pagado = pagoTotal - pagoRealizado;
            //exacto
            if (Pagado == 0)
            {
                var resultado = new DADetalleTipoPago().InsertarDetalleTipoPago(Entidad);
                if (resultado > 0)
                {
                    return RedirectToAction("Index", "Comprobante");
                }
                else
                {
                    return View(resultado);
                }
                //pago menos, faltan pagos
            }else if (Pagado>0)
            {
                var resultado = new DADetalleTipoPago().InsertarDetalleTipoPago(Entidad);
                if (resultado > 0)
                {
                    //se evalua que falta pago y se redirecciona al mismo create para concretarlo
                    TempData["n"] = Entidad.IdComprobante;
                    return RedirectToAction("Create");
                }
                else
                {
                    return View(resultado);
                }
            }
            //pago de más recibe vuelto
            else
            {
                //se resta el pago para que sea exacto y dee 0
                Entidad.PagoDetallePago = Entidad.PagoDetallePago + Pagado;
                var resultado = new DADetalleTipoPago().InsertarDetalleTipoPago(Entidad);
                
                if (resultado > 0)
                {
                    return RedirectToAction("Index", "Comprobante");
                }
                else
                {
                    return View(resultado);
                }
            }
           
            //var model = new DADetalleComprobante();
           
        }

    }
}
