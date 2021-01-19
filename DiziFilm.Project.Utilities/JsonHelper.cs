using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DiziFilm.Core.Aspects.Autofac.Exception;
using DiziFilm.Core.Aspects.Autofac.Logging;
using DiziFilm.Core.Aspects.Postsharp.ValidationAspects;
using DiziFilm.Project.Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace DiziFilm.Project.Utilities
{

    public class JsonHelper
    {
        
        private IHostingEnvironment _hostingEnvironment;

        public JsonHelper(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        
        [ExceptionLogAspect]
        [LogAspect]
        public void Insert(Film film)
        {
            
            string rootPath = _hostingEnvironment.ContentRootPath;
            
            rootPath = rootPath.Split("DiziFilm\\")[0] + "DiziFilm\\";
            
            string jsonFile = Path.Combine(rootPath + "DiziFilm.Project.Web.UI\\wwwroot", "files/dizifilm.json");
            
            string jsonString = System.IO.File.ReadAllText(jsonFile);

            using (StreamWriter sw = new StreamWriter(jsonFile))
            {
                List<Film> jsonData2 = JsonConvert.DeserializeObject<List<Film>>(jsonString);

                Film yeni = new Film();

                yeni.Category = film.Category;

                yeni.Detail = film.Detail;

                yeni.Fragman = film.Fragman;

                yeni.Name = film.Name;

                yeni.id = Guid.NewGuid().ToString();

                jsonData2.Add(yeni);

                string yeniJson = JsonConvert.SerializeObject(jsonData2);

                sw.Write(yeniJson);

                sw.Close();

                sw.Dispose();

            }

        }

        [ExceptionLogAspect]
        [LogAspect]
        public void Update(Film film)
        {
            string rootPath = _hostingEnvironment.ContentRootPath;
            rootPath = rootPath.Split("DiziFilm\\")[0] + "DiziFilm\\";
            string jsonFile = Path.Combine(rootPath + "DiziFilm.Project.Web.UI\\wwwroot", "files/dizifilm.json");
            
            string jsonString = System.IO.File.ReadAllText(jsonFile);

            using (StreamWriter sw = new StreamWriter(jsonFile))
            {
                List<Film> jsonData4 = JsonConvert.DeserializeObject<List<Film>>(jsonString);

                var guncellenecekFilm = jsonData4.SingleOrDefault(x => x.id == film.id);

                guncellenecekFilm.Category = film.Category;

                guncellenecekFilm.Detail = film.Detail;

                guncellenecekFilm.Fragman = film.Fragman;

                guncellenecekFilm.Name = film.Name;

                guncellenecekFilm.id = film.id;

                string yeniJson3 = JsonConvert.SerializeObject(jsonData4);

                sw.Write(yeniJson3);

                sw.Close();

                sw.Dispose();
            }

        }

        [ExceptionLogAspect]
        [LogAspect]
        public void Delete(Film film)
        {
            string rootPath = _hostingEnvironment.ContentRootPath;

            rootPath = rootPath.Split("DiziFilm\\")[0] + "DiziFilm\\";

            string jsonFile = Path.Combine(rootPath + "DiziFilm.Project.Web.UI\\wwwroot", "files/dizifilm.json");
            
            string jsonString = System.IO.File.ReadAllText(jsonFile);

            using (StreamWriter sw = new StreamWriter(jsonFile))
            {
                List<Film> jsonData3 = JsonConvert.DeserializeObject<List<Film>>(jsonString);

                Film silinecekFilm = jsonData3.SingleOrDefault(x => x.id == film.id);

                jsonData3.Remove(silinecekFilm);

                string yeniJson2 = JsonConvert.SerializeObject(jsonData3);

                sw.Write(yeniJson2);

                sw.Close();

                sw.Dispose();
            }

        }
        
    }
}
