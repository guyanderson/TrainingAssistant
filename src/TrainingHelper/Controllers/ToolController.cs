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
    public class ToolController : Controller
    {
        private TrainingHelperDbContext db = new TrainingHelperDbContext();
        public IActionResult Index()
        {
            return View(db.Tools.ToList());
        }
        public IActionResult List()
        {
            return View(db.Tools.ToList());
        }

        //Edit Tool GET
        public IActionResult Edit(int id)
        {
            var thisTool = db.Tools.FirstOrDefault(x => x.ToolId == id);
            return View(thisTool);
        }
        //Edit Tool POST
        [HttpPost]
        public IActionResult Edit(Tool tool)
        {
            db.Entry(tool).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisTool = db.Tools.FirstOrDefault(x => x.ToolId == id);
            db.Tools.Remove(thisTool);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
