using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppVentaDSI.Data.DataAcces;
using WebAppVentaDSI.Data.Interface;
using WebAppVentaDSI.Models;
using X.PagedList;

namespace WebAppVentaDSI.Controllers
{
    [Authorize]
    public class DetalleComprobanteController : Controller
    {
        private readonly IDADetalleComprobante DADetalleComprobante;
        private readonly IDAProducto DAProducto;
        private readonly IDAComprobante DAComprobante;
        public DetalleComprobanteController(IDADetalleComprobante DADetalleComprobante, IDAProducto DAProducto, IDAComprobante DAComprobante)
        {
            this.DADetalleComprobante = DADetalleComprobante; 
            this.DAProducto = DAProducto;
            this.DAComprobante = DAComprobante;
        }

        public List<double> lista(IEnumerable<DetalleComprobante> informacion)
            {
                var resultado = new List<double>();
                double total = 0;
                foreach (var item in informacion)
                {
                    total = (item.CantidadDetalleComprobante * item.Producto.PrecioVentaProducto);
                    resultado.Add(total);
                }
                return resultado;
            }
        public double Total(int id)
        {
            double total = 0;
            var info = DADetalleComprobante.GetDetalleComprobante();
            foreach (var item in info)
            {
                if (item.IdComprobante==id)
                {
                    total += (item.CantidadDetalleComprobante * item.Producto.PrecioVentaProducto);
                }
            }

            return total;
        }

        public String Condicion(int id)
        {
            string condicion = "";
            //para saber cuanto pago:
            double detallepago = 0;
            var detpago = new DADetalleTipoPago().GetDetalleTipoPago();
            foreach (var item in detpago)
            {
                if (item.IdComprobante==id)
                {
                    detallepago += item.PagoDetallePago;
                }
            }
            //para saber cuando debe pagar:
            var detcomp = DADetalleComprobante.GetDetalleComprobante();
            double detallecomp = 0;
            foreach (var item in detcomp)
            {
                if (item.IdComprobante==id)
                {
                    detallecomp += (item.CantidadDetalleComprobante*item.Producto.PrecioVentaProducto);
                }
            }
            double total = detallecomp - detallepago;
            if (total<=0)
            {
                condicion = "Cancelado";
            }
            else
            {
                condicion = "SinCancelar";
            }
            return condicion;
        }
        

        public IActionResult Index( int id, int page=1)
            {
            //var model = new DADetalleComprobante();
            var pagenumber = page;
                var DC = DADetalleComprobante.GetDetalleComprobante();
                    DC=(from tbl in DC where tbl.IdComprobante == id select tbl ).ToList();
                //if (filterByName != null)
                //{
                //    var filtro = (from tbl in DC
                //                  where tbl.Comprobante.Cliente.NombreCliente.ToLower().Contains(filterByName.ToLower())
                //                  select tbl).ToList();
                //    var model = filtro.OrderByDescending(d => d.IdDetalleComprobante).ToList().ToPagedList(pagenumber, 8);
                //    var envio = lista(model); 
                //    ViewBag.Total = envio;
                //   // DC = filtro;
                //    TempData["info"] = model;
                //    ViewBag.DetPag = Condicion(id);
                //}
                //else
                //{
                    var model = DC.OrderByDescending(d => d.IdDetalleComprobante).ToList().ToPagedList(pagenumber, 8);
                    var envio = lista(model);
                    ViewBag.Total = envio;
                    TempData["info"] = model;
                    ViewBag.DetPag = Condicion(id);
                //}
                TempData["IdComp"] = id;
                return View();
            }

            public IActionResult Create( int id)
            {
                //Listar Producto
                //var infoProducto = new DAProducto();
                ViewBag.InfoProducto = DAProducto.GetProducto();
                

            if (id==0)
            {
                var info = new DAComprobante().GetComprobante();
                var cod = (from tbl in info orderby tbl.IdComprobante descending select tbl.IdComprobante).ToList();//primer valor
                int pos = cod.ElementAt(0);
                ViewBag.InfoComprobante = pos;
                ViewBag.InfoTotal ="Total:  S/"+ Total(pos)+".00";


            }
            else
            {
                ViewBag.InfoComprobante = id;
                ViewBag.InfoTotal = "Total:  S/"+Total(id)+".00";
            }
                //Listar Comprobantes
                //var infoComprobante = new DAComprobante();
                

                return View();
            }

            [HttpPost]
            public IActionResult Create(DetalleComprobante Entidad)
            {
                Entidad.IdDetalleComprobante = 0;
                //var model = new DADetalleComprobante();
                var resultado = DADetalleComprobante.InsertDetalleComprobanteDet(Entidad);
                if (resultado > 0)
                {
                //TempData["n"] = Entidad.IdComprobante;
                    return RedirectToAction("Create");
                }
                else
                {
                    return View(resultado);
                }
            }
            public IActionResult Edit(int id)
            {
                //var ProductoEdit = new DAProducto();
                ViewBag.ProductoEdit = DAProducto.GetProducto();

                //var ComprobanteEdit = new DAComprobante();
                ViewBag.ComprobanteEdit = DAComprobante.GetComprobante();

                //var model = new DADetalleComprobante();
                var resultado = DADetalleComprobante.GetIdDetalleComprobante(id);
                return View(resultado);
            }

            [HttpPost]
            public IActionResult Edit(DetalleComprobante detalleComprobante)
            {

                //var model = new DADetalleComprobante();
                var resultao = DADetalleComprobante.UpdateDetalleComprobante(detalleComprobante);
                if (resultao)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(detalleComprobante);
                }
            }

            public IActionResult Details(int id)
            {
                //var datos = new DADetalleComprobante();
                var model = DADetalleComprobante.GetIdDetalleComprobante(id);
                return View(model);
            }

            public IActionResult Delete(int id)
            {
                //var modelodelete = new DADetalleComprobante();
                var model = DADetalleComprobante.GetIdDetalleComprobante(id);
                var resultado = DADetalleComprobante.DeleteDetalleComprobante(id);
            
                return RedirectToAction("Index",new { id = model.IdComprobante  });
            }
        }
}
