using DoAnWebFilm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PagedList;
using PagedList.Mvc;

namespace DoAnWebFilm.Controllers
{
    public class HomeController : Controller
    {

        dbWebFilmDataContext db = new dbWebFilmDataContext();
        private List<PHIM> themphim(int count)
        {
            return db.PHIMs.OrderByDescending(a => a.ID_PHIM).Take(count).ToList();
        }
        public ActionResult index(int ? page)
        {
            int pageSize = 12;
            int pageNum = (page ?? 1);

            var indexfilm = themphim(25);
            return View(indexfilm.ToPagedList(pageNum,pageSize));
        }
        public ActionResult LuotXem(int id)
        {
            PHIM phim = db.PHIMs.SingleOrDefault(n => n.ID_PHIM == id);

            phim.LuotXem += 1;
            UpdateModel(phim);
            db.SubmitChanges();
            var id1 = phim.ID_PHIM;
            return RedirectToAction("watchFilm/"+id1, "Home");
        }
        public ActionResult Details(int id)
        {
            var deltaisfilm = from df in db.PHIMs
                       where df.ID_PHIM == id
                       select df;
            return View(deltaisfilm.Single());
        }
        public ActionResult watchFilm(int id)
        {
            var watchfilm = from w in db.PHIMs
                       where w.ID_PHIM == id
                       select w;
            return View(watchfilm.Single());
        }

        public ActionResult filmType()
        {
            var type = from t in db.LOAIs select t;
            return PartialView(type);
        }
        public ActionResult filmInType(int id, int? page)
        {
            int pageSize = 12;
            int pageNum = (page ?? 1);
            var filmintype = from fit in db.PHIMs join ct in db.CHITIETLOAIs on fit.ID_PHIM equals ct.ID_PHIM where ct.IDLOAI == id select fit ;
            return View(filmintype.ToPagedList(pageNum, pageSize));
        }

        public ActionResult nation()
        {
            var nation = from n in db.QUOCGIAs select n;
            return PartialView(nation);
        }
        public ActionResult filmNation(int id, int? page)
        {
            int pageSize = 12;
            int pageNum = (page ?? 1);
            var filmnation = from fn in db.PHIMs where fn.ID_QG == id select fn;
            return View(filmnation.ToPagedList(pageNum, pageSize));

        }

        public ActionResult filmYear()
        {
            var filmYear = from fy in db.NAMPHATHANHs select fy;
            return PartialView(filmYear);
        }
        public ActionResult filmInYear(int id,int? page)
        {
            int pageSize = 12;
            int pageNum = (page ?? 1);
            var filminyear = from fiy in db.PHIMs where fiy.ID_NAM == id select fiy;
            return View(filminyear.ToPagedList(pageNum, pageSize));
        }
        public ActionResult phimHot()
        {
            var phimhot = themphim(5);
            return PartialView(phimhot);
        }
        public ActionResult binhLuan(int id)
        {
            var bluan = from bl in db.BINHLUANs where bl.ID_PHIM == id select bl;
            return PartialView(bluan);
        }
        [HttpPost]
        public ActionResult createBinhLuan(BINHLUAN binhLuan)
        {
            DateTime localDate = DateTime.Now;
            var id = binhLuan.ID_PHIM;
            binhLuan.NGAY_BINHLUAN = localDate;
            db.BINHLUANs.InsertOnSubmit(binhLuan);
            db.SubmitChanges();
            return RedirectToAction("watchFilm/"+id);
        }
    }
}