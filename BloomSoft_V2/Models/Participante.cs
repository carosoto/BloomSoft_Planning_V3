namespace BloomSoft_V2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //inicializa los valores de los prarticipantes de cada proyecto

    [Table("Participante")]
    public partial class Participante
    {
        [Key]
        public int id_participante { get; set; }

        public int id_proyecto { get; set; }

        [Required]
        [StringLength(128)]
        public string id_usuario { get; set; }

        public int tipo { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
