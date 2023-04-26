using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppVentaDSI.Data.DataAcces;
using WebAppVentaDSI.Data.Interface;
using WebAppVentaDSI.Models;
//paginacion
using X.PagedList;


namespace WebAppVentaDSI.Controllers
{
    [Authorize]
    public class ComprobanteController : Controller
    {
        private readonly IDAComprobante DAComprobante;
        private readonly IDACliente DACliente; 
        private readonly IDATipoComprobante DATipoComprobante;
        private readonly IDAEmpleado DAEmpleado;
        private readonly IDADetalleTipoPago DADetalleTipoPago;


        public ComprobanteController(IDAComprobante DAComprobante, IDACliente DACliente, IDATipoComprobante DATipoComprobante, IDAEmpleado DAEmpleado, IDADetalleTipoPago DADetalleTipoPago)
        {
            this.DAComprobante = DAComprobante;
            this.DACliente = DACliente;
            this.DATipoComprobante = DATipoComprobante;
            this.DAEmpleado = DAEmpleado;
            this.DADetalleTipoPago = DADetalleTipoPago;
        }

        public List<double> Total(IEnumerable<Comprobante> comprobante)
        {
            var resultado = new List<double>();
           // var comprobante = DAComprobante.GetComprobante();
            var detallepago = DADetalleTipoPago.GetDetalleTipoPago();
            double total = 0;

            for (int i =0; i<comprobante.Count();i++ )
            {
                for (int j=0; j<detallepago.Count();j++)
                {
                    if (comprobante.ElementAt(i).IdComprobante == detallepago.ElementAt(j).IdComprobante)
                    {
                        total += detallepago.ElementAt(j).PagoDetallePago;
                    }
                }
                resultado.Add(total);
                total = 0;
            }

            return resultado;
        }
        //PAGO DEL DETALLE COMPROBANTE
        public List<double> TotalDet(IEnumerable<Comprobante> comprobante)
        {
            var resultado = new List<double>();
            var detallepago = new DADetalleComprobante().GetDetalleComprobante();
            double total = 0;

            for (int i = 0; i < comprobante.Count(); i++)
            {
                for (int j = 0; j < detallepago.Count(); j++)
                {
                    if (comprobante.ElementAt(i).IdComprobante == detallepago.ElementAt(j).IdComprobante)
                    {
                        total += (detallepago.ElementAt(j).CantidadDetalleComprobante*detallepago.ElementAt(j).Producto.PrecioVentaProducto);
                    }
                }
                resultado.Add(total);
                total = 0;
            }

            return resultado;
        }
        

        public IActionResult Index(String filterByName, int page=1)
        {
            //pageNumnber:
            var pagenumber = page;

            //var model = new DAComprobante();
            var CO = DAComprobante.GetComprobante();
            ViewBag.ID = "Comprobante"; 
            ViewBag.NOM = "Nombres";
            ViewBag.APE = "Apellidos";
            ViewBag.FECH = "Fecha Compra";
            ViewBag.SEX = "Sexo";
            ViewBag.DNI = "DNI";
            ViewBag.TC = "Tipo Comprobante";
            ViewBag.OP = "Opciones";
            ViewBag.PAG = "Condicion";
            ViewBag.TT = "Total";



            if (filterByName != null)
            {
                var filtro = (from tbl in CO
                              where tbl.CodigoComprobante.ToLower().Contains(filterByName.ToLower())
                              select tbl).ToList();
                var model = filtro.OrderByDescending(x => x.IdComprobante).ToList().ToPagedList(pagenumber, 8);
                TempData["Total"] = Total(model);
                TempData["DetPag"] = TotalDet(model);
                
                //ViewBag.CO = model;
                return View(model);
            }
            else
            {
                var model = CO.OrderByDescending(x => x.IdComprobante).ToList().ToPagedList(pagenumber, 8);
                TempData["Total"] = Total(model);
                TempData["DetPag"]= TotalDet(model);
                
                //ViewBag.CO = model;
                return View(model);
            }

            return View();
        }
        public IActionResult Create()
        {
            //Listar empleado
            //var infoEmpleado = new DAEmpleado();
            var model = DAEmpleado.GetEmpleado();
            model = (from tbl in model
                     where tbl.CargoEmpleado.NombreCargoEmpleado.ToUpper().Contains("VENDEDOR")
                     select tbl).ToList();
            ViewBag.InfoEmpleado = model;

            //listar cliente
            //var infoCliente = new DACliente();
            ViewBag.InfoCliente = DACliente.GetCliente();

            //listar tipo comprobante
            //var infoTipo = new DATipoComprobante();
            ViewBag.InfoTipo = DATipoComprobante.GetTipoComprobante();


            return View();
        }

        [HttpPost]
        public IActionResult Create(Comprobante Entidad)
        {
            Entidad.FechaEmisionComprobante = DateTime.Now;
            Entidad.IdComprobante = 0;
            //var model = new DAComprobante();
            var resultado = DAComprobante.InsertComprobante(Entidad);
            if (resultado > 0)
            {
                return RedirectToAction("Create","DetalleComprobante");
            }
            else
            {
                return View(resultado);
            }
        }



        
        public IActionResult Edit(int id)
        {
            //var EmpleadoEdit = new DAEmpleado();
            ViewBag.EmpleadoEdit = DAEmpleado.GetEmpleado();

            //var ClienteEdit = new DACliente();
            ViewBag.ClienteEdit = DACliente.GetCliente();

            //var TipoEdit = new DATipoComprobante();
            ViewBag.TipoEdit = DATipoComprobante.GetTipoComprobante();


            //var model = new DAComprobante();
            var resultado = DAComprobante.GetIdComprobante(id);
            return View(resultado);
        }

        [HttpPost]
        public IActionResult Edit(Comprobante comprobante)
        {

            //var model = new DAComprobante();
            var resultao = DAComprobante.UpdatComprobante(comprobante);
            if (resultao)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(comprobante);
            }
        }

       //TIPO DE PAGO
       public string Tpago(int id)
        {
            
            double efectivo = 0;
            double yape = 0;
            double plim = 0;
            double transferencia = 0;
            var DetPago = DADetalleTipoPago.GetDetalleTipoPago();
            foreach (var item in DetPago)
            {
                if (item.IdComprobante==id)
                {
                    switch (item.TipoPago.IdTipoPago)
                    {
                        case 1:
                            efectivo += item.PagoDetallePago;
                            break;
                        case 2:
                            yape += item.PagoDetallePago;
                            break;
                        case 3:
                            plim += item.PagoDetallePago;
                            break;
                        case 4:
                            transferencia += item.PagoDetallePago;
                            break;
                        default:
                            break;
                    }
                    
                }
            }
            string resultado = "Efectivo:  S/" + efectivo + "  Yape:  S/" + yape + "  Plim  S/" + plim + "  T. Bancaria  S/" + transferencia;

            return resultado;
        }



        //Details Referencia DETAILS/COMPROBANTE
        public IActionResult Details(int id)
        {
            //var datos = new DAComprobante();
            var model = DAComprobante.GetIdComprobante(id);
            ViewBag.TipoPag= Tpago(id);

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            //var modelodelete = new DAComprobante();
            var resultado = DAComprobante.DeleteComprobante(id);
            return RedirectToAction("Index");
        }
    }
}
