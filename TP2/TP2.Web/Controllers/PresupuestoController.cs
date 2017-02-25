using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP2.Entidades.EF;
using TP2.Negocio;

namespace TP2.Web.Controllers
{

    public class PresupuestoController : Controller
    {
           // public static  List<T_GUQ_PARTIDA> listaPartidas = new List<T_GUQ_PARTIDA>();
        public static List<Partida> listaPartidas = new List<Partida>();
            public  struct Partida
            {
                public int idPartida;
                public double monto;
                public string descripcion;
            } 

        //
        // GET: /Presupuesto/
        public ActionResult Index()
        {
            var listado = TGUQPresupuesto.ListarTodos();
            return View(listado);
        }

        public ActionResult Create()
        {
            var partidaList = TGUQPartida.ListarTodos();
            ViewBag.PartidaList = partidaList;

            var areaList = TGUQArea.ListarTodos();
            ViewBag.AreaList = areaList;

            return View();
        }

        [HttpPost]
        public string Create(T_GUQ_PRESUPUESTO presupuesto)
        {
            string mensaje = "Error al grabar los datos";
            List<T_GUQ_PARTIDA> lisPartidas = new List<T_GUQ_PARTIDA>();
            T_GUQ_PARTIDA oPartida ; 
            double montoTotal = 0;
            for (int i = 0; i < listaPartidas.Count(); i++)
            {
                montoTotal = montoTotal + listaPartidas[i].monto;
                oPartida = new T_GUQ_PARTIDA();
                oPartida.idPartida = listaPartidas[i].idPartida;
                oPartida.dscPartida = listaPartidas[i].descripcion;
                lisPartidas.Add(oPartida);
            }


            bool exito = TGUQPresupuesto.Crear(presupuesto, lisPartidas, montoTotal);
            if (exito)
                mensaje = "Los datos se grabaron con exito";
            return mensaje;
        }

        public ActionResult Edit(int id)
        {

            var presupuesto = TGUQPresupuesto.Obtener(id);
            var partidaList = TGUQPartida.ListarTodos();
            var idPartida =  presupuesto.T_GUQ_PARTIDA.ToList()[0].idPartida;
            ViewBag.PartidaList = new SelectList(partidaList, "idPartida", "dscPartida", idPartida);

            var areaList = TGUQArea.ListarTodos();
            ViewBag.AreaList = areaList;

            return View(presupuesto);
        }


        [HttpPost]
        public string Edit(T_GUQ_PRESUPUESTO presupuesto, int partida)
        {
            string mensaje = "Error al grabar los datos";
            bool exito = TGUQPresupuesto.Editar(presupuesto, partida);
            if (exito)
                mensaje = "Los datos se actualizaron con exito";
            return mensaje;
        }


        [HttpPost]
        public ActionResult AgregarPartida(T_GUQ_PRESUPUESTO presupuesto, int partida)
        {
            double monto = TGUQEstadisticaRecursos.ObtenerPromedio(presupuesto.anio, partida, presupuesto.idArea);
            var Partida = TGUQPartida.Obtener(partida);
            Partida oPartida = new Partida();
            oPartida.monto = monto;
            oPartida.idPartida = partida;
            oPartida.descripcion = Partida.dscPartida;
            listaPartidas.Add(oPartida);
            return Json(listaPartidas, JsonRequestBehavior.AllowGet);  
        }

        
        public ActionResult EditarPartida(int idPartida)
        {
            for (int i = 0; i < listaPartidas.Count(); i++)
            {
                if (listaPartidas[i].idPartida == idPartida)
                {
                    return Json(listaPartidas[i], JsonRequestBehavior.AllowGet);
                }
            }

            return Json("", JsonRequestBehavior.AllowGet);
           
        }

        [HttpPost]
        public ActionResult EditarPartida(int idPartida, double monto)
        {
            for (int i = 0; i < listaPartidas.Count(); i++)
            {
                if (listaPartidas[i].idPartida == idPartida)
                {
                    var Partida = TGUQPartida.Obtener(idPartida);
                    Partida oPartida = new Partida();
                    oPartida.monto = monto;
                    oPartida.idPartida = idPartida;
                    oPartida.descripcion = Partida.dscPartida;
                    listaPartidas[i]= oPartida;
                }
            }
         

            return Json(listaPartidas, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult EliminarPartida(int idPartida)
        {
            listaPartidas.RemoveAll(x => x.idPartida == idPartida);
            return Json(listaPartidas, JsonRequestBehavior.AllowGet);

        }
	}


}