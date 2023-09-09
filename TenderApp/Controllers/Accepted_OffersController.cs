using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TenderApp.Models;

namespace TenderApp.Controllers
{
    public class Accepted_OffersController : Controller
    {
        private TenderEntities db = new TenderEntities();

        // GET: Accepted_Offers
        public ActionResult Index()
        {
            var accepted_Offers = db.Accepted_Offers.Include(a => a.Offer);
            return View(accepted_Offers.ToList());
        }

        // GET: Accepted_Offers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accepted_Offers accepted_Offers = db.Accepted_Offers.Find(id);
            if (accepted_Offers == null)
            {
                return HttpNotFound();
            }
            return View(accepted_Offers);
        }

        // GET: Accepted_Offers/Create
        public ActionResult Create()
        {
            ViewBag.Off_Id = new SelectList(db.Offers, "Id", "Status");
            return View();
        }

        // POST: Accepted_Offers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Off_Id")] Accepted_Offers accepted_Offers)
        {
            if (ModelState.IsValid)
            {
                db.Accepted_Offers.Add(accepted_Offers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Off_Id = new SelectList(db.Offers, "Id", "Status", accepted_Offers.Off_Id);
            return View(accepted_Offers);
        }

        // GET: Accepted_Offers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accepted_Offers accepted_Offers = db.Accepted_Offers.Find(id);
            if (accepted_Offers == null)
            {
                return HttpNotFound();
            }
            ViewBag.Off_Id = new SelectList(db.Offers, "Id", "Status", accepted_Offers.Off_Id);
            return View(accepted_Offers);
        }

        // POST: Accepted_Offers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Off_Id")] Accepted_Offers accepted_Offers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accepted_Offers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Off_Id = new SelectList(db.Offers, "Id", "Status", accepted_Offers.Off_Id);
            return View(accepted_Offers);
        }

        // GET: Accepted_Offers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accepted_Offers accepted_Offers = db.Accepted_Offers.Find(id);
            if (accepted_Offers == null)
            {
                return HttpNotFound();
            }
            return View(accepted_Offers);
        }

        // POST: Accepted_Offers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accepted_Offers accepted_Offers = db.Accepted_Offers.Find(id);
            db.Accepted_Offers.Remove(accepted_Offers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
