﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TrainingHelper.Controllers
{
    public class BayController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
