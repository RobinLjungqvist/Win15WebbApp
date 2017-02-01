using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebbApp.Areas.Admin.Controllers
{
    public class ExpiredController : Controller
    {
        // GET: Admin/Expired
        public ActionResult Index()
        {
            return View();
        }
    }
}