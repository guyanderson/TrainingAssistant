﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TrainingHelper.Controllers
{
    public class FabController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
