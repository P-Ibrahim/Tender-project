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
    public class StakeholdersController : Controller
    {
        private TenderEntities db = new TenderEntities();

        // GET: Stakeholders
        public ActionResult Index()
        {
            return View(db.Stakeholders.ToList());
        }

        // GET: Stakeholders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stakeholder stakeholder = db.Stakeholders.Find(id);
            if (stakeholder == null)
            {
                return HttpNotFound();
            }
            return View(stakeholder);
        }

        // GET: Stakeholders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stakeholders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Phone,Address")] Stakeholder stakeholder)
        {
            if (ModelState.IsValid)
            {
                db.Stakeholders.Add(stakeholder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stakeholder);
        }

        // GET: Stakeholders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stakeholder stakeholder = db.Stakeholders.Find(id);
            if (stakeholder == null)
            {
                return HttpNotFound();
            }
            return View(stakeholder);
        }

        // POST: Stakeholders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Phone,Address")] Stakeholder stakeholder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stakeholder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stakeholder);
        }

        // GET: Stakeholders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stakeholder stakeholder = db.Stakeholders.Find(id);
            if (stakeholder == null)
            {
                return HttpNotFound();
            }
            return View(stakeholder);
        }

        // POST: Stakeholders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stakeholder stakeholder = db.Stakeholders.Find(id);
            db.Stakeholders.Remove(stakeholder);
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
