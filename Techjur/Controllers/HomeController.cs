﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Techjur.Controllers
{
    public class HomeController : CustomController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}