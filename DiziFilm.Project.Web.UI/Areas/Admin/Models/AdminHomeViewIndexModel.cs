using System.Collections.Generic;
using DiziFilm.Project.Entities.Concrete;

namespace DiziFilm.Project.Web.UI.Areas.Admin.Models
{
    public class AdminHomeViewIndexModel
    {
        public string sessionName { get; set; }

        public Film Film { get; set; }

        public List<Film> FilmListesi { get; set; }
    }
}
