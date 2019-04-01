﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StatisticalQualityControl.Models;

namespace StatisticalQualityControl.Controllers
{
    public class HomeController : Controller
    {
        StatisticalQualityControlModel db = new StatisticalQualityControlModel();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error(string Message)
        {
            ViewBag.ErrorMessage = Message;
            return View();
        }
    }
}