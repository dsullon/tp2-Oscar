using System.Collections.Generic;
using TP2.Datos.EF;
using TP2.Entidades.EF;
using System.Linq;

namespace TP2.Negocio
{
    public class TGUQTipoOperacion
    {
        public static List<T_GUQ_TIPO_OPERACIÓN> GetAll()
        {
            RicardoPalmaEntities db = new RicardoPalmaEntities();
            return db.T_GUQ_TIPO_OPERACIÓN.ToList();
        }
    }
}
