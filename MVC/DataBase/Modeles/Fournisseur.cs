namespace DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Fournisseur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fournisseur()
        {
            Produits = new HashSet<Produit>();
        }

        [Key]
        public int IdFournisseur { get; set; }

        [StringLength(50)]
        public string NomFournisseur { get; set; }

        [StringLength(50)]
        public string AdresseFournisseur { get; set; }

        public int? CodePostalFournisseur { get; set; }

        [StringLength(50)]
        public string VilleFournisseur { get; set; }

        [StringLength(50)]
        public string PaysFournisseur { get; set; }

        [StringLength(20)]
        public string TelephoneFournisseur { get; set; }

        [StringLength(100)]
        public string WebSiteFournisseur { get; set; }

        [StringLength(50)]
        public string EmailFournisseur { get; set; }

        public bool? IsActifFournisseur { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produit> Produits { get; set; }
    }
}
