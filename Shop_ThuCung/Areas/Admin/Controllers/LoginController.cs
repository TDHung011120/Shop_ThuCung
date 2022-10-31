using Shop_ThuCung.Common;
using Shop_ThuCung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_ThuCung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginAdminModel model)
        {
            if (ModelState.IsValid)//Kiểm tra form nhập rỗng
            {
                var dao = new AdminDAO();
                //kiểm tra đăng nhập
                var result = dao.Login(model.AdminName, Ecryptor.MD5Hash(model.Password)); //mã hóa mật khẩu 
                if (result == 1)
                {
                    var admin = dao.GetByUserName(model.AdminName);
                    var adminSession = new AdminLogin();
                    adminSession.Name = admin.AdminName;
                    adminSession.ID = admin.ID;
                    Session.Add(CommonConstants.ADMIN_SESSION, adminSession);
                    return RedirectToAction("Index", "Home",new {Area="Admin"});
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại!");
                }
                else if (result == -1)
                    ModelState.AddModelError("", "Tài khoản đang bị khóa");
                else
                    ModelState.AddModelError("","Mật khẩu không đúng!");
            }
            return View("Index");

        }
    }
}