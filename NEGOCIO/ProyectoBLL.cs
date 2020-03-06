using DATOS;
using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
    public class ProyectoBLL
    {
        private static ProyectoDAL obj = new ProyectoDAL();
        public static void Agregar(Proyecto proy)
        {
            obj.Agregar(proy);
        }
        public static List<Proyecto> ListarProyectos()
        {
            return obj.ListarProyectos();
        }

        public static Proyecto DetalleProy(int Id)
        {
            return obj.DetalleProy(Id);
        }

        public static void Editar(Proyecto proy)
        {
            obj.Editar(proy);
        }
        public static void Borrar(int Id)
        {
            obj.Borrar(Id);
        }
    }
}
