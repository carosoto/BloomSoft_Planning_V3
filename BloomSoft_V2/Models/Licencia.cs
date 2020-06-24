namespace BloomSoft_V2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //modelo que guarda los datos de los proyectos registrados con una licencia premium (sin habilitar)

    [Table("Licencia")]
    public partial class Licencia
    {
        public int id { get; set; }

        public int id_licencia { get; set; }

        public int cantidadRequerimientos { get; set; }

        public int cantidadProyectos { get; set; }

        public int tiempo { get; set; }

        [StringLength(30)]
        public string nombre { get; set; }

        public virtual LicenciaUsuario LicenciaUsuario { get; set; }
    }
}
