using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
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
            listaPartidas.Clear();
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

            if (DateTime.Now.Year != presupuesto.anio)
            {
                mensaje = "Error : No puede grabar presupuesto en ese año: " + presupuesto.anio;
                return mensaje;
            }

            if (listaPartidas.Count() == 0)
            {
                mensaje = "Error : No puede grabar presupuesto sin partida";
                return mensaje;
            }

          
            foreach (var item in TGUQPresupuesto.ListarTodos())
            {
                if(item.anio == presupuesto.anio && item.idArea == presupuesto.idArea){
                    mensaje = "Error : Ya existe presupuesto para este año y esa área";
                    return mensaje;
                }
            }

            
            List<T_GUQ_PARTIDA> lisPartidas = new List<T_GUQ_PARTIDA>();
            T_GUQ_PARTIDA oPartida ;
            List<double> listaMontos = new List<double>();
            double montoTotal = 0;
            for (int i = 0; i < listaPartidas.Count(); i++)
            {
                montoTotal = montoTotal + listaPartidas[i].monto;
                oPartida = new T_GUQ_PARTIDA();
                oPartida.idPartida = listaPartidas[i].idPartida;
                oPartida.dscPartida = listaPartidas[i].descripcion;
                lisPartidas.Add(oPartida);
                listaMontos.Add(listaPartidas[i].monto);
            }


            bool exito = TGUQPresupuesto.Crear(presupuesto, lisPartidas, listaMontos);
            if (exito)
                mensaje = "Los datos se grabaron con exito";
            return mensaje;
        }

        public ActionResult Edit(int id)
        {

            var presupuesto = TGUQPresupuesto.Obtener(id);

            var partidaList = TGUQPartida.ListarTodos();
            ViewBag.PartidaList = new SelectList(partidaList, "idPartida", "dscPartida");

            var areaList = TGUQArea.ListarTodos();
            ViewBag.AreaList = new SelectList(areaList, "idArea", "descripcion", presupuesto.idArea);
            
            return View(presupuesto);
            //return Json(listaPartidas, JsonRequestBehavior.AllowGet);  
        }

         [HttpPost]
        public string Edit(T_GUQ_PRESUPUESTO presupuesto)
        {
            string mensaje = "Error al grabar los datos";

            if (listaPartidas.Count() == 0)
            {
                mensaje = "Error : No puede grabar presupuesto sin partida";
                return mensaje;
            }

            T_GUQ_PRESUPUESTO oPresupuesto = TGUQPresupuesto.Obtener(presupuesto.idPresupuesto);
            List<T_GUQ_PARTIDA> lisPartidas = new List<T_GUQ_PARTIDA>();
            T_GUQ_PARTIDA oPartida;
            List<double> listaMontos = new List<double>();
            double montoTotal = 0;

            for (int i = 0; i < listaPartidas.Count(); i++)
            {
                montoTotal = montoTotal + listaPartidas[i].monto;
                oPartida = new T_GUQ_PARTIDA();
                oPartida.idPartida = listaPartidas[i].idPartida;
                oPartida.dscPartida = listaPartidas[i].descripcion;
                lisPartidas.Add(oPartida);
                listaMontos.Add(listaPartidas[i].monto);
            }

            bool exito = TGUQPresupuesto.Editar(oPresupuesto, lisPartidas, listaMontos);
      
            if (exito)
                mensaje = "Los datos se grabaron con exito";
            return mensaje;
        }


        [HttpPost]
        public ActionResult ListarPartidas(int IdPresupuesto)
        {

            listaPartidas.Clear();
            var presupuesto = TGUQPresupuesto.Obtener(IdPresupuesto);

            if (presupuesto.anio != DateTime.Now.Year)
            {
                return Json("1", JsonRequestBehavior.AllowGet);
            }

            if (presupuesto.estado == "Generado")
            {
                Partida partida;

                foreach (var item in presupuesto.T_GUQ_PRESUPUESTO_PARTIDA)
                {
                    var oPartida = TGUQPartida.Obtener(item.idPartida);
                    partida = new Partida();
                    partida.idPartida = item.idPartida;
                    partida.monto = item.montoPartida;
                    partida.descripcion = oPartida.dscPartida;
                    listaPartidas.Add(partida);
                }

                return Json(listaPartidas, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("2", JsonRequestBehavior.AllowGet);
            }
          
        }


        [HttpPost]
        public ActionResult AgregarPartida(T_GUQ_PRESUPUESTO presupuesto, int partida)
        {
            foreach (var item in listaPartidas)
            {
                if (item.idPartida == partida)
                {
                  
                    return Json("Error", JsonRequestBehavior.AllowGet); 
                }
            }

            double monto = presupuesto.monto;
            var Partida = TGUQPartida.Obtener(partida);
            Partida oPartida = new Partida();
            oPartida.monto = Math.Round(monto,2);
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

        public ActionResult ExportToExcel(int id)
        {
            var presupuesto = TGUQPresupuesto.Obtener(id);
            Partida partida;
            listaPartidas.Clear();
           

            var dt = new System.Data.DataTable("presupuesto");
            dt.Columns.Add("Año", typeof(int));
            dt.Columns.Add("Area", typeof(string));
            dt.Columns.Add("Partida", typeof(string));
            dt.Columns.Add("Monto", typeof(string));

            foreach (var item in presupuesto.T_GUQ_PRESUPUESTO_PARTIDA)
            {
                var oPartida = TGUQPartida.Obtener(item.idPartida);
                dt.Rows.Add(presupuesto.anio, presupuesto.T_GUQ_AREA.descripcion,oPartida.dscPartida,item.montoPartida);
               
            }

            var grid = new GridView();
            grid.DataSource = dt;
            grid.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Presupuesto_"+presupuesto.anio+"_"+presupuesto.idArea+".xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return Json("Datos exportados correctamente", JsonRequestBehavior.AllowGet);
        }
	}


}