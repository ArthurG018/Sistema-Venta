using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppVentaDSI.Data.DataAcces;
using WebAppVentaDSI.Data.Interface;
using WebAppVentaDSI.Models;
using X.PagedList;

namespace WebAppVentaDSI.Controllers
{
    [Authorize]
    public class EmpleadoController : Controller
    {
        private readonly IDAEmpleado DAEmpleado;
        private readonly IDACargoEmpleado DACargoEmpleado;
        private readonly IDADetalleEmpleado DADetalleEmpleado;

        public EmpleadoController(IDAEmpleado DAEmpleado, IDACargoEmpleado DACargoEmpleado, IDADetalleEmpleado DADetalleEmpleado)
        {
            this.DAEmpleado = DAEmpleado;
            this.DACargoEmpleado = DACargoEmpleado;
            this.DADetalleEmpleado = DADetalleEmpleado;
        }
        public List<string> GetEstado(IEnumerable<Empleado> empleado)
        {
            var estado = new List<string>();
            var detalle = DADetalleEmpleado.GetDetalleEmpleado();
           // var empleado = DAEmpleado.GetEmpleado();
            for (int i = 0; i<empleado.Count();i++)
            {

                var sql = (from tbl in detalle
                           where tbl.Empleado.IdEmpleado == empleado.ElementAt(i).IdEmpleado
                           orderby tbl.IdDetalleEmpleado descending
                           select tbl.Estado.NombreEstado).ToList();
                estado.Add(sql.ElementAt(0));
            }
            
            return estado;
        }
        public IActionResult Index(string filterByName, int page=1)
        {
            var pagenumber = page;
            //var model = new DAEmpleado();
            var EM = DAEmpleado.GetEmpleado();
            if (filterByName != null)
            {
                var filtro = (from tbl in EM
                              where tbl.NombreEmpleado.ToLower().Contains(filterByName.ToLower())
                              select tbl).ToList();
                var model = filtro.ToPagedList(pagenumber, 16);
                ViewData["ESTADO"] = GetEstado(filtro);
                ViewData["EM"] = model;
            }
            else
            {
                var model = EM.ToPagedList(pagenumber, 8);
                ViewData["ESTADO"]=GetEstado(model);
                ViewData["EM"] = model;
            }

            return View();
        }
        public IActionResult Create()
        {
            //Listar categoria
            //var infoCargo = new DACargoEmpleado();
            ViewBag.InfoCargo = DACargoEmpleado.GetCargoEmpleado();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Empleado Entidad)
        {
            Entidad.IdEmpleado = 0;
           // var model = new DAEmpleado();
            var resultado = DAEmpleado.InsertEmpleado(Entidad);
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
           // var CargoEdit = new DACargoEmpleado();
            ViewBag.CargoEdit = DACargoEmpleado.GetCargoEmpleado();

            //var model = new DAEmpleado();
            var resultado = DAEmpleado.GetIdEmpleado(id);
            return View(resultado);
        }

        [HttpPost]
        public IActionResult Edit(Empleado empleado)
        {

           // var model = new DAEmpleado();
            var resultao = DAEmpleado.UpdateEmpleado(empleado);
            if (resultao)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(empleado);
            }
        }

        public IActionResult Details(int id)
        {
            //var datos = new DAEmpleado();
            var model = DAEmpleado.GetIdEmpleado(id);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
           // var modelodelete = new DAEmpleado();
            //var resultado = DAEmpleado.DeleteEmpleado(id);
            var tabladet = DADetalleEmpleado.GetDetalleEmpleado();

            var estado = (from tbl in tabladet where tbl.IdEmpleado==id orderby tbl.IdDetalleEmpleado descending select tbl.IdEstado).ToList();
            var estadoEmp = estado.ElementAt(0);
            if (estadoEmp == 1)
            {
                var detalle = new DetalleEmpleado();
                detalle.FechaDetalleEmpleado = DateTime.Now;
                detalle.IdEstado = 2;
                detalle.IdEmpleado = id;

                var resultado = DADetalleEmpleado.InsertDetalleEmpleado(detalle);
                if (resultado > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(resultado);
                }

            }
            else if (estadoEmp == 2)
            {
                var detalle = new DetalleEmpleado();
                detalle.FechaDetalleEmpleado = DateTime.Now;
                detalle.IdEstado = 1;
                detalle.IdEmpleado = id;

                var resultado = DADetalleEmpleado.InsertDetalleEmpleado(detalle);
                if (resultado > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(resultado);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
