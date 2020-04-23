using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        UserManagementDbEntities db = new UserManagementDbEntities();
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Users user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Login", "Securty");
        }
    }
}