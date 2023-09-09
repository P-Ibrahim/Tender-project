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
    public class OffersController : Controller
    {
        private TenderEntities db = new TenderEntities();
        private TenderEntities1 d = new TenderEntities1();

        // GET: Offers
        public ActionResult Index()
        {
            //var offers = db.Offers.Include(o => o.Contractors1).Include(o => o.Project);
            var offers=  d.c();
            return View(offers.ToList());
        }

        // GET: Offers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offer offer = db.Offers.Find(id);
            if (offer == null)
            {
                return HttpNotFound();
            }
            return View(offer);
        }

        // GET: Offers/Create
        public ActionResult Create()
        {
            ViewBag.C_Id = new SelectList(db.Contractors1, "Id", "Name");
            ViewBag.P_Id = new SelectList(db.Projects, "Id", "Details_file");
            return View();
        }

        // POST: Offers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,C_Id,P_Id,Price,Start_Date,End_Date,Status,Notes")] Offer offer)
        {
            if (ModelState.IsValid)
            {
                db.Offers.Add(offer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.C_Id = new SelectList(db.Contractors1, "Id", "Name", offer.C_Id);
            ViewBag.P_Id = new SelectList(db.Projects, "Id", "Details_file", offer.P_Id);
            return View(offer);
        }

        // GET: Offers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offer offer = db.Offers.Find(id);
            if (offer == null)
            {
                return HttpNotFound();
            }
            ViewBag.C_Id = new SelectList(db.Contractors1, "Id", "Name", offer.C_Id);
            ViewBag.P_Id = new SelectList(db.Projects, "Id", "Details_file", offer.P_Id);
            return View(offer);
        }

        // POST: Offers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,C_Id,P_Id,Price,Start_Date,End_Date,Status,Notes")] Offer offer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.C_Id = new SelectList(db.Contractors1, "Id", "Name", offer.C_Id);
            ViewBag.P_Id = new SelectList(db.Projects, "Id", "Details_file", offer.P_Id);
            return View(offer);
        }

        // GET: Offers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offer offer = db.Offers.Find(id);
            if (offer == null)
            {
                return HttpNotFound();
            }
            return View(offer);
        }

        // POST: Offers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Offer offer = db.Offers.Find(id);
            db.Offers.Remove(offer);
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
