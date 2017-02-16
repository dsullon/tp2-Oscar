using System.Web.Mvc;
using TP2.Entidades.EF;
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

        [HttpPost]
        public string Create(T_GUQ_RESERVA_SALA_OPERACIÓN reserva)
        {
            string mensaje = "Error al grabar los datos";
            bool exito = TGUQReservaSalaOperacion.Crear(reserva);
            if(exito)
                mensaje = "Los datos se grabaron con exito";
            return mensaje;
        }
    }
}