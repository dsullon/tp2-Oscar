using System.Collections.Generic;
using TP2.Datos.EF;
using System.Linq;
using System;
using TP2.Entidades.EF;

namespace TP2.Negocio
{
    public class TGUQReservaSalaOperacion
    {
        public static List<T_GUQ_RESERVA_SALA_OPERACIÓN> ListarTodos()
        {
            RicardoPalmaEntities db = new RicardoPalmaEntities();
            return db.T_GUQ_RESERVA_SALA_OPERACIÓN.ToList();
        }

        public static List<string> ListarDisponibles(string fecha, int tipo, int inmueble)
        {
            List<String> horario = new List<string>();
            TimeSpan result;
            string timeString;
            DateTime nuevaFecha = Convert.ToDateTime(fecha);
            RicardoPalmaEntities db = new RicardoPalmaEntities();
            T_GUQ_RESERVA_SALA_OPERACIÓN reserva = null;
            var reservas = db.T_GUQ_RESERVA_SALA_OPERACIÓN.Where(x => x.fecha.CompareTo(nuevaFecha) == 0 &&
             x.idInmueble == inmueble && x.T_GG_INMUEBLE.T_GUQ_TIPO_OPERACIÓN.Where(y=> y.idOperación == tipo).Any()).ToList();
            for (int i = 0; i < 24; i++)
            {
                reserva = reservas.Where(x=> x.horaInicio.Hours==i).FirstOrDefault();
                if (reserva == null)
                {
                    result = TimeSpan.FromHours(i);
                    timeString = result.ToString("hh':'mm");
                    horario.Add(timeString);
                }
            }
            return horario;
        }

        public static bool Crear(T_GUQ_RESERVA_SALA_OPERACIÓN reserva)
        {
            bool exito = false;
            try
            {
                RicardoPalmaEntities db = new RicardoPalmaEntities();
                db.T_GUQ_RESERVA_SALA_OPERACIÓN.Add(reserva);
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
