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
    
    public partial class T_GUQ_CAMA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_GUQ_CAMA()
        {
            this.T_GUQ_INGRESO_SALIDA_PACIENTE = new HashSet<T_GUQ_INGRESO_SALIDA_PACIENTE>();
        }
    
        public string marca { get; set; }
        public string modelo { get; set; }
        public string estado { get; set; }
        public string idModelo { get; set; }
        public string codBien { get; set; }
    
        public virtual T_GG_INMUEBLE T_GG_INMUEBLE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_GUQ_INGRESO_SALIDA_PACIENTE> T_GUQ_INGRESO_SALIDA_PACIENTE { get; set; }
    }
}
