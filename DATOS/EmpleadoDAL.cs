using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
    public class EmpleadoDAL
    {
        public void Agregar(Empleado empleado)
        {
            using (var db = new ProyectosContext())
            {
                db.Empleado.Add(empleado);
                db.SaveChanges();
            }
        }

        public List<Empleado> ListarEmpleados()
        {
            using (var db = new ProyectosContext())
            {
                return db.Empleado.ToList();
            }
        }

        public Empleado Detalles(int Id)
        {
            using (var db = new ProyectosContext())
            {
                //return db.Proyecto.Find(Id);
                return db.Empleado.Where(a => a.EmpleadoId == Id).FirstOrDefault();
            }
        }

        public void Editar(Empleado empleado)
        {
            using (var db = new ProyectosContext())
            {
                var origen = db.Empleado.Where(a => a.EmpleadoId == empleado.EmpleadoId).FirstOrDefault();
                origen.Nombres = empleado.Nombres;
                origen.Apellidos = empleado.Apellidos;
                origen.Email = empleado.Email;
                origen.Direccion = empleado.Direccion;
                origen.Celular = empleado.Celular;

                db.SaveChanges();

            }
        }

        public void Borrar(int Id)
        {
            using (var db = new ProyectosContext())
            {
                var origen = db.Proyecto.Where(a => a.ProyectoId == Id).FirstOrDefault();

                db.Proyecto.Remove(origen);

                db.SaveChanges();


            }
        }
    }
}
