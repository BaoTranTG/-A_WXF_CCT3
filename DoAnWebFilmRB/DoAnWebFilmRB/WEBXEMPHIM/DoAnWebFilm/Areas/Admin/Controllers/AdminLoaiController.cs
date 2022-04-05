using DoAnWebFilm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebFilm.Areas.Admin.Controllers
{
    public class AdminLoaiController : Controller
    {
        dbWebFilmDataContext db = new dbWebFilmDataContext();
        public ActionResult Index()
        {
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View(db.LOAIs.ToList());
        }

        // Create Loai
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
        public ActionResult Create(LOAI loai)
        {
            db.LOAIs.InsertOnSubmit(loai);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        //Delete Loai
        [HttpGet]
        public ActionResult Delete(int id)
        {
            LOAI loai = db.LOAIs.SingleOrDefault(n => n.IDLOAI == id);

            ViewBag.id_loai = loai.IDLOAI;
            if (loai == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View(loai);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            //Get object by id
            LOAI loai = db.LOAIs.SingleOrDefault(n => n.IDLOAI == id);
            ViewBag.IDLOAI = loai.IDLOAI;
            if (loai == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.LOAIs.DeleteOnSubmit(loai);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        //Edit Loai
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //Get object by id
            LOAI loai = db.LOAIs.SingleOrDefault(n => n.IDLOAI == id);
            ViewBag.IDLOAI = loai.IDLOAI;
            if (loai == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View(loai);
        }

        [ValidateInput(false)]
        public ActionResult Edit(LOAI loai)
        {
            LOAI loai2 = db.LOAIs.Single(n => n.IDLOAI == loai.IDLOAI);

            loai2.TENLOAI = loai.TENLOAI;
            db.SubmitChanges();

            return RedirectToAction("Index");

        }
    }
}