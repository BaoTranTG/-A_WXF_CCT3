using DoAnWebFilm.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebFilm.Controllers
{
    public class SearchController : Controller
    {
        dbWebFilmDataContext db = new dbWebFilmDataContext();
        // GET: Search
        public ActionResult searchFilm(String searchfilm, int? page)
        {
            int pageSize = 12;
            int pageNum = (page ?? 1);

            var search = from s in db.PHIMs
                         where s.TEN_PHIM.Contains(searchfilm)
                         select s;
            return View(search.ToPagedList(pageNum, pageSize));
        }
    }
}