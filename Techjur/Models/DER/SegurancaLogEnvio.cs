namespace Techjur.Models.DER
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SegurancaLogEnvio")]
    public partial class SegurancaLogEnvio
    {
        public int id { get; set; }

        [Required]
        [StringLength(11)]
        public string idUsuario { get; set; }

        public int idAcaoMovimentoDocumento { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ocorrencia { get; set; }

        public virtual AcaoMovimentoDocumento AcaoMovimentoDocumento { get; set; }

        public virtual SegurancaUsuario SegurancaUsuario { get; set; }
    }
}
