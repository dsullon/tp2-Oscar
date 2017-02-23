using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Datos.EF;
using TP2.Entidades.EF;

namespace TP2.Negocio
{
    public class TGUQPartidaPresupuesto
    {
        public static bool Crear(T_GUQ_PRESUPUESTO presupuesto, int idPartida)
        {
            bool exito = false;
            try
            {
                RicardoPalmaEntities db = new RicardoPalmaEntities();
                double monto = TGUQEstadisticaRecursos.ObtenerPromedio(presupuesto.anio, idPartida, presupuesto.idArea);
                presupuesto.monto = monto;
                presupuesto.estado = "Generado";
                db.T_GUQ_PRESUPUESTO.Add(presupuesto);
                db.SaveChanges();
                exito = true;
            }
            catch (Exception ex)
            {
                exito = false;
            }
            return exito;
        }
    }
}
