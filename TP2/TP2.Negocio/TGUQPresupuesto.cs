using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Datos.EF;
using TP2.Entidades.EF;

namespace TP2.Negocio
{
    public class TGUQPresupuesto
    {
        public static List<T_GUQ_PRESUPUESTO> ListarTodos()
        {
            RicardoPalmaEntities db = new RicardoPalmaEntities();
            return db.T_GUQ_PRESUPUESTO.ToList();
        }

        public static bool Crear(T_GUQ_PRESUPUESTO presupuesto, int idPartida)
        {
            bool exito = false;

            try
            {
                RicardoPalmaEntities db = new RicardoPalmaEntities();
                double monto = TGUQEstadisticaRecursos.ObtenerPromedio(presupuesto.anio, idPartida, presupuesto.idArea);
                var partida = new T_GUQ_PARTIDA();
                partida.idPartida = idPartida;
                presupuesto.monto = monto;
                presupuesto.estado = "Generado";
                presupuesto.T_GUQ_PARTIDA.Add(partida);
                db.Entry(presupuesto).State = EntityState.Added;
              //  db.T_GUQ_PRESUPUESTO.Add(presupuesto);
                db.Entry(partida).State = EntityState.Unchanged;
                db.SaveChanges();
                exito = true;
            }
           
            catch (DbEntityValidationException dbEx)
            {
                exito = false;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return exito;
        }

        public static bool Editar(T_GUQ_PRESUPUESTO presupuesto, int idPartida)
        {
            bool exito = false;

            try
            {
                RicardoPalmaEntities db = new RicardoPalmaEntities();
                double monto = TGUQEstadisticaRecursos.ObtenerPromedio(presupuesto.anio, idPartida, presupuesto.idArea);
                var partida = new T_GUQ_PARTIDA();
                partida.idPartida = idPartida;

                db.Database.ExecuteSqlCommand(
                     "update  T_GUQ_PRESUPUESTO_PARTIDA set idPartida = @idPar where idPresupuesto = @idPer",
                     new SqlParameter[]
                     {
                         new SqlParameter ("idPar", idPartida),
                         new SqlParameter ("idPer", presupuesto.idPresupuesto)
                     }
                    
                 );

                presupuesto.monto = monto;
                presupuesto.estado = "Generado";
               
                db.Entry(presupuesto).State = EntityState.Modified;
               
                db.SaveChanges();
               
                exito = true;
            }
            catch (Exception ex)
            {
                exito = false;
            }
            return exito;
        }

        public static T_GUQ_PRESUPUESTO Obtener(int id)
        {
            RicardoPalmaEntities db = new RicardoPalmaEntities();
            var presupuesto = db.T_GUQ_PRESUPUESTO.Find(id);
            return presupuesto;
        }
    }
}
