using System.Collections.Generic;
using System.IO;
using System.Linq;
using DiziFilm.Project.Entities.Concrete;
using DiziFilm.Project.Web.UI.Areas.Admin.Models;
using DiziFilm.Project.Web.UI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DiziFilm.Project.Web.UI.Controllers
{
    public class FilmController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FilmController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("filmler")]
        public IActionResult Index()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;

            string jsonFile = Path.Combine(webRootPath, "files/dizifilm.json");

            string jsonString = System.IO.File.ReadAllText(jsonFile);

            List<Film> films = JsonConvert.DeserializeObject<List<Film>>(jsonString).ToList();

            FilmIndexViewModel filmIndexViewModel = new FilmIndexViewModel()
            {
                FilmListesi = films
            };

            return View(filmIndexViewModel);
        }

        [Route("detay")]
        public IActionResult Detail(string id)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;

            string jsonFile = Path.Combine(webRootPath, "files/dizifilm.json");

            string jsonString = System.IO.File.ReadAllText(jsonFile);

            List<Film> jsonData4 = JsonConvert.DeserializeObject<List<Film>>(jsonString);

            Film film = jsonData4.SingleOrDefault(x => x.id == id);

            FilmIndexViewModel homeViewIndexModel = new FilmIndexViewModel()
            {
                Film = film
            };

            return View(homeViewIndexModel);
        }

    }
}
