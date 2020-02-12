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

    }
}
