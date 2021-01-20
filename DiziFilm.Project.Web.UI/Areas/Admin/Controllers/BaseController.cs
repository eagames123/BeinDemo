using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DiziFilm.Project.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string path = context.HttpContext.Request.Path;

            if (HttpContext.Session.GetString("KAd") == null)
            {
                context.Result = RedirectToAction("Index", "AdminLogin");
            }
            else
            {
                base.OnActionExecuting(context);
            }
        }

    }
}
