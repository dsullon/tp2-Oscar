//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
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
        public System.DateTime fecha { get; set; }
        public System.TimeSpan horaInicio { get; set; }
        public int idPaciente { get; set; }
        public int idInmueble { get; set; }
        public string estado { get; set; }
    
        public virtual T_GDA_PACIENTE T_GDA_PACIENTE { get; set; }
        public virtual T_GG_INMUEBLE T_GG_INMUEBLE { get; set; }
        public virtual T_GUQ_TIPO_OPERACIÓN T_GUQ_TIPO_OPERACIÓN { get; set; }
    }
}
