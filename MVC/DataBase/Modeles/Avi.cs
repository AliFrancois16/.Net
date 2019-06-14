namespace DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Avi
    {
        [Key]
        public int IdAvis { get; set; }

        public int? IdClient { get; set; }

        public int? IdProduit { get; set; }

        [StringLength(255)]
        public string TexteAvis { get; set; }

        public int? NoteAvis { get; set; }

        public DateTime? DateAvis { get; set; }

        public bool? IsPublie { get; set; }

        public virtual Client Client { get; set; }

        public virtual Produit Produit { get; set; }
    }
}
