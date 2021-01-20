using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace DiziFilm.Project.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminLoginController : Controller
    {

        [Route("giris")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("kontrol")]
        [HttpPost]
        public IActionResult LoginUser(string username, string password)
        {
            if (username=="admin"&&password=="1")
            {
                HttpContext.Session.SetString("KAd", $"{username}");

                string sessionUserName= HttpContext.Session.GetString("KAd");

                return RedirectToAction("Index", "HomeAdmin");
            }
            return RedirectToAction("Index", "AdminLogin");
        }

        [Route("cikis")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Kad");

            HttpContext.Session.Clear();

            return RedirectToAction("Index", "AdminLogin");
        }

    }
}
