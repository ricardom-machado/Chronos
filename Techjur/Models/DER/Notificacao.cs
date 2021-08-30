namespace Techjur.Models.DER
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notificacao")]
    public partial class Notificacao
    {
        public int id { get; set; }

        [Required]
        [StringLength(11)]
        public string idUsuario { get; set; }

        [Required]
        [StringLength(200)]
        public string titulo { get; set; }

        [StringLength(200)]
        public string url { get; set; }

        public DateTime criadoEm { get; set; }

        public DateTime? vistoEm { get; set; }

        public virtual SegurancaUsuario SegurancaUsuario { get; set; }
    }
}
