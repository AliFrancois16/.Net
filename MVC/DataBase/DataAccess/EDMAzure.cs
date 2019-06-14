namespace DataBase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EDMAzure : DbContext
    {
        public EDMAzure() : base("name=EDMAzure")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Avi> Avis { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Commande> Commandes { get; set; }
        public virtual DbSet<DetailsCommande> DetailsCommandes { get; set; }
        public virtual DbSet<Fournisseur> Fournisseurs { get; set; }
        public virtual DbSet<Produit> Produits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avi>()
                .Property(e => e.TexteAvis)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.NomClient)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.EmailClient)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.AdresseClient)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.VilleClient)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.PaysClient)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.TelephoneClient)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Theme)
                .IsUnicode(false);

            modelBuilder.Entity<Commande>()
                .Property(e => e.StateDeCommande)
                .IsUnicode(false);

            modelBuilder.Entity<DetailsCommande>()
                .Property(e => e.Prix)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Fournisseur>()
                .Property(e => e.NomFournisseur)
                .IsUnicode(false);

            modelBuilder.Entity<Fournisseur>()
                .Property(e => e.AdresseFournisseur)
                .IsUnicode(false);

            modelBuilder.Entity<Fournisseur>()
                .Property(e => e.VilleFournisseur)
                .IsUnicode(false);

            modelBuilder.Entity<Fournisseur>()
                .Property(e => e.PaysFournisseur)
                .IsUnicode(false);

            modelBuilder.Entity<Fournisseur>()
                .Property(e => e.TelephoneFournisseur)
                .IsUnicode(false);

            modelBuilder.Entity<Fournisseur>()
                .Property(e => e.WebSiteFournisseur)
                .IsUnicode(false);

            modelBuilder.Entity<Fournisseur>()
                .Property(e => e.EmailFournisseur)
                .IsUnicode(false);

            modelBuilder.Entity<Produit>()
                .Property(e => e.NomProduit)
                .IsUnicode(false);

            modelBuilder.Entity<Produit>()
                .Property(e => e.PrixProduit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Produit>()
                .Property(e => e.UrlImage)
                .IsUnicode(false);

            modelBuilder.Entity<Produit>()
                .Property(e => e.Couleur)
                .IsUnicode(false);

            modelBuilder.Entity<Produit>()
                .Property(e => e.DescriptionProduit)
                .IsUnicode(false);
        }
    }
}
