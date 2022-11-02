using Shop_ThuCung.Common;
using Shop_ThuCung.Models;
using Shop_ThuCung.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_ThuCung.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index(string keyWord,int page=1,int pageSize=10)
        {
            CategoryDAO dao = new CategoryDAO();
            var categoris= dao.GetListCategory(keyWord, page, page);
            return View( categoris);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDAO();
                long id = dao.Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Category", new { Area = "Admin" });
                }
                else
                    ModelState.AddModelError("", "Thêm User thành công");
            }
            return View("Index");
        }

    }
}