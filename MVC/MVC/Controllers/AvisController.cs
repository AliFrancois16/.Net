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
    public class AvisController : Controller
    {
        IRepository<Avi> rep = new EFRepository<Avi>();
        IRepository<Client> repC = new EFRepository<Client>();
        IRepository<Produit> repP = new EFRepository<Produit>();

        // GET: Avis
        public ActionResult Index()
        {
            ViewBag.IdClient = new SelectList(repC.Lister().Select(c => new { c.IdClient, c.NomClient }), "IdClient", "NomClient");
            ViewBag.IdProduit = new SelectList(repP.Lister().Select(p => new { p.IdProduit, p.NomProduit }), "IdProduit", "NomProduit");
            return View(rep.Lister());
        }

        // GET: Avis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avi avi = rep.Trouver((int)id);
            if (avi == null)
            {
                return HttpNotFound();
            }
            return View(avi);
        }

        // GET: Avis/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.IdClient = new SelectList(repC.Lister().Select(c=> new { c.IdClient, c.NomClient }), "IdClient", "NomClient");
            ViewBag.IdProduit = new SelectList(repP.Lister().Select(p=> new { p.IdProduit, p.NomProduit }), "IdProduit", "NomProduit");
            ViewBag.Id = id;
            return View();
        }

        // POST: Avis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAvis,IdClient,IdProduit,TexteAvis,NoteAvis,DateAvis,IsPublie")] Avi avi)
        {
            if (ModelState.IsValid)
            {
                avi.DateAvis = DateTime.Now;
                avi.IsPublie = false;
                avi.IdClient = int.Parse(Session["id"].ToString());
                rep.Ajouter(avi);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.IdClient = new SelectList(repC.Lister().Select(c=> new { c.IdClient, c.NomClient }), "IdClient", "NomClient", avi.IdClient);
            ViewBag.IdProduit = new SelectList(repP.Lister().Select(p=>new { p.IdProduit, p.NomProduit }), "IdProduit", "NomProduit", avi.IdProduit);
            return View(avi);
        }

        // GET: Avis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avi avi = rep.Trouver((int)id);
            if (avi == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClient = new SelectList(repC.Lister().Select(c => new { c.IdClient, c.NomClient }), "IdClient", "NomClient", avi.IdClient);
            ViewBag.IdProduit = new SelectList(repP.Lister().Select(p => new { p.IdProduit, p.NomProduit }), "IdProduit", "NomProduit", avi.IdProduit);
            return View(avi);
        }

        // POST: Avis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAvis,IdClient,IdProduit,TexteAvis,NoteAvis,DateAvis,IsPublie")] Avi avi)
        {
            if (ModelState.IsValid)
            {
                rep.Modifier(avi);
                return RedirectToAction("Index");
            }
            ViewBag.IdClient = new SelectList(repC.Lister().Select(c => new { c.IdClient, c.NomClient }), "IdClient", "NomClient", avi.IdClient);
            ViewBag.IdProduit = new SelectList(repP.Lister().Select(p => new { p.IdProduit, p.NomProduit }), "IdProduit", "NomProduit", avi.IdProduit);
            return View(avi);
        }

        // GET: Avis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avi avi = rep.Trouver((int)id);
            if (avi == null)
            {
                return HttpNotFound();
            }
            return View(avi);
        }

        // POST: Avis/Delete/5
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
