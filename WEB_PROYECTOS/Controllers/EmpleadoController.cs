using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ENTIDAD;
using NEGOCIO;

namespace WEB_PROYECTOS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmpleadoController : Controller
    {
        // GET: Proyecto
        public ActionResult Index()
        {
            var empleados = EmpleadoBLL.ListarEmpleados();
            return View(empleados);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Empleado empleado)
        {
            try
            {
                if (empleado.Nombres == null)
                    return Json(new { ok = false, msg = "Debe ingresar los nombres del Empleado" }, JsonRequestBehavior.AllowGet);
                if (empleado.Apellidos == null)
                    return Json(new { ok = false, msg = "Debe ingresar los apellidos del Empleado" }, JsonRequestBehavior.AllowGet);
                if (empleado.Email == null)
                    return Json(new { ok = false, msg = "Debe ingresar el email del Empleado" }, JsonRequestBehavior.AllowGet);
                if (empleado.Direccion == null)
                    return Json(new { ok = false, msg = "Debe ingresar la dirección del Empleado" }, JsonRequestBehavior.AllowGet);

                System.Threading.Thread.Sleep(2000);

                EmpleadoBLL.Agregar(empleado);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("", "Ocurrió un error al crear el proyecto. " + ex.Message);
                //return View(proy);
                return Json(new { ok = false, msg = "Ocurrió un error al crear el empleado. " + ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult Detallar(int id)
        {
            var proy = EmpleadoBLL.Detalles(id);
            return View(proy);

        }

        public ActionResult Modificar(int id)
        {
            var proy = EmpleadoBLL.Detalles(id);
            return View(proy);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar(Empleado empleado)
        {
            try
            {
                EmpleadoBLL.Editar(empleado);

                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = "Ocurrió un error al modificar el empleado. " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            try
            {
                EmpleadoBLL.Borrar(id);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { ok = false, msg = "Ocurrió un error al borrar el empleado. " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}