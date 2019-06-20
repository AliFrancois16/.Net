namespace DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DetailsCommande
    {
        [Key]
        public int IdDetailsCommandes { get; set; }

        public int IdCommande { get; set; }

        public int IdProduit { get; set; }

        public decimal? Prix { get; set; }

        public int? Quantite { get; set; }

        [ForeignKey("IdCommande")]
        public virtual Commande Commande { get; set; }

        [ForeignKey("IdProduit")]
        public virtual Produit Produit { get; set; }
    }
}
