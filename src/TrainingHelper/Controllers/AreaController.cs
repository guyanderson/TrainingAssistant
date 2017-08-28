using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingHelper.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;


namespace TrainingHelper.Controllers
{
    public class AreaController : Controller
    {
        private TrainingHelperDbContext db = new TrainingHelperDbContext();

        public IActionResult Index()
        {
            return View(db.Areas.ToList());
        }


        //Create new Area
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            Area newArea = new Area(name);
            db.Areas.Add(newArea);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
