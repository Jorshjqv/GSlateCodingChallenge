﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GSlateDataAccess;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    { 

        public HomeController()
        {
            
        }

        public ActionResult Index()
        {
        ViewBag.Title = "Home Page";

            return View();
        }
    }
}
