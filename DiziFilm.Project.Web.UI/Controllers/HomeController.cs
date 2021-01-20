using System.Collections.Generic;
using System.IO;
using System.Linq;
using DiziFilm.Project.Entities.Concrete;
using DiziFilm.Project.Web.UI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DiziFilm.Project.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("")]
        public IActionResult Index()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;

            string jsonFile = Path.Combine(webRootPath, "files/dizifilm.json");

            string jsonString = System.IO.File.ReadAllText(jsonFile);

            List<Film> films = JsonConvert.DeserializeObject<List<Film>>(jsonString).ToList();

            HomeWebUIViewModel homeWebUiViewModel = new HomeWebUIViewModel()
            {
                FilmIndexViewModel = new FilmIndexViewModel()
                {
                    FilmListesi = films
                }
            };

            return View(homeWebUiViewModel);
        }
        
    }
}
