using DoAnWebFilm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebFilm.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        dbWebFilmDataContext db = new dbWebFilmDataContext();
        // GET: Admin/AdminHome
        public ActionResult Index()
        {
            if(Session["Taikhoanadmin"] == null) {
                return RedirectToAction("Login","AdminHome");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("AdminHome","Admin");
        }
       
        [HttpPost]
        public ActionResult Login(FormCollection collection) 
        {
            var tendn = collection["username"];
            var matkhau = collection["password"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                ADMINFILM ad = db.ADMINFILMs.SingleOrDefault(n => n.TEN_ADMIN == tendn && n.MK_ADMIN == matkhau);
                if (ad != null)
                {
                    Session["Taikhoanadmin"] = ad;
                    return RedirectToAction("Index", "AdminHome");
                }
                else
                {
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
                }
                
            }
            return View();
        }
    }
}