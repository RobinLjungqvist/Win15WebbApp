using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebbApp.Areas.User.Controllers
{
    public class UserAccountController : Controller
    {
        // GET: User/UserAccount
        public ActionResult Index()
        {
            return View();
        }
    }
}