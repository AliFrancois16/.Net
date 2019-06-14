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
    public class ClientsController : Controller
    {
        IRepository<Client> rep = new EFRepository<Client>();

        // GET: Clients
        public ActionResult Index()
        {
            return View(rep.Lister());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = rep.Trouver((int)id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdClient,NomClient,EmailClient,AdresseClient,CodePostalClient,VilleClient,PaysClient,DateInscriptionClient,TelephoneClient,Theme,IsActive")] Client client)
        {
            if (ModelState.IsValid)
            {
                //client.IsActive = true;
                //client.DateInscriptionClient = DateTime.Now;
                //rep.Ajouter(client);

                    //var user = new ApplicationUser { UserName = client.EmailClient, Email = client.EmailClient };
                    //var result = await UserManager.CreateAsync(user, client.Password);
                    //if (result.Succeeded)
                    //{
                    //    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    //    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    //    // Send an email with this link
                    //    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    //    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    //    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    //    return RedirectToAction("Index", "Home");
                    //}
                    //AddErrors(result);


                // If we got this far, something failed, redisplay form
                return View(client);
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = rep.Trouver((int)id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdClient,NomClient,EmailClient,AdresseClient,CodePostalClient,VilleClient,PaysClient,DateInscriptionClient,TelephoneClient,Theme,IsActive")] Client client)
        {
            if (ModelState.IsValid)
            {
                rep.Modifier(client);
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = rep.Trouver(id.GetValueOrDefault());
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rep.Supprimer(id, "IsActive");
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
