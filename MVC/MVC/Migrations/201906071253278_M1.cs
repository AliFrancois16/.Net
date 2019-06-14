namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M1 : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Fournisseurs",
            //    c => new
            //        {
            //            IdFournisseur = c.Int(nullable: false, identity: true),
            //            NomFournisseur = c.String(maxLength: 50),
            //            AdresseFournisseur = c.String(maxLength: 50),
            //            CodePostalFournisseur = c.Int(),
            //            VilleFournisseur = c.String(maxLength: 50),
            //            PaysFournisseur = c.String(maxLength: 50),
            //            TelephoneFournisseur = c.String(maxLength: 20),
            //            WebSiteFournisseur = c.String(maxLength: 100),
            //            EmailFournisseur = c.String(maxLength: 50),
            //            IsActifFournisseur = c.Boolean(),
            //        })
            //    .PrimaryKey(t => t.IdFournisseur);
            
            //CreateTable(
            //    "dbo.Produits",
            //    c => new
            //        {
            //            IdProduit = c.Int(nullable: false, identity: true),
            //            IdFournisseur = c.Int(),
            //            NomProduit = c.String(maxLength: 50),
            //            IsActif = c.Boolean(),
            //            PrixProduit = c.Decimal(precision: 18, scale: 2),
            //            UnitsInStock = c.Int(),
            //            PoidsProduit = c.Double(),
            //            UrlImage = c.String(maxLength: 200),
            //            LargeurProduit = c.Double(),
            //            LongueurProduit = c.Double(),
            //            HauteurProduit = c.Double(),
            //            CapaciteProduit = c.Int(),
            //            Couleur = c.String(maxLength: 50),
            //            DescriptionProduit = c.String(maxLength: 255),
            //        })
            //    .PrimaryKey(t => t.IdProduit)
            //    .ForeignKey("dbo.Fournisseurs", t => t.IdFournisseur)
            //    .Index(t => t.IdFournisseur);
            
            //CreateTable(
            //    "dbo.Avis",
            //    c => new
            //        {
            //            IdAvis = c.Int(nullable: false, identity: true),
            //            IdClient = c.Int(),
            //            IdProduit = c.Int(),
            //            TexteAvis = c.String(maxLength: 255),
            //            NoteAvis = c.Int(),
            //            DateAvis = c.DateTime(),
            //            IsPublie = c.Boolean(),
            //        })
            //    .PrimaryKey(t => t.IdAvis)
            //    .ForeignKey("dbo.Clients", t => t.IdClient)
            //    .ForeignKey("dbo.Produits", t => t.IdProduit)
            //    .Index(t => t.IdClient)
            //    .Index(t => t.IdProduit);
            
            //CreateTable(
            //    "dbo.Clients",
            //    c => new
            //        {
            //            IdClient = c.Int(nullable: false, identity: true),
            //            NomClient = c.String(maxLength: 50),
            //            EmailClient = c.String(maxLength: 50),
            //            AdresseClient = c.String(maxLength: 50),
            //            CodePostalClient = c.Int(),
            //            VilleClient = c.String(maxLength: 50),
            //            PaysClient = c.String(maxLength: 50),
            //            DateInscriptionClient = c.DateTime(),
            //            TelephoneClient = c.String(maxLength: 20),
            //            Theme = c.String(maxLength: 20),
            //            IsActive = c.Boolean(),
            //            Email = c.String(),
            //            Password = c.String(maxLength: 100),
            //            ConfirmPassword = c.String(),
            //            Discriminator = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.IdClient);
            
            //CreateTable(
            //    "dbo.Commandes",
            //    c => new
            //        {
            //            IdCommande = c.Int(nullable: false, identity: true),
            //            IdClient = c.Int(),
            //            DateCommande = c.DateTime(),
            //            DateLivraison = c.DateTime(),
            //            StateDeCommande = c.String(maxLength: 30),
            //        })
            //    .PrimaryKey(t => t.IdCommande)
            //    .ForeignKey("dbo.Clients", t => t.IdClient)
            //    .Index(t => t.IdClient);
            
            //CreateTable(
            //    "dbo.DetailsCommandes",
            //    c => new
            //        {
            //            IdDetailsCommandes = c.Int(nullable: false, identity: true),
            //            IdCommande = c.Int(),
            //            IdProduit = c.Int(),
            //            Prix = c.Decimal(precision: 18, scale: 2),
            //            Quantite = c.Int(),
            //        })
            //    .PrimaryKey(t => t.IdDetailsCommandes)
            //    .ForeignKey("dbo.Commandes", t => t.IdCommande)
            //    .ForeignKey("dbo.Produits", t => t.IdProduit)
            //    .Index(t => t.IdCommande)
            //    .Index(t => t.IdProduit);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            //DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            //DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            //DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            //DropForeignKey("dbo.Produits", "IdFournisseur", "dbo.Fournisseurs");
            //DropForeignKey("dbo.Avis", "IdProduit", "dbo.Produits");
            //DropForeignKey("dbo.DetailsCommandes", "IdProduit", "dbo.Produits");
            //DropForeignKey("dbo.DetailsCommandes", "IdCommande", "dbo.Commandes");
            //DropForeignKey("dbo.Commandes", "IdClient", "dbo.Clients");
            //DropForeignKey("dbo.Avis", "IdClient", "dbo.Clients");
            //DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            //DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            //DropIndex("dbo.AspNetUsers", "UserNameIndex");
            //DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            //DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            //DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            //DropIndex("dbo.DetailsCommandes", new[] { "IdProduit" });
            //DropIndex("dbo.DetailsCommandes", new[] { "IdCommande" });
            //DropIndex("dbo.Commandes", new[] { "IdClient" });
            //DropIndex("dbo.Avis", new[] { "IdProduit" });
            //DropIndex("dbo.Avis", new[] { "IdClient" });
            //DropIndex("dbo.Produits", new[] { "IdFournisseur" });
            //DropTable("dbo.AspNetUserLogins");
            //DropTable("dbo.AspNetUserClaims");
            //DropTable("dbo.AspNetUsers");
            //DropTable("dbo.AspNetUserRoles");
            //DropTable("dbo.AspNetRoles");
            //DropTable("dbo.DetailsCommandes");
            //DropTable("dbo.Commandes");
            //DropTable("dbo.Clients");
            //DropTable("dbo.Avis");
            //DropTable("dbo.Produits");
            //DropTable("dbo.Fournisseurs");
        }
    }
}
