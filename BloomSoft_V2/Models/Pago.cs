namespace BloomSoft_V2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //registra los datos de pago del usuario y su folio de licencia (sin habilitar)

    [Table("Pago")]
    public partial class Pago
    {
        [Key]
        [Column(Order = 0)]
        public string id_usuario { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_licencia { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "money")]
        public decimal monto { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime fecha { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual LicenciaUsuario LicenciaUsuario { get; set; }
    }
}
