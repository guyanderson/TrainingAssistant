using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingHelper.Models;

namespace TrainingHelper.Controllers
{
    public class BayController : Controller
    {
        private TrainingHelperDbContext db = new TrainingHelperDbContext();
        public IActionResult Index()
        {
            return View(db.Bays.ToList());
        }

        //Create new Bay
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name, int areaId)
        {
            Bay newBay = new Bay(name, areaId);
            db.Bays.Add(newBay);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}


