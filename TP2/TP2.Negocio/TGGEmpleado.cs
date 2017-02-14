using System.Collections.Generic;
using TP2.Datos.EF;
using TP2.Entidades.EF;
using System.Linq;

namespace TP2.Negocio
{
    public class TGGEmpleado
    {
        public static List<T_GG_EMPLEADO> ListarTodos()
        {
            RicardoPalmaEntities db = new RicardoPalmaEntities();
            return db.T_GG_EMPLEADO.ToList();
        }

        public static List<T_GG_EMPLEADO> ListarDisponibles(int tipoOperacion)
        {
            RicardoPalmaEntities db = new RicardoPalmaEntities();
            return db.T_GG_EMPLEADO.ToList();
        }
    }
}
