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
    public class CourseController : Controller
    {
        private StudentManagementDBEntities db = new StudentManagementDBEntities();

        // GET: Course
        public ActionResult Index()
        {
            return View(db.tblCourses.ToList());
        }

        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCourse tblCourse = db.tblCourses.Find(id);
            if (tblCourse == null)
            {
                return HttpNotFound();
            }
            return View(tblCourse);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,Course,Duration")] tblCourse tblCourse)
        {
            if (ModelState.IsValid)
            {
                db.tblCourses.Add(tblCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblCourse);
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCourse tblCourse = db.tblCourses.Find(id);
            if (tblCourse == null)
            {
                return HttpNotFound();
            }
            return View(tblCourse);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,Course,Duration")] tblCourse tblCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblCourse);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCourse tblCourse = db.tblCourses.Find(id);
            if (tblCourse == null)
            {
                return HttpNotFound();
            }
            return View(tblCourse);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCourse tblCourse = db.tblCourses.Find(id);
            db.tblCourses.Remove(tblCourse);
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
