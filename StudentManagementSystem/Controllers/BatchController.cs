using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class BatchController : Controller
    {
        private StudentManagementDBEntities db = new StudentManagementDBEntities();

        // GET: Batch
        public ActionResult Index()
        {
            return View(db.tblBatches.ToList());
        }

        // GET: Batch/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBatch tblBatch = db.tblBatches.Find(id);
            if (tblBatch == null)
            {
                return HttpNotFound();
            }
            return View(tblBatch);
        }

        // GET: Batch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Batch/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,Batch,Year")] tblBatch tblBatch)
        {
            if (ModelState.IsValid)
            {
                db.tblBatches.Add(tblBatch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblBatch);
        }

        // GET: Batch/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBatch tblBatch = db.tblBatches.Find(id);
            if (tblBatch == null)
            {
                return HttpNotFound();
            }
            return View(tblBatch);
        }

        // POST: Batch/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,Batch,Year")] tblBatch tblBatch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblBatch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblBatch);
        }

        // GET: Batch/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBatch tblBatch = db.tblBatches.Find(id);
            if (tblBatch == null)
            {
                return HttpNotFound();
            }
            return View(tblBatch);
        }

        // POST: Batch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblBatch tblBatch = db.tblBatches.Find(id);
            db.tblBatches.Remove(tblBatch);
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
