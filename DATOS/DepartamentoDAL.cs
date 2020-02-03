using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
    public class DepartamentoDAL
    {
        public void Agregar(Departamento dpto)
        {
            using (var db = new ProyectosContext())
            {
                db.Departamento.Add(dpto);
                db.SaveChanges();
            }
        }

        public List<Departamento> ListarDepartamentos()
        {
            using (var db = new ProyectosContext())
            {
                return db.Departamento.ToList();
            }
        }



    }
}
