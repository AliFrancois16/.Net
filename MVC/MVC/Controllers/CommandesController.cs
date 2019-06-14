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
    public class CommandesController : Controller
    {
        IRepository<Commande> rep = new EFRepository<Commande>();
        IRepository<Client> repC = new EFRepository<Client>();

        // GET: Commandes
        public ActionResult Index()
        {
            return View(rep.Lister());
        }

        // GET: Commandes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commande commande = rep.Trouver((int)id);
            if (commande == null)
            {
                return HttpNotFound();
            }
            return View(commande);
        }

        // GET: Commandes/Create
        public ActionResult Create()
        {
            ViewBag.IdClient = new SelectList(repC.Lister().Select(c=>new { c.IdClient, c.NomClient }), "IdClient", "NomClient");
            return View();
        }

        // POST: Commandes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCommande,IdClient,DateCommande,DateLivraison,StateDeCommande")] Commande commande)
        {
            if (ModelState.IsValid)
            {
                rep.Ajouter(commande);
                return RedirectToAction("Index");
            }

            ViewBag.IdClient = new SelectList(repC.Lister().Select(c => new { c.IdClient, c.NomClient }), "IdClient", "NomClient", commande.IdClient);
            return View(commande);
        }

        // GET: Commandes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commande commande = rep.Trouver((int)id);
            if (commande == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClient = new SelectList(repC.Lister().Select(c=>new { c.IdClient, c.NomClient }), "IdClient", "NomClient", commande.IdClient);
            return View(commande);
        }

        // POST: Commandes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCommande,IdClient,DateCommande,DateLivraison,StateDeCommande")] Commande commande)
        {
            if (ModelState.IsValid)
            {
                rep.Modifier(commande);
                return RedirectToAction("Index");
            }
            ViewBag.IdClient = new SelectList(repC.Lister().Select(c => new { c.IdClient, c.NomClient }), "IdClient", "NomClient", commande.IdClient);
            return View(commande);
        }

        // GET: Commandes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commande commande = rep.Trouver((int)id);
            if (commande == null)
            {
                return HttpNotFound();
            }
            return View(commande);
        }

        // POST: Commandes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rep.Supprimer(id);
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
