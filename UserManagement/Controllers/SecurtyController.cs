using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    [AllowAnonymous]
    public class SecurtyController : Controller
    {
        UserManagementDbEntities db = new UserManagementDbEntities();
        // GET: Securty
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users user)
        {
            var userInDb = db.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            if (userInDb != null)
            {
                if (userInDb.RoleId == 1)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("AdminPage", "Home");

                }
                else
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("StandartUserPage", "Home");

                }
            }
            else
            {
                ViewBag.message = "Geçersiz Kullanıcı yada şifre";
                return View();
            }
        }

        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}