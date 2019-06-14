using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataBase;
using DataBase.DataAccess;
using MVC.Models;
//using DataBas.DataAccess;

namespace MVC.Controllers
{
    [Authorize]
    public class ProduitsController : Controller
    {
        IRepository<Produit> rep = new EFRepository<Produit>();
        IRepository<Fournisseur> repF = new EFRepository<Fournisseur>();


        // GET: Produits
        public ActionResult Index()
        {
            return View(rep.Lister());
        }

        // GET: Produits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var produit = rep.Trouver(id.GetValueOrDefault());
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        // GET: Produits/Create
        public ActionResult Create()
        {
            ViewBag.IdFournisseur = new SelectList(repF.Lister().Select(f=>new {f.IdFournisseur,f.NomFournisseur }), "IdFournisseur", "NomFournisseur");
            return View();
        }

        // POST: Produits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProduit,IdFournisseur,NomProduit,IsActif,PrixProduit,UnitsInStock,PoidsProduit,UrlImage,LargeurProduit,LongueurProduit,HauteurProduit,CapaciteProduit,Couleur,DescriptionProduit")] Produit produit)
        {
            if (ModelState.IsValid)
            {
                rep.Ajouter(produit);
                return RedirectToAction("Index");
            }

            ViewBag.IdFournisseur = new SelectList(repF.Lister().Select(f=>new { f.IdFournisseur, f.NomFournisseur }), "IdFournisseur", "NomFournisseur", produit.IdFournisseur);
            return View(produit);
        }

        // GET: Produits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var produit=rep.Trouver((int)id);

            if (produit == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFournisseur = new SelectList(repF.Lister().Select(f => new { f.IdFournisseur, f.NomFournisseur }), "IdFournisseur", "NomFournisseur", produit.IdFournisseur);
            return View(produit);
        }

        // POST: Produits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProduit,IdFournisseur,NomProduit,IsActif,PrixProduit,UnitsInStock,PoidsProduit,UrlImage,LargeurProduit,LongueurProduit,HauteurProduit,CapaciteProduit,Couleur,DescriptionProduit")] Produit produit)
        {
            if (ModelState.IsValid)
            {
                rep.Modifier(produit);
                return RedirectToAction("Index");
            }
            ViewBag.IdFournisseur = new SelectList(repF.Lister().Select(f => new { f.IdFournisseur, f.NomFournisseur }), "IdFournisseur", "NomFournisseur", produit.IdFournisseur);
            return View(produit);
        }

        // GET: Produits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var produit = rep.Trouver(id.GetValueOrDefault());
            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(produit);
        }

        // POST: Produits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rep.Supprimer(id, "IsActif");

            return RedirectToAction("Index");
        }

    }
}
