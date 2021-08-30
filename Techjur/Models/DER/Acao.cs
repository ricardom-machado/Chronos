namespace Techjur.Models.DER
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Acao")]
    public partial class Acao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Acao()
        {
            AcaoMovimento = new HashSet<AcaoMovimento>();
            AcaoParte = new HashSet<AcaoParte>();
        }

        public int id { get; set; }

        public int idClasse { get; set; }

        public int idAssunto { get; set; }

        public int? idMovimento { get; set; }

        public int idRito { get; set; }

        [Required]
        [StringLength(1000)]
        public string descricao { get; set; }

        public decimal valorCausa { get; set; }

        [StringLength(30)]
        public string numeroProcesso { get; set; }

        public virtual Assunto Assunto { get; set; }

        public virtual Classe Classe { get; set; }

        public virtual Movimento Movimento { get; set; }

        public virtual Rito Rito { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AcaoMovimento> AcaoMovimento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AcaoParte> AcaoParte { get; set; }
    }
}
