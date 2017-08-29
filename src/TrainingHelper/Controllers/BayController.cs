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

        public IActionResult List()
        {
            return View(db.Bays.ToList());
        }

        //Edit Bay GET
        public IActionResult Edit(int id)
        {
            var thisBay = db.Bays.FirstOrDefault(x => x.BayId == id);
            return View(thisBay);
        }
        //Edit Bay POST
        [HttpPost]
        public IActionResult Edit(Bay bay)
        {
            db.Entry(bay).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisBay = db.Bays.FirstOrDefault(x => x.BayId == id);
            db.Bays.Remove(thisBay);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}


