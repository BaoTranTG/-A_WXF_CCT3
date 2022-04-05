using DoAnWebFilm.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebFilm.Areas.Admin.Controllers
{
    public class AdminPhimSapChieuController : Controller
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
            return View(db.PHIMSAPCHIEUs.ToList().OrderBy(n => n.ID_PHIMSP).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Search(String search, int? page)
        {
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }

            int pageNumber = (page ?? 1);
            int pageSize = 10;

            var phimsc = from psc in db.PHIMSAPCHIEUs
                       where psc.TEN_PHIMSP.Contains(search)
                       select psc;
            return View(phimsc.OrderBy(n => n.ID_PHIMSP).ToPagedList(pageNumber, pageSize));
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
        [ValidateInput(false)]
        public ActionResult Create(PHIMSAPCHIEU phimsp, HttpPostedFileBase fileUpload)
        {

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
                    var path = Path.Combine(Server.MapPath("~/PosterFilmSC"), fileName);
                    if (System.IO.File.Exists(path))
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    else
                    {
                        fileUpload.SaveAs(path);
                    }
                    phimsp.IMAGE_PHIMSP = fileName;

                    db.PHIMSAPCHIEUs.InsertOnSubmit(phimsp);

                    db.SubmitChanges();
                }
                return RedirectToAction("Index");
            }
        }

        //Delete QuocGias
        [HttpGet]
        public ActionResult Delete(int id)
        {
            PHIMSAPCHIEU phimsp = db.PHIMSAPCHIEUs.SingleOrDefault(n => n.ID_PHIMSP == id);
            ViewBag.ID_PHIMSP = phimsp.ID_PHIMSP;
            if (phimsp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View(phimsp);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            //Get object by id
            PHIMSAPCHIEU phimsp = db.PHIMSAPCHIEUs.SingleOrDefault(n => n.ID_PHIMSP == id);
            ViewBag.ID_PHIMSP = phimsp.ID_PHIMSP;
            if (phimsp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.PHIMSAPCHIEUs.DeleteOnSubmit(phimsp);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        //Edit QuocGias
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //Get object by id
            PHIMSAPCHIEU phimsp = db.PHIMSAPCHIEUs.SingleOrDefault(n => n.ID_PHIMSP == id);
            ViewBag.ID_PHIMSP = phimsp.ID_PHIMSP;
            if (phimsp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View(phimsp);
        }

        [ValidateInput(false)]
        public ActionResult Edit(PHIMSAPCHIEU phimsp, HttpPostedFileBase fileUpload)
        {
            PHIMSAPCHIEU phimsp2 = db.PHIMSAPCHIEUs.Single(n => n.ID_PHIMSP == phimsp.ID_PHIMSP);
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
                    var path = Path.Combine(Server.MapPath("~/PosterFilmSC"), fileName);
                    if (System.IO.File.Exists(path))
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    else
                    {
                        fileUpload.SaveAs(path);
                    }
                    phimsp.IMAGE_PHIMSP = fileName;

                    phimsp2.TEN_PHIMSP = phimsp.TEN_PHIMSP;
                    phimsp2.IMAGE_PHIMSP = phimsp.IMAGE_PHIMSP;
                    phimsp2.LINK_PHIMSP = phimsp.LINK_PHIMSP;
                    db.SubmitChanges();
                }
                return RedirectToAction("Index");
            }

        }
    }
}