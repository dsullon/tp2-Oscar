//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TP2.Entidades.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_GUQ_RESERVA_SALA_OPERACIÓN
    {
        public int idReserva { get; set; }
        public int idOperación { get; set; }
        public int duración { get; set; }
        public int idPaciente { get; set; }
        public int idInmueble { get; set; }
        public string estado { get; set; }
        public int idEmpleado { get; set; }
        public System.DateTime fechaInicio { get; set; }
        public System.DateTime fechaFin { get; set; }
    
        public virtual T_GDA_PACIENTE T_GDA_PACIENTE { get; set; }
        public virtual T_GG_EMPLEADO T_GG_EMPLEADO { get; set; }
        public virtual T_GG_INMUEBLE T_GG_INMUEBLE { get; set; }
        public virtual T_GUQ_TIPO_OPERACIÓN T_GUQ_TIPO_OPERACIÓN { get; set; }
    }
}
