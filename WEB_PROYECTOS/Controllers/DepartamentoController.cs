using ENTIDAD;
using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WEB_PROYECTOS.Controllers
{
    public class DepartamentoController : Controller
    {
        // GET: Departamento
        public ActionResult Index()
        {
            var dptos = DepartamentoBLL.ListarDepartamentos();
            return View(dptos);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Departamento dpto)
        {
            try
            {
                if (dpto.NombreDepartamento == null)
                {
                    ModelState.AddModelError("", "Debe ingresar un nombre de departamento.");
                    return View(dpto);
                }
                DepartamentoBLL.Agregar(dpto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al crear el departamento" + " " + ex.Message);
                return View(dpto);
            }

        }


        public ActionResult GetDepartamento (int id)
        {
            var dpto = DepartamentoBLL.GetDepartamento(id);
            return View(dpto);
        }


        public ActionResult Editar(int id)
        {
            var dpto = DepartamentoBLL.GetDepartamento(id);
            return View(dpto);
        }

        [HttpPost]
        public ActionResult Editar(Departamento dpto)
        {
           
            try
            {
                if (dpto.NombreDepartamento == null)
                {
                    ModelState.AddModelError("", "Debe ingresar un nombre de departamento.");
                    return View(dpto);
                }

                DepartamentoBLL.Editar(dpto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al modificar el departamento" + " " + ex.Message);
                return View(dpto);
            }
        }

        public ActionResult Eliminar(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var dpto = DepartamentoBLL.GetDepartamento(id.Value);
            return View(dpto);
        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            try
            {
                DepartamentoBLL.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Ocurrió un error al eliminar el departamento" + " " + ex.Message);
                return View();
            }
        }

    }
}