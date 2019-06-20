namespace DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Commande
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Commande()
        {
            DetailsCommandes = new HashSet<DetailsCommande>();
        }

        [Key]
        public int IdCommande { get; set; }

        public int IdClient { get; set; }

        public DateTime? DateCommande { get; set; }

        public DateTime? DateLivraison { get; set; }

        [StringLength(30)]
        public string StateDeCommande { get; set; }

        [ForeignKey("IdClient")]
        public virtual Client Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailsCommande> DetailsCommandes { get; set; }
    }
}
