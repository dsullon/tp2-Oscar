using System.Collections.Generic;
using TP2.Datos.EF;
using TP2.Entidades.EF;
using System.Linq;

namespace TP2.Negocio
{
    public class TGGInmueble
    {
        public static List<T_GG_INMUEBLE> ListarTodos(int area)
        {
            RicardoPalmaEntities db = new RicardoPalmaEntities();
            return db.T_GG_INMUEBLE.Where(x => x.idArea == area).ToList();
        }

        public static List<T_GG_INMUEBLE> ListarDisponibles(string fecha)
        {
            RicardoPalmaEntities db = new RicardoPalmaEntities();
            return db.T_GG_INMUEBLE.Where(x => x.idArea == 2).ToList();
        }
    }
}
