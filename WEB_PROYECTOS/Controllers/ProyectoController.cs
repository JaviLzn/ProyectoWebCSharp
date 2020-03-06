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

                System.Threading.Thread.Sleep(2000);

                ProyectoBLL.Agregar(proy);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("", "Ocurrió un error al crear el proyecto. " + ex.Message);
                //return View(proy);
                return Json(new { ok = false, msg = "Ocurrió un error al crear el proyecto. " + ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult DetalleProy(int id)
        {
            var proy = ProyectoBLL.DetalleProy(id);
            return View(proy);

        }

        public ActionResult Modificar(int id)
        {
            var proy = ProyectoBLL.DetalleProy(id);
            return View(proy);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar(Proyecto proy)
        {
            try
            {
                ProyectoBLL.Editar(proy);

                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = "Ocurrió un error al modificar el proyecto. " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            try
            {
                ProyectoBLL.Borrar(id);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { ok = false, msg = "Ocurrió un error al borrar el proyecto. " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}