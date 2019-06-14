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
    public class FournisseursController : Controller
    {
        

        IRepository<Fournisseur> rep = new EFRepository<Fournisseur>();

        // GET: Fournisseurs
        public ActionResult Index()
        {
            return View(rep.Lister());
        }

        // GET: Fournisseurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fournisseur fournisseur = rep.Trouver((int)id);
            if (fournisseur == null)
            {
                return HttpNotFound();
            }
            return View(fournisseur);
        }

        // GET: Fournisseurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fournisseurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFournisseur,NomFournisseur,AdresseFournisseur,CodePostalFournisseur,VilleFournisseur,PaysFournisseur,TelephoneFournisseur,WebSiteFournisseur,EmailFournisseur,IsActifFournisseur")] Fournisseur fournisseur)
        {
            if (ModelState.IsValid)
            {
                rep.Ajouter(fournisseur);
                return RedirectToAction("Index");
            }

            return View(fournisseur);
        }

        // GET: Fournisseurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fournisseur fournisseur = rep.Trouver((int)id);
            if (fournisseur == null)
            {
                return HttpNotFound();
            }
            return View(fournisseur);
        }

        // POST: Fournisseurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFournisseur,NomFournisseur,AdresseFournisseur,CodePostalFournisseur,VilleFournisseur,PaysFournisseur,TelephoneFournisseur,WebSiteFournisseur,EmailFournisseur,IsActifFournisseur")] Fournisseur fournisseur)
        {
            if (ModelState.IsValid)
            {
                rep.Modifier(fournisseur);
                return RedirectToAction("Index");
            }
            return View(fournisseur);
        }

        // GET: Fournisseurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fournisseur fournisseur = rep.Trouver((int)id);
            if (fournisseur == null)
            {
                return HttpNotFound();
            }
            return View(fournisseur);
        }

        // POST: Fournisseurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rep.Supprimer(id, "IsActifFournisseur");
            return RedirectToAction("Index");
        }
        //private EDMAzure db = new EDMAzure();
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
