using DoAnWebFilm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebFilm.Areas.Admin.Controllers
{
    public class AdminAccountAdminController : Controller
    {
        dbWebFilmDataContext db = new dbWebFilmDataContext();
        public ActionResult Index()
        {
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View(db.ADMINFILMs.ToList());
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
        public ActionResult Create(ADMINFILM adminfilm)
        {
            db.ADMINFILMs.InsertOnSubmit(adminfilm);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ADMINFILM adminfilm = db.ADMINFILMs.SingleOrDefault(n => n.ID_ADMIN == id);

            ViewBag.ID_ADMIN = adminfilm.ID_ADMIN;
            if (adminfilm == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View(adminfilm);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            ADMINFILM adminfilm = db.ADMINFILMs.SingleOrDefault(n => n.ID_ADMIN == id);
            ViewBag.ID_ADMIN = adminfilm.ID_ADMIN;
            if (adminfilm == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.ADMINFILMs.DeleteOnSubmit(adminfilm);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ADMINFILM adminfilm = db.ADMINFILMs.SingleOrDefault(n => n.ID_ADMIN == id);
            ViewBag.IDLOAI = adminfilm.ID_ADMIN;
            if (adminfilm == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View(adminfilm);
        }

        [ValidateInput(false)]
        public ActionResult Edit(ADMINFILM adminfilm)
        {
            ADMINFILM adminfilm2 = db.ADMINFILMs.Single(n => n.ID_ADMIN == adminfilm.ID_ADMIN);
            adminfilm2.TEN_ADMIN = adminfilm.TEN_ADMIN;
            adminfilm2.MK_ADMIN = adminfilm.MK_ADMIN;
            db.SubmitChanges();

            return RedirectToAction("Index");

        }
    }
}