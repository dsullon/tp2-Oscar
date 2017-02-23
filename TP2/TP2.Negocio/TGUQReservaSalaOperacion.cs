using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using TP2.Datos.EF;
using TP2.Entidades.EF;

namespace TP2.Negocio
{
    public class TGUQReservaSalaOperacion
    {
        protected static readonly ILog log = LogManager.GetLogger("Reservas");

        public static List<T_GUQ_RESERVA_SALA_OPERACIÓN> ListarTodos()
        {
            RicardoPalmaEntities db = new RicardoPalmaEntities();
            return db.T_GUQ_RESERVA_SALA_OPERACIÓN.ToList();
        }

        public static List<string> ListarHorarios(string fecha, int inmueble)
        {
            List<String> horario = new List<string>();
            TimeSpan result;
            string timeString;
            DateTime nuevaFecha = Convert.ToDateTime(fecha);
            if (nuevaFecha.CompareTo(new DateTime(1900, 1, 1)) == 0)
                return horario;

            try
            {
                RicardoPalmaEntities db = new RicardoPalmaEntities();
                T_GUQ_RESERVA_SALA_OPERACIÓN reserva = null;
                var reservas = db.T_GUQ_RESERVA_SALA_OPERACIÓN.Where(x => x.fecha.CompareTo(nuevaFecha) == 0 &&
                 x.idInmueble == inmueble).ToList();
                for (int i = 0; i < 24; i++)
                {
                    reserva = reservas.Where(x => x.horaInicio.Hours == i).FirstOrDefault();

                    if (reserva != null)
                        i += (reserva.duración - 1);
                    else
                    {
                        result = TimeSpan.FromHours(i);
                        timeString = result.ToString("hh':'mm");
                        horario.Add(timeString);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error al consultar los horarios", ex);
            }
            
            return horario;
        }

        public static List<T_GG_EMPLEADO> ListarMedicos(int tipoOperacion, DateTime fecha, int hora)
        {
            List<T_GG_EMPLEADO> lista = new List<T_GG_EMPLEADO>();
            DateTime nuevaFecha = Convert.ToDateTime(fecha);
            if (nuevaFecha.CompareTo(new DateTime(1900, 1, 1)) == 0)
                return lista;
            try
            {
                RicardoPalmaEntities db = new RicardoPalmaEntities();
                var tipo = db.T_GUQ_TIPO_OPERACIÓN.Find(tipoOperacion);
                var listaEspecialidad = db.T_GDA_ESPECIALIDAD__MEDICA.Where(x => x.idOperacion == tipoOperacion).ToList();
                var listaEmpleados = db.T_GG_EMPLEADO.ToList();
                listaEmpleados = listaEmpleados.Where(x => listaEspecialidad.Any(y => y.idEspecialidad == x.idEspecialidad)).ToList();

                var reservas = db.T_GUQ_RESERVA_SALA_OPERACIÓN.Where(x => x.fecha.CompareTo(fecha) == 0 && (x.horaInicio.Hours <= hora && (x.horaInicio.Hours + x.duración) > hora)).ToList();

                lista = listaEmpleados.Where(x => !reservas.Any(y => y.idEmpleado == x.idEmpleado)).ToList();
            }
            catch (Exception ex)
            {
                log.Error("Error al consultar los médicos", ex);
            }
            
            return lista;
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
                log.Error("Error al crear la reserva", ex);
            }
            return exito;
        }
    }
}
