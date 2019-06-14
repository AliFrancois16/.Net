namespace DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Avis = new HashSet<Avi>();
            Commandes = new HashSet<Commande>();
        }

        [Key]
        public int IdClient { get; set; }
        [Display(Name ="Votre Nom")]
        [StringLength(50)]
        public string NomClient { get; set; }
        [Display(Name = "E-mail")]
        [StringLength(50)]
        public string EmailClient { get; set; }
        [Display(Name = "Votre Address")]
        [StringLength(50)]
        public string AdresseClient { get; set; }
        [Display(Name = "Votre Code Postal")]
        public int? CodePostalClient { get; set; }
        [Display(Name = "Votre Ville")]
        [StringLength(50)]
        public string VilleClient { get; set; }
        [Display(Name = "Pays")]
        [StringLength(50)]
        public string PaysClient { get; set; }

        public DateTime? DateInscriptionClient { get; set; }
        [Display(Name = "Votre Nr.Telephone")]
        [StringLength(20)]
        public string TelephoneClient { get; set; }

        [StringLength(20)]
        public string Theme { get; set; }

        public bool? IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Avi> Avis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Commande> Commandes { get; set; }
    }
}
