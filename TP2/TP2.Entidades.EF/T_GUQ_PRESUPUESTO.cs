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
    
    public partial class T_GUQ_PRESUPUESTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_GUQ_PRESUPUESTO()
        {
            this.T_GUQ_CONSOLIDADO_PRESUPUESTO = new HashSet<T_GUQ_CONSOLIDADO_PRESUPUESTO>();
            this.T_GUQ_PARTIDA = new HashSet<T_GUQ_PARTIDA>();
        }
    
        public int idPresupuesto { get; set; }
        public int anio { get; set; }
        public int idArea { get; set; }
        public double monto { get; set; }
        public string estado { get; set; }
    
        public virtual T_GUQ_AREA T_GUQ_AREA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_GUQ_CONSOLIDADO_PRESUPUESTO> T_GUQ_CONSOLIDADO_PRESUPUESTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_GUQ_PARTIDA> T_GUQ_PARTIDA { get; set; }
    }
}
