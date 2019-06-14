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

namespace MVC.Controllers
{
    [Authorize]
    public class DetailsCommandesController : Controller
    {
        IRepository<DetailsCommande> rep = new EFDetailsCommandes();
        IRepository<Commande> repC = new EFRepository<Commande>();
        IRepository<Produit> repP = new EFRepository<Produit>();

        // GET: DetailsCommandes
        public ActionResult Index()
        {
            return View(rep.Lister());
        }

        // GET: DetailsCommandes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailsCommande detailsCommande = rep.Trouver((int)id);
            if (detailsCommande == null)
            {
                return HttpNotFound();
            }
            return View(detailsCommande);
        }

        // GET: DetailsCommandes/Create
        public ActionResult Create()
        {
            ViewBag.IdCommande = new SelectList(repC.Lister().Select(c=>new { c.IdCommande, c.StateDeCommande }), "IdCommande", "StateDeCommande");
            ViewBag.IdProduit = new SelectList(repP.Lister().Select(p=>new { p.IdProduit, p.NomProduit }), "IdProduit", "NomProduit");
            return View();
        }

        // POST: DetailsCommandes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDetailsCommandes,IdCommande,IdProduit,Prix,Quantite")] DetailsCommande detailsCommande)
        {
            if (ModelState.IsValid)
            {
                rep.Ajouter(detailsCommande);
                return RedirectToAction("Index");
            }

            ViewBag.IdCommande = new SelectList(repC.Lister().Select(c => new { c.IdCommande, c.StateDeCommande }), "IdCommande", "StateDeCommande", detailsCommande.IdCommande);
            ViewBag.IdProduit = new SelectList(repP.Lister().Select(p => new { p.IdProduit, p.NomProduit }), "IdProduit", "NomProduit", detailsCommande.IdProduit);
            return View(detailsCommande);
        }

        // GET: DetailsCommandes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailsCommande detailsCommande = rep.Trouver((int)id);
            if (detailsCommande == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCommande = new SelectList(repC.Lister().Select(c => new { c.IdCommande, c.StateDeCommande }), "IdCommande", "StateDeCommande", detailsCommande.IdCommande);
            ViewBag.IdProduit = new SelectList(repP.Lister().Select(p => new { p.IdProduit, p.NomProduit }), "IdProduit", "NomProduit", detailsCommande.IdProduit);
            return View(detailsCommande);
        }

        // POST: DetailsCommandes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDetailsCommandes,IdCommande,IdProduit,Prix,Quantite")] DetailsCommande detailsCommande)
        {
            if (ModelState.IsValid)
            {
                rep.Modifier(detailsCommande);
                return RedirectToAction("Index");
            }
            ViewBag.IdCommande = new SelectList(repC.Lister().Select(c => new { c.IdCommande, c.StateDeCommande }), "IdCommande", "StateDeCommande", detailsCommande.IdCommande);
            ViewBag.IdProduit = new SelectList(repP.Lister().Select(p => new { p.IdProduit, p.NomProduit }), "IdProduit", "NomProduit", detailsCommande.IdProduit);
            return View(detailsCommande);
        }

        // GET: DetailsCommandes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailsCommande detailsCommande = rep.Trouver((int)id);
            if (detailsCommande == null)
            {
                return HttpNotFound();
            }
            return View(detailsCommande);
        }

        // POST: DetailsCommandes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rep.Supprimer(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
