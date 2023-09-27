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
    public class RegistrationController : Controller
    {
        private StudentManagementDBEntities db = new StudentManagementDBEntities();

        // GET: Registration
        public ActionResult Index()
        {
            var tblRegistrations = db.tblRegistrations.Include(t => t.tblBatch).Include(t => t.tblCourse);
            return View(tblRegistrations.ToList());
        }

        // GET: Registration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRegistration tblRegistration = db.tblRegistrations.Find(id);
            if (tblRegistration == null)
            {
                return HttpNotFound();
            }
            return View(tblRegistration);
        }

        // GET: Registration/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.tblBatches, "CourseId", "Batch");
            ViewBag.StudentId = new SelectList(db.tblCourses, "StudentId", "Course");
            return View();
        }

        // POST: Registration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegisterId,FirstName,LastName,CourseId,StudentId,MobileNo")] tblRegistration tblRegistration)
        {
            if (ModelState.IsValid)
            {
                db.tblRegistrations.Add(tblRegistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.tblBatches, "CourseId", "Batch", tblRegistration.CourseId);
            ViewBag.StudentId = new SelectList(db.tblCourses, "StudentId", "Course", tblRegistration.StudentId);
            return View(tblRegistration);
        }

        // GET: Registration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRegistration tblRegistration = db.tblRegistrations.Find(id);
            if (tblRegistration == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.tblBatches, "CourseId", "Batch", tblRegistration.CourseId);
            ViewBag.StudentId = new SelectList(db.tblCourses, "StudentId", "Course", tblRegistration.StudentId);
            return View(tblRegistration);
        }

        // POST: Registration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegisterId,FirstName,LastName,CourseId,StudentId,MobileNo")] tblRegistration tblRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.tblBatches, "CourseId", "Batch", tblRegistration.CourseId);
            ViewBag.StudentId = new SelectList(db.tblCourses, "StudentId", "Course", tblRegistration.StudentId);
            return View(tblRegistration);
        }

        // GET: Registration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRegistration tblRegistration = db.tblRegistrations.Find(id);
            if (tblRegistration == null)
            {
                return HttpNotFound();
            }
            return View(tblRegistration);
        }

        // POST: Registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblRegistration tblRegistration = db.tblRegistrations.Find(id);
            db.tblRegistrations.Remove(tblRegistration);
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
