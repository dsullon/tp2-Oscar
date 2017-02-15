using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP2.Negocio;

namespace TP2.Web.Controllers
{
    public class ReservaController : Controller
    {
        // GET: Reserva
        public ActionResult Index()
        {
            var tipoOperacionList = TGUQTipoOperacion.ListarTodos();
            ViewBag.TipoOperacionList = tipoOperacionList;

            var salaList = TGGInmueble.ListarTodos(2);
            ViewBag.SalaList = salaList;

            var pacienteList = TGDAPaciente.ListarTodos();
            ViewBag.PacienteList = pacienteList;

            return View(); 
        }

        public ActionResult MedicoPartial(int tipo, string fecha)
        {
            var empleadoList = TGGEmpleado.ListarDisponibles(tipo);
            return PartialView("_ReservaMedico", empleadoList);
        }

        public ActionResult HorarioPartial(string fecha)
        {
            var salaList = TGUQReservaSalaOperacion.ListarDisponibles(fecha);
            return PartialView("_ReservaSala", salaList);
        }
    }
}