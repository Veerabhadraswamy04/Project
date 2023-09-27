using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;

namespace StudentManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        StudentManagementDBEntities db = new StudentManagementDBEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(tblUser objchk)
        {
            if(ModelState.IsValid)
            {
                using (StudentManagementDBEntities db = new StudentManagementDBEntities())
                {
                    var obj = db.tblUsers.Where(a => a.UserName.Equals(objchk.UserName) && a.Password.Equals(objchk.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserId"] = obj.UserId.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("","The username or password incorrect");
                    }
                }
                
            } 
            
            return View(objchk); 
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}