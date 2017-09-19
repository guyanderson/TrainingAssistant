using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingHelper.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using TrainingHelper.ViewModels;

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
            Bay bay = new Bay();
            List<Area> areas = db.Areas.ToList();
            BayCreateVM VM = new BayCreateVM(bay, areas);
            return View(VM);
        }

        [HttpPost]
        public IActionResult Create(string name, int targetTrained, int areaId)
        {
            Bay newBay = new Bay(name, targetTrained, areaId);
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
            List<Area> areas = db.Areas.ToList();
            BayCreateVM VM = new BayCreateVM(thisBay, areas);
            return View(VM);
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
        //list all Tools in selected Bay
         public IActionResult Details(int id)
        {
            Bay bay = db.Bays.FirstOrDefault(x => x.BayId == id);
            List<Tool>tools = db.Tools.Where(x => x.BayId == id).ToList();
            BayDetailVM VM = new BayDetailVM(bay,tools);
            return View(VM);
        }


    }
}


