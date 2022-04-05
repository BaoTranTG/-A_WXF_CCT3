using DoAnWebFilm.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace DoAnWebFilm.Areas.Admin.Controllers
{
    public class AdminPhimController : Controller
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
            return View(db.PHIMs.ToList().OrderBy(n => n.ID_PHIM).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Search(String search, int? page)
        {
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }

            int pageNumber = (page ?? 1);
            int pageSize = 10;

            var phim = from p in db.PHIMs
                       where p.TEN_PHIM.Contains(search)
                       select p;
            return View(phim.OrderBy(n => n.ID_PHIM).ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new PHIM();
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            ViewBag.ID_QG = new SelectList(db.QUOCGIAs.ToList().OrderBy(n => n.TEN_QG), "ID_QG", "TEN_QG");
            ViewBag.ID_NAM = new SelectList(db.NAMPHATHANHs.ToList().OrderBy(n => n.NAM_PHAT), "ID_NAM", "NAM_PHAT");
            ViewBag.ID_TRANGTHAI = new SelectList(db.TRANGTHAIs.ToList().OrderBy(n => n.TEN_TRANGTHAI), "ID_TRANGTHAI", "TEN_TRANGTHAI");

            ViewBag.IDLOAI = (from a in db.LOAIs select a).ToList();
            ViewBag.ID_DV = (from a in db.DIENVIENs select a).ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(PHIM phim, HttpPostedFileBase fileUpload)
        {
            ViewBag.ID_QG = new SelectList(db.QUOCGIAs.ToList().OrderBy(n => n.TEN_QG), "ID_QG", "TEN_QG");
            ViewBag.ID_NAM = new SelectList(db.NAMPHATHANHs.ToList().OrderBy(n => n.NAM_PHAT), "ID_NAM", "NAM_PHAT");
            ViewBag.ID_TRANGTHAI = new SelectList(db.TRANGTHAIs.ToList().OrderBy(n => n.TEN_TRANGTHAI), "ID_TRANGTHAI", "TEN_TRANGTHAI");

            ViewBag.IDLOAI = (from a in db.LOAIs select a).ToList();
            ViewBag.ID_DV = (from a in db.DIENVIENs select a).ToList();

            if (fileUpload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    DateTime localDate = DateTime.Now;
                    string date_str = localDate.ToString("ddMMyyyy_HHmmss");
                    fileName = date_str + "_" + fileName;
                    var path = Path.Combine(Server.MapPath("~/PosterFilm/"), fileName);
                    if (System.IO.File.Exists(path))
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    else
                    {
                        fileUpload.SaveAs(path);
                    }
                    phim.IMAGE_PHIM = fileName;

                    db.PHIMs.InsertOnSubmit(phim);

                    db.SubmitChanges();
                }
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            PHIM phim = db.PHIMs.SingleOrDefault(n => n.ID_PHIM == id);
            ViewBag.ID_PHIM = phim.ID_PHIM;
            if (phim == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View(phim);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            PHIM phim = db.PHIMs.SingleOrDefault(n => n.ID_PHIM == id);
            ViewBag.ID_PHIM = phim.ID_PHIM;
            if (phim == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.PHIMs.DeleteOnSubmit(phim);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            PHIM phim = db.PHIMs.SingleOrDefault(n => n.ID_PHIM == id);
            ViewBag.ID_PHIM = phim.ID_PHIM;
            if (phim == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.ID_QG = new SelectList(db.QUOCGIAs.ToList().OrderBy(n => n.TEN_QG), "ID_QG", "TEN_QG");
            ViewBag.ID_NAM = new SelectList(db.NAMPHATHANHs.ToList().OrderBy(n => n.NAM_PHAT), "ID_NAM", "NAM_PHAT");
            ViewBag.ID_TRANGTHAI = new SelectList(db.TRANGTHAIs.ToList().OrderBy(n => n.TEN_TRANGTHAI), "ID_TRANGTHAI", "TEN_TRANGTHAI");
            ViewBag.IDLOAI = (from a in db.LOAIs select a).ToList();
            ViewBag.ID_DV = (from a in db.DIENVIENs select a).ToList();
            return View(phim);
        }
        [ValidateInput(false)]
        public ActionResult Edit(PHIM phim, HttpPostedFileBase fileUpload)
        {
            ViewBag.ID_QG = new SelectList(db.QUOCGIAs.ToList().OrderBy(n => n.TEN_QG), "ID_QG", "TEN_QG");
            ViewBag.ID_NAM = new SelectList(db.NAMPHATHANHs.ToList().OrderBy(n => n.NAM_PHAT), "ID_NAM", "NAM_PHAT");
            ViewBag.ID_TRANGTHAI = new SelectList(db.TRANGTHAIs.ToList().OrderBy(n => n.TEN_TRANGTHAI), "ID_TRANGTHAI", "TEN_TRANGTHAI");

            ViewBag.IDLOAI = (from a in db.LOAIs select a).ToList();
            ViewBag.ID_DV = (from a in db.DIENVIENs select a).ToList();

            PHIM phim2 = db.PHIMs.Single(n => n.ID_PHIM == phim.ID_PHIM);
            if (fileUpload != null)
            {
                var fileName = Path.GetFileName(fileUpload.FileName);
                DateTime localDate = DateTime.Now;
                string date_str = localDate.ToString("ddMMyyyy_HHmmss");
                fileName = date_str + "_" + fileName;
                var path = Path.Combine(Server.MapPath("~/PosterFilm"), fileName);
                if (System.IO.File.Exists(path))
                    ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                else
                {
                    fileUpload.SaveAs(path);
                }

                phim.IMAGE_PHIM = fileName;
                phim2.IMAGE_PHIM = phim.IMAGE_PHIM;
            }

            phim2.TEN_PHIM = phim.TEN_PHIM;
            phim2.LINK_PHIM = phim.LINK_PHIM;
            phim2.IMAGE_PHIM = phim.IMAGE_PHIM;
            phim2.MOTA = phim.MOTA;
            phim2.ID_TRANGTHAI = phim.ID_TRANGTHAI;
            phim2.ID_QG = phim.ID_QG;
            phim2.ID_NAM = phim.ID_NAM;

            db.SubmitChanges();

            return RedirectToAction("Index");

        }


    }
}