using DoAnWebFilm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebFilm.Areas.Admin.Controllers
{
    public class AdminThanhVienController : Controller
    {
        // GET: Admin/AdminThanhVien
        dbWebFilmDataContext db = new dbWebFilmDataContext();
        public ActionResult Index()
        {
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View(db.THANHVIENs.ToList());
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            THANHVIEN tv = db.THANHVIENs.SingleOrDefault(n => n.ID_TV == id);

            ViewBag.ID_TV = tv.ID_TV;
            if (tv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View(tv);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            THANHVIEN tv = db.THANHVIENs.SingleOrDefault(n => n.ID_TV == id);
            ViewBag.ID_TV = tv.ID_TV;
            if (tv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.THANHVIENs.DeleteOnSubmit(tv);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //Get object by id
            THANHVIEN tv = db.THANHVIENs.SingleOrDefault(n => n.ID_TV == id);
            ViewBag.ID_TV = tv.ID_TV;
            if (tv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View(tv);
        }
        [ValidateInput(false)]
        public ActionResult Edit(THANHVIEN tv)
        {
            THANHVIEN tv2 = db.THANHVIENs.Single(n => n.ID_TV == tv.ID_TV);
            tv2.HOTEN = tv.HOTEN;
            tv2.TAIKHOAN = tv.TAIKHOAN;
            tv2.MATKHAU = tv.MATKHAU;
            tv2.EMAIL = tv.EMAIL;
            tv2.NGAYSINH = tv.NGAYSINH;
            tv2.DIACHI = tv.DIACHI;
            tv2.SDT = tv.SDT;
            db.SubmitChanges();
            return RedirectToAction("Index");

        }
    }
}