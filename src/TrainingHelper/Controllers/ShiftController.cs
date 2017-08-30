using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingHelper.Models;
using Microsoft.EntityFrameworkCore;

namespace TrainingHelper.Controllers
{
    public class ShiftController : Controller
    {

        private TrainingHelperDbContext db = new TrainingHelperDbContext();

        public IActionResult Index()
        {
            return View(db.Shifts.ToList());
        }


        //Create new Shift GET
        public IActionResult Create()
        {
            return View();
        }
        //Create new Shift POST
        [HttpPost]
        public IActionResult Create(string name)
        {
            Shift newShift = new Shift(name);
            db.Shifts.Add(newShift);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult List()
        {
            return View(db.Shifts.ToList());
        }
        //Edit Shift GET
        public IActionResult Edit(int id)
        {
            var thisShift = db.Shifts.FirstOrDefault(x => x.ShiftId == id);
            return View(thisShift);
        }
        //Edit Shift POST
        [HttpPost]
        public IActionResult Edit(Shift area)
        {
            db.Entry(area).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisShift = db.Shifts.FirstOrDefault(x => x.ShiftId == id);
            db.Shifts.Remove(thisShift);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
