namespace Techjur.Models.DER
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AcaoMovimentoDocumento")]
    public partial class AcaoMovimentoDocumento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AcaoMovimentoDocumento()
        {
            SegurancaLogEnvio = new HashSet<SegurancaLogEnvio>();
        }

        public int id { get; set; }

        public int idAcaoMovimento { get; set; }

        [Required]
        public byte[] documento { get; set; }

        [Required]
        [StringLength(100)]
        public string documentoMime { get; set; }

        [Required]
        public byte[] hash { get; set; }

        public virtual AcaoMovimento AcaoMovimento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegurancaLogEnvio> SegurancaLogEnvio { get; set; }
    }
}
