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
    
    public partial class T_GG_MODELO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_GG_MODELO()
        {
            this.T_GG_MUEBLE = new HashSet<T_GG_MUEBLE>();
        }
    
        public string idModelo { get; set; }
        public string nomModelo { get; set; }
        public string dscMarca { get; set; }
        public string T_GG_MUEBLE_idModelo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_GG_MUEBLE> T_GG_MUEBLE { get; set; }
    }
}
