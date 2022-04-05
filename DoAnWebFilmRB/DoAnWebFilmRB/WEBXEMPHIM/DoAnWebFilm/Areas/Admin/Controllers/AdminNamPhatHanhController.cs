using DoAnWebFilm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebFilm.Areas.Admin.Controllers
{
    public class AdminNamPhatHanhController : Controller
    {
        dbWebFilmDataContext db = new dbWebFilmDataContext();
        public ActionResult Index()
        {
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View(db.NAMPHATHANHs.ToList());
        }

        // Create NamPhatHanh
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
        public ActionResult Create(NAMPHATHANH namPhatHanh)
        {
            db.NAMPHATHANHs.InsertOnSubmit(namPhatHanh);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        //Delete NamPhatHanh
        [HttpGet]
        public ActionResult Delete(int id)
        {
            NAMPHATHANH namPhatHanh = db.NAMPHATHANHs.SingleOrDefault(n => n.ID_NAM == id);

            ViewBag.ID_NAM = namPhatHanh.ID_NAM;
            if (namPhatHanh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View(namPhatHanh);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            //Get object by id
            NAMPHATHANH namPhatHanh = db.NAMPHATHANHs.SingleOrDefault(n => n.ID_NAM == id);
            ViewBag.ID_NAM = namPhatHanh.ID_NAM;
            if (namPhatHanh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.NAMPHATHANHs.DeleteOnSubmit(namPhatHanh);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        //Edit NamPhatHanh
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //Get object by id
            NAMPHATHANH namPhatHanh = db.NAMPHATHANHs.SingleOrDefault(n => n.ID_NAM == id);
            ViewBag.ID_NAM = namPhatHanh.ID_NAM;
            if (namPhatHanh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            if (Session["Taikhoanadmin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View(namPhatHanh);
        }

        [ValidateInput(false)]
        public ActionResult Edit(NAMPHATHANH namPhatHanh)
        {
            NAMPHATHANH namPhatHanh2 = db.NAMPHATHANHs.Single(n => n.ID_NAM == namPhatHanh.ID_NAM);

            namPhatHanh2.NAM_PHAT = namPhatHanh.NAM_PHAT;
            db.SubmitChanges();

            return RedirectToAction("Index");

        }
    }
}