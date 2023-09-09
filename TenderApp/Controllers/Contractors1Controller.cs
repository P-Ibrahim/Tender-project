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
    public class Contractors1Controller : Controller
    {
        private TenderEntities db = new TenderEntities();

        // GET: Contractors1
        public ActionResult Index()
        {
            return View(db.Contractors1.ToList());
        }

        // GET: Contractors1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contractors1 contractors1 = db.Contractors1.Find(id);
            if (contractors1 == null)
            {
                return HttpNotFound();
            }
            return View(contractors1);
        }

        // GET: Contractors1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contractors1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Phone,Commercial_Record,Address")] Contractors1 contractors1)
        {
            if (ModelState.IsValid)
            {
                db.Contractors1.Add(contractors1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contractors1);
        }

        // GET: Contractors1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contractors1 contractors1 = db.Contractors1.Find(id);
            if (contractors1 == null)
            {
                return HttpNotFound();
            }
            return View(contractors1);
        }

        // POST: Contractors1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Phone,Commercial_Record,Address")] Contractors1 contractors1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contractors1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contractors1);
        }

        // GET: Contractors1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contractors1 contractors1 = db.Contractors1.Find(id);
            if (contractors1 == null)
            {
                return HttpNotFound();
            }
            return View(contractors1);
        }

        // POST: Contractors1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contractors1 contractors1 = db.Contractors1.Find(id);
            db.Contractors1.Remove(contractors1);
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
