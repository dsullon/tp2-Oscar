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
            var tipoOperacionList = TGUQTipoOperacion.GetAll();
            ViewBag.TipoOperacionList = tipoOperacionList;
            ////using viewbag  
            //ViewBag.dropdownVD = new SelectList(DB.tblStuds.ToList(), "studid", "stud_name");
            return View(); 
        }
    }
}