using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebbApp.DAL.DB.Models;
using static WebbApp.App_Start.IdentityConfig;
using WebbApp.DAL;

namespace WebbApp.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string AddUser()
        {
            ApplicationUser user;
            ApplicationUserStore Store = new ApplicationUserStore(new ApplicationContext());
            ApplicationUserManager userManager = new ApplicationUserManager(Store);
            user = new ApplicationUser
            {
                UserName = "TestUser",
                Email = "TestUser@test.com"
            };

            var result = userManager.Create(user);
            if (!result.Succeeded)
            {
                return result.Errors.First();
            }
            return "User Added";
        }
    }
}