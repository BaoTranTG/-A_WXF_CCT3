using DoAnWebFilm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebFilm.Controllers
{
    public class ThanhVienController : Controller
    {
        dbWebFilmDataContext db = new dbWebFilmDataContext();

        [HttpGet]
        public ActionResult register()
        {
            return View();
        }
        public ActionResult logout()
        {
            Session.Clear();
            return RedirectToAction("login");
        }

        [HttpPost]
        public ActionResult register(FormCollection collection, THANHVIEN tv)
        {
            var hoten = collection["HotenTV"];
            var tendangnhap = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            var nhaplaimatkhau = collection["Nhaplaimatkhau"];
            var email = collection["Email"];
            var diachi = collection["Diachi"];
            var dienthoai = collection["Dienthoai"];
            var ngaysinh =String.Format("{0:MM/dd/yyyy}",collection["Ngaysinh"]);
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên thành viên không được để trống";
            }
            else if (String.IsNullOrEmpty(tendangnhap))
            {
                ViewData["Loi2"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Phải nhập mật khẩu";
            }
            else if (String.IsNullOrEmpty(nhaplaimatkhau))
            {
                ViewData["Loi4"] = "Phải nhập lại mật khẩu";
            }
            else if (String.IsNullOrEmpty(email))
            {
                ViewData["Loi5"] = "Email không được để trống";
            }
            else if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi6"] = "Địa chỉ không được để trống";
            }
            else if (String.IsNullOrEmpty(diachi))
            {
                ViewData["Loi7"] = "Điện thoại không được để trống";
            }
            else if (String.IsNullOrEmpty(ngaysinh))
            {
                ViewData["Loi8"] = "Ngày sinh không được để trống";
            }
            else
            {
                THANHVIEN tendn = db.THANHVIENs.SingleOrDefault(t => t.TAIKHOAN == tendangnhap);
                THANHVIEN emails = db.THANHVIENs.SingleOrDefault(t => t.EMAIL == email);
                if (tendn == null && emails == null)
                {
                    if (matkhau.Equals(nhaplaimatkhau))
                    {
                        tv.HOTEN = hoten;
                        tv.TAIKHOAN = tendangnhap;
                        tv.MATKHAU = matkhau;
                        tv.EMAIL = email;
                        tv.DIACHI = diachi;
                        tv.SDT = dienthoai;
                        tv.NGAYSINH = DateTime.Parse(ngaysinh);
                        db.THANHVIENs.InsertOnSubmit(tv);
                        db.SubmitChanges();
                        ViewBag.Thongbao = "Đăng ký thành công";
                        //return RedirectToAction("login");
                    }
                    else
                    {
                        ViewData["Loi9"] = "Mật khẩu không trùng khớp";
                    }

                }
                if (tendn != null)
                {
                    ViewData["Loi10"] = "Tên đăng nhập này tồn tại";
                }
                if (emails != null)
                {
                    ViewData["Loi11"] = "Email này đã tồn tại";
                }
            }
            return this.register();
        }
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult login(FormCollection collection)
        {
            var tendangnhap = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            if (String.IsNullOrEmpty(tendangnhap))
            {
                ViewData["Loi1"] = "Chưa nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Chưa nhập mật khẩu";
            }
            else
            {
                THANHVIEN tv = db.THANHVIENs.SingleOrDefault(n => n.TAIKHOAN == tendangnhap && n.MATKHAU == matkhau);
                if (tv != null)
                {
                    ViewBag.Thongbao = "Đăng nhập thành công";
                    Session["Taikhoan"] = tv;
                    return RedirectToAction("index","Home");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }
    }
}