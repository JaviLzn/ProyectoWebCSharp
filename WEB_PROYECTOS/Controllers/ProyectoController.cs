using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ENTIDAD;
using NEGOCIO;

namespace WEB_PROYECTOS.Controllers
{
    public class ProyectoController : Controller
    {
        // GET: Proyecto
        public ActionResult Index()
        {
            var proyectos = ProyectoBLL.ListarProyectos();
            return View(proyectos);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Proyecto proy)
        {
            try
            {
                if (proy.NombreProyecto == null)
                  return Json(new { ok = false, msg = "Debe ingresar el nombre del proyecto" }, JsonRequestBehavior.AllowGet);
                

                ProyectoBLL.Agregar(proy);
                return Json(new { ok = true, toRedirect = "Index" }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("", "Ocurrió un error al crear el proyecto. " + ex.Message);
                //return View(proy);
                return Json(new { ok = false, msg = "Ocurrió un error al crear el proyecto. " + ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}