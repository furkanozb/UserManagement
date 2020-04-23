using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserManagement.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult AdminPage()
        {
            return View();
        }

        public ActionResult StandartUserPage()
        {
            return View();
        }
    }
}