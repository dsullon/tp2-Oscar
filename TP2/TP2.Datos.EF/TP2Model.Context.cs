﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TP2.Datos.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using TP2.Entidades.EF;
    
    public partial class RicardoPalmaEntities : DbContext
    {
        public RicardoPalmaEntities()
            : base("name=RicardoPalmaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<T_GCT_PROGRAMACION_MEDICA> T_GCT_PROGRAMACION_MEDICA { get; set; }
        public virtual DbSet<T_GDA_ESPECIALIDAD__MEDICA> T_GDA_ESPECIALIDAD__MEDICA { get; set; }
        public virtual DbSet<T_GDA_HISTORIA_CLINICA> T_GDA_HISTORIA_CLINICA { get; set; }
        public virtual DbSet<T_GDA_PACIENTE> T_GDA_PACIENTE { get; set; }
        public virtual DbSet<T_GG_EMPLEADO> T_GG_EMPLEADO { get; set; }
        public virtual DbSet<T_GG_INMUEBLE> T_GG_INMUEBLE { get; set; }
        public virtual DbSet<T_GG_MODELO> T_GG_MODELO { get; set; }
        public virtual DbSet<T_GUQ_AREA> T_GUQ_AREA { get; set; }
        public virtual DbSet<T_GUQ_CAMA> T_GUQ_CAMA { get; set; }
        public virtual DbSet<T_GUQ_CONSOLIDADO_PRESUPUESTO> T_GUQ_CONSOLIDADO_PRESUPUESTO { get; set; }
        public virtual DbSet<T_GUQ_ESTADÍSTICA_RECURSOS> T_GUQ_ESTADÍSTICA_RECURSOS { get; set; }
        public virtual DbSet<T_GUQ_INGRESO_SALIDA_PACIENTE> T_GUQ_INGRESO_SALIDA_PACIENTE { get; set; }
        public virtual DbSet<T_GUQ_INSUMO> T_GUQ_INSUMO { get; set; }
        public virtual DbSet<T_GUQ_INSUMO_TIPOOPERACION> T_GUQ_INSUMO_TIPOOPERACION { get; set; }
        public virtual DbSet<T_GUQ_PARTIDA> T_GUQ_PARTIDA { get; set; }
        public virtual DbSet<T_GUQ_PRESUPUESTO> T_GUQ_PRESUPUESTO { get; set; }
        public virtual DbSet<T_GUQ_RESERVA_SALA_OPERACIÓN> T_GUQ_RESERVA_SALA_OPERACIÓN { get; set; }
        public virtual DbSet<T_GUQ_SOLICITUD_UCI> T_GUQ_SOLICITUD_UCI { get; set; }
        public virtual DbSet<T_GUQ_TIPO_OPERACIÓN> T_GUQ_TIPO_OPERACIÓN { get; set; }
        public virtual DbSet<T_GUQ_TURNO_MEDICO> T_GUQ_TURNO_MEDICO { get; set; }
    }
}
