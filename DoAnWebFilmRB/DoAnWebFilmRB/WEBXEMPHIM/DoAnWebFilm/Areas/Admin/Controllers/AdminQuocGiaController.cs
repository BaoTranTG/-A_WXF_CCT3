using DoAnWebFilm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebFilm.Areas.Admin.Controllers
{
    public class AdminQuocGiaController : Controller
    {
        dbWebFilmDataContext db = new dbWebFilmDataContext();
        public ActionResult Index()
        {
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View(db.QUOCGIAs.ToList());
        }

        // Create QuocGias
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
        public ActionResult Create(QUOCGIA quocGia)
        {
            db.QUOCGIAs.InsertOnSubmit(quocGia);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        //Delete QuocGias
        [HttpGet]
        public ActionResult Delete(int id)
        {
            QUOCGIA quocGia = db.QUOCGIAs.SingleOrDefault(n => n.ID_QG == id);
            ViewBag.id_quoc_gia = quocGia.ID_QG;
            if (quocGia == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View(quocGia);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            //Get object by id
            QUOCGIA quocGia = db.QUOCGIAs.SingleOrDefault(n => n.ID_QG == id);
            ViewBag.id_quoc_gia = quocGia.ID_QG;
            if (quocGia == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.QUOCGIAs.DeleteOnSubmit(quocGia);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        //Edit QuocGias
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //Get object by id
            QUOCGIA quocGia = db.QUOCGIAs.SingleOrDefault(n => n.ID_QG == id);
            ViewBag.id_quoc_gia = quocGia.ID_QG;
            if (quocGia == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View(quocGia);
        }

        [ValidateInput(false)]
        public ActionResult Edit(QUOCGIA quocGia)
        {
            QUOCGIA quocGia2 = db.QUOCGIAs.Single(n => n.ID_QG == quocGia.ID_QG);

            quocGia2.TEN_QG = quocGia.TEN_QG;
            db.SubmitChanges();

            return RedirectToAction("Index");

        }
    }
}