using DoAnWebFilm.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebFilm.Areas.Admin.Controllers
{
    public class AdminBinhLuanController : Controller
    {
        dbWebFilmDataContext db = new dbWebFilmDataContext();
        public ActionResult Index(int? page)
        {
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.BINHLUANs.ToList().OrderBy(n => n.ID_BINHLUAN).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Search(String search, int? page)
        {
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }

            int pageNumber = (page ?? 1);
            int pageSize = 10;
            var phim = from p in db.BINHLUANs
                       where p.NOIDUNG.Contains(search)
                       select p;
            //var phim = from p in db.PHIMs join pp in db.BINHLUANs on p.ID_PHIM equals pp.ID_PHIM
            //           where p.TEN_PHIM.Contains(search)
            //           select p;
            return View(phim.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            BINHLUAN bl = db.BINHLUANs.SingleOrDefault(n => n.ID_BINHLUAN == id);

            ViewBag.ID_BINHLUAN = bl.ID_BINHLUAN;
            if (bl == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View(bl);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            BINHLUAN bl = db.BINHLUANs.SingleOrDefault(n => n.ID_BINHLUAN == id);
            ViewBag.ID_BINHLUAN = bl.ID_BINHLUAN;
            if (bl == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.BINHLUANs.DeleteOnSubmit(bl);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

    }
}