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
    
    public partial class T_GG_EMPLEADO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_GG_EMPLEADO()
        {
            this.T_GMP_BITACORA_INCIDENCIA = new HashSet<T_GMP_BITACORA_INCIDENCIA>();
            this.T_GMP_RESERVA_SERVICIO = new HashSet<T_GMP_RESERVA_SERVICIO>();
            this.T_GDA_HISTORIA_CLINICA = new HashSet<T_GDA_HISTORIA_CLINICA>();
            this.T_GUQ_RESERVA_SALA_OPERACIÓN = new HashSet<T_GUQ_RESERVA_SALA_OPERACIÓN>();
            this.T_GDA_ESPECIALIDAD__MEDICA = new HashSet<T_GDA_ESPECIALIDAD__MEDICA>();
            this.T_GCT_PROGRAMACION_MEDICA = new HashSet<T_GCT_PROGRAMACION_MEDICA>();
        }
    
        public string idEmpleado { get; set; }
        public int nroDni { get; set; }
        public string nomEmpleado { get; set; }
        public System.DateTime fecIngreso { get; set; }
        public string stdEmplead { get; set; }
        public string dscCargo { get; set; }
        public string dscProfesion { get; set; }
        public string dscArea { get; set; }
        public string idPersona { get; set; }
    
        public virtual T_GG_PERSONA T_GG_PERSONA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_GMP_BITACORA_INCIDENCIA> T_GMP_BITACORA_INCIDENCIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_GMP_RESERVA_SERVICIO> T_GMP_RESERVA_SERVICIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_GDA_HISTORIA_CLINICA> T_GDA_HISTORIA_CLINICA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_GUQ_RESERVA_SALA_OPERACIÓN> T_GUQ_RESERVA_SALA_OPERACIÓN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_GDA_ESPECIALIDAD__MEDICA> T_GDA_ESPECIALIDAD__MEDICA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_GCT_PROGRAMACION_MEDICA> T_GCT_PROGRAMACION_MEDICA { get; set; }
    }
}
