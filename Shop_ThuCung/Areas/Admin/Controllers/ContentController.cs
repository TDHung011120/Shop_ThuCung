﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_ThuCung.Areas.Admin.Controllers
{
    public class ContentController : Controller
    {
        // GET: Admin/Content
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}