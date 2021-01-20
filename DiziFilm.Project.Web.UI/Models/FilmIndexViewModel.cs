using System.Collections.Generic;
using DiziFilm.Project.Entities.Concrete;

namespace DiziFilm.Project.Web.UI.Models
{
    public class FilmIndexViewModel
    {
        public Film Film { get; set; }

        public List<Film> FilmListesi { get; set; }
    }
}
