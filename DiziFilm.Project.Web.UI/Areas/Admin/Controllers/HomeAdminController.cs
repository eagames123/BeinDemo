using System.Collections.Generic;
using System.IO;
using System.Linq;
using DiziFilm.Core;
using DiziFilm.Core.Aspects.Postsharp;
using DiziFilm.Core.Aspects.Postsharp.ValidationAspects;
using DiziFilm.Core.Utilities;
using DiziFilm.Project.Business.ValidationRules.FluentValidation;
using DiziFilm.Project.Entities.Concrete;
using DiziFilm.Project.Utilities;
using DiziFilm.Project.Web.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DiziFilm.Project.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeAdminController : BaseController
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        
        public HomeAdminController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("homeadmin")]
        public IActionResult Index()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            
            string jsonFile = Path.Combine(webRootPath, "files/dizifilm.json");

            string jsonString = System.IO.File.ReadAllText(jsonFile);

            List<Film> films = JsonConvert.DeserializeObject<List<Film>>(jsonString).ToList();

            ////data ekle
            //using (StreamWriter sw = new StreamWriter(jsonFile))
            //{
            //    List<Entities.Concrete.DiziFilm> jsonData2 = JsonConvert.DeserializeObject<List<Entities.Concrete.DiziFilm>>(jsonString);
            //    Entities.Concrete.DiziFilm yeni = new Entities.Concrete.DiziFilm();
            //    yeni.Category = "yeniAhmetABC";
            //    yeni.Detail = "yeniAhmetABC";
            //    yeni.Fragman = "yeniAhmetABC";
            //    yeni.Name = "yeniAhmetABC";
            //    jsonData2.Add(yeni);
            //    string yeniJson = JsonConvert.SerializeObject(jsonData2);

            //    sw.Write(yeniJson);
            //    sw.Close();
            //    sw.Dispose();
            //}


            ////data sil
            //jsonString = System.IO.File.ReadAllText(jsonFile);
            //using (StreamWriter sw = new StreamWriter(jsonFile))
            //{
            //    List<Entities.Concrete.DiziFilm> jsonData3 = JsonConvert.DeserializeObject<List<Entities.Concrete.DiziFilm>>(jsonString);
            //    var silinecekFilm = jsonData3.SingleOrDefault(x => x.Name == "yeniAhmetSil");
            //    jsonData3.Remove(silinecekFilm);
            //    string yeniJson2 = JsonConvert.SerializeObject(jsonData3);

            //    sw.Write(yeniJson2);
            //    sw.Close();
            //    sw.Dispose();
            //}

            ////data güncelle
            //jsonString = System.IO.File.ReadAllText(jsonFile);
            //using (StreamWriter sw = new StreamWriter(jsonFile))
            //{
            //    List<Entities.Concrete.DiziFilm> jsonData4 = JsonConvert.DeserializeObject<List<Entities.Concrete.DiziFilm>>(jsonString);
            //    var guncellenecekFilm = jsonData4.SingleOrDefault(x => x.Name == "guncelee");
            //    guncellenecekFilm.Category = "aa";
            //    guncellenecekFilm.Detail = "aa";
            //    guncellenecekFilm.Fragman = "aa";
            //    guncellenecekFilm.Name = "aa";
            //    string yeniJson3 = JsonConvert.SerializeObject(jsonData4);

            //    sw.Write(yeniJson3);
            //    sw.Close();
            //    sw.Dispose();
            //}

            TempData["username"] = HttpContext.Session.GetString("KAd");

            string kullaniciAdi = HttpContext.Session.GetString("KAd");

            AdminHomeViewIndexModel homeViewIndexModel = new AdminHomeViewIndexModel()
            {
                sessionName = kullaniciAdi,
                FilmListesi = films
            };

            return View(homeViewIndexModel);
        }

        [Route("createfilmpage")]
        public IActionResult AddNewFilm()
        {
            TempData["username"] = HttpContext.Session.GetString("KAd");

            string kullaniciAdi = HttpContext.Session.GetString("KAd");

            Film film = new Film();

            AdminHomeViewIndexModel homeViewIndexModel = new AdminHomeViewIndexModel()
            {
                sessionName = kullaniciAdi,
                Film = film
            };

            return View(homeViewIndexModel);
        }
        
        [Route("createfilm")]
        [HttpPost]
        public IActionResult AddNewFilmCreate(Film film)
        {
            JsonHelper jsonHelper = new JsonHelper(_hostingEnvironment);

            jsonHelper.Insert(film);

            LogBeinHelper logHelper = new LogBeinHelper(_hostingEnvironment);

            logHelper.Insert("insert", Layer.Admin);

            return RedirectToAction("Index", "HomeAdmin");
        }

        [Route("updatefilmpage")]
        public IActionResult UpdateFilmPage(string id)
        {
            TempData["username"] = HttpContext.Session.GetString("KAd");

            string kullaniciAdi = HttpContext.Session.GetString("KAd");

            string webRootPath = _hostingEnvironment.WebRootPath;

            string jsonFile = Path.Combine(webRootPath, "files/dizifilm.json");

            string jsonString = System.IO.File.ReadAllText(jsonFile);

            List<Film> jsonData4 = JsonConvert.DeserializeObject<List<Film>>(jsonString);

            Film guncellenecekFilm = jsonData4.SingleOrDefault(x => x.id == id);

            AdminHomeViewIndexModel homeViewIndexModel = new AdminHomeViewIndexModel()
            {
                sessionName = kullaniciAdi,
                Film = guncellenecekFilm
            };

            return View(homeViewIndexModel);
        }

        [Route("updatefilm")]
        [HttpPost]
        public IActionResult UpdateFilm(Film film)
        {
            JsonHelper jsonHelper = new JsonHelper(_hostingEnvironment);

            jsonHelper.Update(film);

            LogBeinHelper logHelper = new LogBeinHelper(_hostingEnvironment);

            logHelper.Insert("update", Layer.Admin);
            
            return RedirectToAction("Index", "HomeAdmin");
        }

        [Route("deletefilmpage")]
        public IActionResult DeleteFilmPage(string id)
        {
            TempData["username"] = HttpContext.Session.GetString("KAd");

            string kullaniciAdi = HttpContext.Session.GetString("KAd");

            string webRootPath = _hostingEnvironment.WebRootPath;

            string jsonFile = Path.Combine(webRootPath, "files/dizifilm.json");

            string jsonString = System.IO.File.ReadAllText(jsonFile);

            List<Film> jsonData4 = JsonConvert.DeserializeObject<List<Film>>(jsonString);

            Film silinecekFilm = jsonData4.SingleOrDefault(x => x.id == id);

            AdminHomeViewIndexModel homeViewIndexModel = new AdminHomeViewIndexModel()
            {
                sessionName = kullaniciAdi,
                Film = silinecekFilm
            };

            return View(homeViewIndexModel);
        }

        [Route("deletefilm")]
        [HttpPost]
        public IActionResult DeleteFilm(Film film)
        {
            //string webRootPath = _hostingEnvironment.WebRootPath;

            //string jsonFile = Path.Combine(webRootPath, "files/dizifilm.json");

            //string jsonString = System.IO.File.ReadAllText(jsonFile);

            //using (StreamWriter sw = new StreamWriter(jsonFile))
            //{
            //    List<Film> jsonData3 = JsonConvert.DeserializeObject<List<Film>>(jsonString);

            //    Film silinecekFilm = jsonData3.SingleOrDefault(x => x.id == film.id);

            //    jsonData3.Remove(silinecekFilm);

            //    string yeniJson2 = JsonConvert.SerializeObject(jsonData3);

            //    sw.Write(yeniJson2);

            //    sw.Close();

            //    sw.Dispose();
            //}

            JsonHelper jsonHelper = new JsonHelper(_hostingEnvironment);

            jsonHelper.Delete(film);

            LogBeinHelper logHelper = new LogBeinHelper(_hostingEnvironment);

            logHelper.Insert("delete", Layer.Admin);

            return RedirectToAction("Index", "HomeAdmin");
        }

    }
}
