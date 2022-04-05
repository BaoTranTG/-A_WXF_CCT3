using DoAnWebFilm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebFilm.Controllers
{
    public class PhimSapChieuController : Controller
    {
        dbWebFilmDataContext db = new dbWebFilmDataContext();
        private List<PHIMSAPCHIEU> themphim(int count)
        {
            return db.PHIMSAPCHIEUs.OrderByDescending(a => a.ID_PHIMSP).Take(count).ToList();
        }
        public ActionResult phimSapChieu()
        {
            var phimsp = themphim(6);
            return PartialView(phimsp);
        }

    }
}