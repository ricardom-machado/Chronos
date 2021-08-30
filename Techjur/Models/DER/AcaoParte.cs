namespace Techjur.Models.DER
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AcaoParte")]
    public partial class AcaoParte
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idAcao { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idPessoa { get; set; }

        public int idAcaoParteTipo { get; set; }

        public virtual Acao Acao { get; set; }

        public virtual AcaoParteTipo AcaoParteTipo { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
