namespace DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Produit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produit()
        {
            Avis = new HashSet<Avi>();
            DetailsCommandes = new HashSet<DetailsCommande>();
        }

        [Key]
        public int IdProduit { get; set; }

        public int IdFournisseur { get; set; }

        [StringLength(50)]
        public string NomProduit { get; set; }

        public bool? IsActif { get; set; }

        public decimal? PrixProduit { get; set; }

        public int? UnitsInStock { get; set; }

        public double? PoidsProduit { get; set; }

        [StringLength(200)]
        public string UrlImage { get; set; }

        public double? LargeurProduit { get; set; }

        public double? LongueurProduit { get; set; }

        public double? HauteurProduit { get; set; }

        public int? CapaciteProduit { get; set; }

        [StringLength(50)]
        public string Couleur { get; set; }

        [StringLength(255)]
        public string DescriptionProduit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Avi> Avis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailsCommande> DetailsCommandes { get; set; }

        [ForeignKey("IdFournisseur")]
        public virtual Fournisseur Fournisseur { get; set; }
    }
}
