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
    
    public partial class T_GDA_HISTORIA_CLINICA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_GDA_HISTORIA_CLINICA()
        {
            this.T_GUQ_SOLICITUD_UCI = new HashSet<T_GUQ_SOLICITUD_UCI>();
        }
    
        public int nroHistoriaClinica { get; set; }
        public string diagnóstico { get; set; }
        public int idPaciente { get; set; }
    
        public virtual T_GDA_PACIENTE T_GDA_PACIENTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_GUQ_SOLICITUD_UCI> T_GUQ_SOLICITUD_UCI { get; set; }
    }
}
