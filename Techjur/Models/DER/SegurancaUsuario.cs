namespace Techjur.Models.DER
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SegurancaUsuario")]
    public partial class SegurancaUsuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SegurancaUsuario()
        {
            Notificacao = new HashSet<Notificacao>();
            SegurancaLogEnvio = new HashSet<SegurancaLogEnvio>();
        }

        [StringLength(11)]
        public string id { get; set; }

        [Required]
        [StringLength(250)]
        public string nome { get; set; }

        [Required]
        [StringLength(255)]
        public string senha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notificacao> Notificacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SegurancaLogEnvio> SegurancaLogEnvio { get; set; }
    }
}
