using DoAnWebFilm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebFilm.Areas.Admin.Controllers
{
    public class AdminDienVienController : Controller
    {
        dbWebFilmDataContext db = new dbWebFilmDataContext();
        public ActionResult Index()
        {
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View(db.DIENVIENs.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(DIENVIEN dienvien)
        {
            db.DIENVIENs.InsertOnSubmit(dienvien);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            DIENVIEN dv = db.DIENVIENs.SingleOrDefault(n => n.ID_DV == id);

            ViewBag.id_loai = dv.ID_DV;
            if (dv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View(dv);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            DIENVIEN dv = db.DIENVIENs.SingleOrDefault(n => n.ID_DV == id);
            ViewBag.ID_DV = dv.ID_DV;
            if (dv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.DIENVIENs.DeleteOnSubmit(dv);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            DIENVIEN dv = db.DIENVIENs.SingleOrDefault(n => n.ID_DV == id);
            ViewBag.ID_DV = dv.ID_DV;
            if (dv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View(dv);
        }

        [ValidateInput(false)]
        public ActionResult Edit(DIENVIEN dv)
        {
            DIENVIEN dv2 = db.DIENVIENs.Single(n => n.ID_DV == dv.ID_DV);

            dv2.TEN_DV = dv.TEN_DV;
            db.SubmitChanges();

            return RedirectToAction("Index");

        }
    }
}