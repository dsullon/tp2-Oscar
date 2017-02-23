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
        public string Create(T_GUQ_PRESUPUESTO presupuesto, int partida)
        {
            string mensaje = "Error al grabar los datos";
            bool exito = TGUQPresupuesto.Crear(presupuesto, partida);
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
	}


}