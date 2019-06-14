using DataBase;
using DataBase.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Produit> rep = new EFRepository<Produit>();
        IRepository<Fournisseur> repF = new EFRepository<Fournisseur>();
        IRepository<Avi> repA = new EFHome();

        public ActionResult Index()
        {
            if (Session["id"]!= null)
            {
                EFClients rep = new EFClients();
                var client = rep.Trouver((int)Session["id"]);
                Session["theme"] = client.Theme;
                
            }
            
            return View(rep.Lister());
        }
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
            ViewBag.Fournisseur = repF.Trouver((int)produit.IdFournisseur).NomFournisseur;
            ViewBag.Avis = (object)((EFHome)repA).ListActiveAvis((int)id);

            return View(produit);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page SALAM.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}