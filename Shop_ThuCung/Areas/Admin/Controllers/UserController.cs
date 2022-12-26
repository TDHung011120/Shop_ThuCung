using Shop_ThuCung.Common;
using Shop_ThuCung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Shop_ThuCung.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string keyWord, int page = 1, int pageSize = 1)
        {
            var dao = new UserDAO();
            var users = dao.GetListUser(keyWord,page, pageSize);
            ViewBag.KeyWord = keyWord;
            return View(users);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var ecryptorMD5 = Ecryptor.MD5Hash(model.Password);
                model.Password = ecryptorMD5;
                long id = dao.Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                    ModelState.AddModelError("", "Thêm User thành công");
            }
            return View("Index");
        }
        public ActionResult Edit(int ID)
        {
            UserDAO dao = new UserDAO();
            var user = dao.GetByID(ID);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                long id = dao.Edit(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                    ModelState.AddModelError("", "Sửa User không thành công");
            }
            return View("Index");

        }
        
        public ActionResult Delete(int ID)
        {
            UserDAO dao = new UserDAO();
            var result=dao.Delete(ID);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var result = new UserDAO().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}