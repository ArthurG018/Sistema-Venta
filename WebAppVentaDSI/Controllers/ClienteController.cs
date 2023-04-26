using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppVentaDSI.Data.DataAcces;
using WebAppVentaDSI.Data.Interface;
using WebAppVentaDSI.Models;
using X.PagedList;

namespace WebAppVentaDSI.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly IDACliente DACliente;

        public ClienteController(IDACliente DACliente)
        {
            this.DACliente = DACliente;
        }

        public IActionResult Index(string filterByName, int page=1)
        {
            //pageNumnber:
            var pagenumber = page;

            //var model = new DACliente();
            var CL = DACliente.GetCliente();
            TempData["ID"] = "ID";
            TempData["NOM"] = "Nombre";
            TempData["APE"] = "Apellidos";
            TempData["DNI"] = "DNI";
            TempData["FECH"] = "Fecha de Nacimeinto";
            TempData["SEX"] = "Sexo";
            TempData["CEL"] = "Celular";
            TempData["DIRE"] = "Direccion";
            TempData["OPC"] = "Opciones";
            if (filterByName != null)
            {
                var filtro = (from tbl in CL
                              where tbl.NombreCliente.ToLower().Contains(filterByName.ToLower())
                              select tbl).ToList();
                var model = filtro.ToPagedList(pagenumber, 16);
                //TempData["CLIENTE"] = model;
                return View(model);
            }
            else
            {
                var model = CL.ToPagedList(pagenumber, 8);
                //TempData["CLIENTE"] = model;
                return View(model);
            }
        }

        public IActionResult Create()
        {

            //listar cliente
            //var infoCliente = new DACliente();
            ViewBag.InfoCliente = DACliente.GetCliente();


            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente Entidad)
        {
            Entidad.IdCliente = 0;
            //var model = new DACliente();
            var resultado = DACliente.InsertCliente(Entidad);
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

            //var ClienteEdit = new DACliente();
            var resultado = DACliente.GetIdCliente(id);

            return View(resultado);
        }

        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {

            //var model = new DACliente();
            var resultao = DACliente.UpdatCliente(cliente);
            if (resultao)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(cliente);
            }
        }

        public IActionResult Details(int id)
        {
           // var datos = new DACliente();
            var model = DACliente.GetIdCliente(id);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            //var modelodelete = new DACliente();
            var resultado = DACliente.DeleteCliente(id);
            return RedirectToAction("Index");
        }
    }
}
