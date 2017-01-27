using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebbApp.Controllers
{
    public class ErrorPageController : Controller
    {
        // GET: ErrorPage
        public ActionResult Error()
        {
            return View();
        }
        
        public ActionResult NotFoundError()
        {
            return View();
        }
        public ActionResult InternalError()
        {
            return View();
        }
    }
}