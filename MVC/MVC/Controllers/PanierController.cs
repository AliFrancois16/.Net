using DataBase;
using DataBase.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class PanierController : Controller
    {
        IRepository<Produit> rep = new EFRepository<Produit>();
        Commande Panier;
        // GET: Panier
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (Session["panier"] != null)
            {
                return View(((Commande)Session["panier"]).DetailsCommandes);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        
        public ActionResult AjouterAuPanier(int Id)
        {
            if (Session["panier"] == null)
            {
                Panier = new Commande() { DateCommande = DateTime.Today, IdClient = int.Parse(Session["id"].ToString()) };
                Panier.DetailsCommandes = new List<DetailsCommande>();
                Panier.DetailsCommandes.Add(new DetailsCommande { IdProduit = Id, Produit = rep.Trouver(Id), Quantite = 1 });
                Session["panier"] = Panier;
            }
            else
            {
                Panier = (Commande)Session["panier"];
                if (Panier.DetailsCommandes.Where(d => d.IdProduit == Id).Count() > 0)
                {
                    Panier.DetailsCommandes.Where(d => d.IdProduit == Id).First().Quantite++;
                }
                else
                {
                    Panier.DetailsCommandes.Add(new DetailsCommande { IdProduit = Id, Produit = rep.Trouver(Id), Quantite = 1 });
                }

                Session["panier"] = Panier;
            }
            return RedirectToAction("Index");
        }

        public ContentResult Incrementer(int IdProduit)
        {
            Panier = (Commande)Session["panier"];
            DetailsCommande detail = Panier.DetailsCommandes.Where(d => d.IdProduit == IdProduit).First();
            detail.Quantite++;
            Session["panier"] = Panier;
            return new ContentResult() { Content = detail.Quantite.ToString() };
        }

        public ContentResult Decrementer(int IdProduit)
        {
            Panier = (Commande)Session["panier"];
            DetailsCommande detail = Panier.DetailsCommandes.Where(d => d.IdProduit == IdProduit).First();
            if(detail.Quantite == 1)
            {
                return new ContentResult() { Content = detail.Quantite.ToString() };
            }
            detail.Quantite--;
            Session["panier"] = Panier;
            return new ContentResult() { Content = detail.Quantite.ToString() };
        }

        // GET: Panier/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Panier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Panier/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Panier/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Panier/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Valide()
        {
            IRepository<Commande> rep = new EFRepository<Commande>();
            Commande c = (Commande)Session["panier"];
            rep.Ajouter(c);
            return RedirectToAction("Index", "Home");
        }
        // GET: Panier/Delete/5
        public ActionResult Delete(int id)
        {
            Commande c = (Commande)Session["panier"];
            DetailsCommande d = c.DetailsCommandes.Where(dc => dc.IdDetailsCommandes == id).First();
            return View(d);
        }

        // POST: Panier/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Commande c = (Commande)Session["panier"];
                DetailsCommande d = c.DetailsCommandes.Where(dc => dc.IdDetailsCommandes == id).First();
                if (d != null)
                {
                    c.DetailsCommandes.Remove(d);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
