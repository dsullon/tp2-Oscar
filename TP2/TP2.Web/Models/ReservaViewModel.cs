using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP2.Entidades.EF;

namespace TP2.Web.Models
{
    public class ReservaViewModel
    {
        public IEnumerable<T_GG_EMPLEADO> Empleados { get; set; }
        //public IEnumerable<Student> Students { get; set; }
    }
}