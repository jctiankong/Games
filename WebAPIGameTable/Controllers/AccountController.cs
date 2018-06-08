using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPIGameTable.Models;

namespace WebAPIGameTable.Controllers
{
    public class AccountController : Controller
    {
        private WebAPIGameTableContext db = new WebAPIGameTableContext();
        // GET: Account
        public ActionResult Index()
        {
            return View(db.UserAccounts.ToList());
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if( ModelState.IsValid )
            {
                db.UserAccounts.Add(account);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.Massage = account.FirstName + " " + account.LastName + " successfully reg ";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            var usr = db.UserAccounts.Single(u => u.Username == user.Username && u.Password == user.Password);
            if (usr != null)
            {
                Session["UserID"] = usr.UserID.ToString();
                Session["Username"] = usr.Username.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Username or Password is wrong");
            }
            return View();
        } 
        public ActionResult LoggenIn()
        {
            if( Session["UserId"] != null )
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
            
        }
    
}