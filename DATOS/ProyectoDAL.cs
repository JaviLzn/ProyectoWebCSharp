using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
    public class ProyectoDAL
    {
        public void Agregar(Proyecto proy)
        {
            using (var db = new ProyectosContext())
            {
                db.Proyecto.Add(proy);
                db.SaveChanges();
            }
        }
        public List<Proyecto> ListarProyectos()
        {
            using (var db = new ProyectosContext())
            {
                return db.Proyecto.ToList();
            }
        }

        public Proyecto DetalleProy(int Id)
        {
            using (var db = new ProyectosContext())
            {
                //return db.Proyecto.Find(Id);
                return db.Proyecto.Where(a => a.ProyectoId == Id).FirstOrDefault();
            }
        }

        public void Editar(Proyecto proy)
        {
            using (var db = new ProyectosContext())
            {
                var origen = db.Proyecto.Where(a => a.ProyectoId == proy.ProyectoId).FirstOrDefault();
                origen.NombreProyecto = proy.NombreProyecto;
                origen.FechaInicio = proy.FechaInicio;
                origen.FechaFin = proy.FechaFin;

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
