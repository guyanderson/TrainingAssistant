﻿using System;
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
    public class OperatorController : Controller
    {
        private TrainingHelperDbContext db = new TrainingHelperDbContext();
        public IActionResult Index()
        {
            return View(db.Operators.ToList());
        }

        //Create new Operator GET
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(db.Operators.ToList());
        }
        //Create new Operator POST
        [HttpPost]
        public IActionResult Create(string name, int shiftId)
        {
            Operator newOperator = new Operator(name, shiftId);
            db.Operators.Add(newOperator);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Edit Operator GET
        public IActionResult Edit(int id)
        {
            var thisOperator = db.Operators.FirstOrDefault(x => x.OperatorId == id);
            return View(thisOperator);
        }
        //Edit Operator POST
        [HttpPost]
        public IActionResult Edit(Operator op)
        {
            db.Entry(op).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisOperator = db.Operators.FirstOrDefault(x => x.OperatorId == id);
            db.Operators.Remove(thisOperator);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
