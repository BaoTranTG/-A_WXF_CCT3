using DoAnWebFilm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebFilm.Areas.Admin.Controllers
{
    public class AdminTrangThaiController : Controller
    {
        dbWebFilmDataContext db = new dbWebFilmDataContext();
        public ActionResult Index()
        {
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View(db.TRANGTHAIs.ToList());
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
        public ActionResult Create(TRANGTHAI trangThai)
        {
            db.TRANGTHAIs.InsertOnSubmit(trangThai);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            TRANGTHAI trangThai = db.TRANGTHAIs.SingleOrDefault(n => n.ID_TRANGTHAI == id);

            ViewBag.id_trang_thai = trangThai.ID_TRANGTHAI;
            if (trangThai == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(trangThai);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            TRANGTHAI trangThai = db.TRANGTHAIs.SingleOrDefault(n => n.ID_TRANGTHAI == id);

            ViewBag.id_trang_thai = trangThai.ID_TRANGTHAI;
            if (trangThai == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.TRANGTHAIs.DeleteOnSubmit(trangThai);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            TRANGTHAI trangThai = db.TRANGTHAIs.SingleOrDefault(n => n.ID_TRANGTHAI == id);
            ViewBag.id_trang_thai = trangThai.ID_TRANGTHAI;
            if (trangThai == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View(trangThai);
        }
        [ValidateInput(false)]
        public ActionResult Edit(TRANGTHAI trangThai)
        {
            TRANGTHAI trangThai2 = db.TRANGTHAIs.Single(n => n.ID_TRANGTHAI == trangThai.ID_TRANGTHAI);

            trangThai2.TEN_TRANGTHAI = trangThai.TEN_TRANGTHAI;
            db.SubmitChanges();

            return RedirectToAction("Index");

        }
    }
}