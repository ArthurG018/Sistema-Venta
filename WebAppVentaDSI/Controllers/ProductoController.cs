using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppVentaDSI.Data.DataAcces;
using WebAppVentaDSI.Data.Interface;
using WebAppVentaDSI.Models;
using X.PagedList;

namespace WebAppVentaDSI.Controllers
{
    [Authorize]
    public class ProductoController : Controller
    {
        private readonly IDAProducto DAProducto;
        private readonly IDAMarcaProducto DAMarcaProducto;
        private readonly IDAFamiliaProducto DAFamiliaProducto;

        public ProductoController(IDAProducto DAProducto, IDAMarcaProducto DAMarcaProducto, IDAFamiliaProducto DAFamiliaProducto)
        {
            this.DAProducto = DAProducto;
            this.DAMarcaProducto = DAMarcaProducto;
            this.DAFamiliaProducto = DAFamiliaProducto;
        }

        public IActionResult Index(string filterByName, int page = 1)
        {
            var Producto = DAProducto.GetProducto();
            var pagenumber = page;
            if (filterByName != null)
            {
                var filtro = (from tbl in Producto
                              where tbl.NombreProducto.ToLower().Contains(filterByName.ToLower())
                              select tbl).ToList();
                var model = filtro.ToPagedList(pagenumber, 16);
                return View(model);
            }
            else
            {
                var model = Producto.ToPagedList(pagenumber, 8);
                return View(model);
            }
        }
        public IActionResult Create()
        {
            ViewBag.infoMarca = DAMarcaProducto.GetMarcaProducto();
            ViewBag.infofamilia = DAFamiliaProducto.GetFamiliaProducto();

            return View();
        }
        [HttpPost]
        public IActionResult Create(Producto Entidad)
        {
            //Entidad.FechaEmisionComprobante = DateTime.Now;
            Entidad.IdProducto = 0;
            //var model = new DAComprobante();
            var resultado = DAProducto.InsertarProducto(Entidad);
            if (resultado > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(resultado);
            }
        }

        public IActionResult Edit(int id)
        {

            var resultado = DAProducto.GetIdProducto(id);
            ViewBag.infoMarca = DAMarcaProducto.GetMarcaProducto();
            ViewBag.infofamilia = DAFamiliaProducto.GetFamiliaProducto();

            return View(resultado);
        }

        [HttpPost]
        public IActionResult Edit(Producto producto)
        {

            var resultao = DAProducto.UpdateProducto(producto);
            if (resultao)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(producto);
            }
        }

        public IActionResult Details(int id)
        {
            // var datos = new DACliente();
            var model = DAProducto.GetIdProducto(id);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            //var modelodelete = new DACliente();
            var resultado = DAProducto.DeleteProducto(id);
            return RedirectToAction("Index");
        }
    }
}