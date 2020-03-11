using DATOS;
using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
    public class EmpleadoBLL
    {
        private static EmpleadoDAL obj = new EmpleadoDAL();
        public static void Agregar(Empleado proy)
        {
            obj.Agregar(proy);
        }
        public static List<Empleado> ListarEmpleados()
        {
            return obj.ListarEmpleados();
        }

        public static Empleado Detalles(int Id)
        {
            return obj.Detalles(Id);
        }

        public static void Editar(Empleado proy)
        {
            obj.Editar(proy);
        }
        public static void Borrar(int Id)
        {
            obj.Borrar(Id);
        }
    }
}
