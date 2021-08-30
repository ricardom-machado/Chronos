namespace Techjur.Models.DER
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AcaoMovimento")]
    public partial class AcaoMovimento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AcaoMovimento()
        {
            AcaoMovimentoDocumento = new HashSet<AcaoMovimentoDocumento>();
        }

        public int id { get; set; }

        public int idAcao { get; set; }

        public int idClasse { get; set; }

        public int idAssunto { get; set; }

        public int? idMovimento { get; set; }

        public int idRito { get; set; }

        public decimal valorCausa { get; set; }

        [StringLength(30)]
        public string numeroProcesso { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ocorrencia { get; set; }

        public virtual Acao Acao { get; set; }

        public virtual Assunto Assunto { get; set; }

        public virtual Classe Classe { get; set; }

        public virtual Movimento Movimento { get; set; }

        public virtual Rito Rito { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AcaoMovimentoDocumento> AcaoMovimentoDocumento { get; set; }
    }
}
