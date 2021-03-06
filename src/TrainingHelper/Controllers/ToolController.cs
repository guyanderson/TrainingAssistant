﻿using System;
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
    public class ToolController : Controller
    {
        private TrainingHelperDbContext db = new TrainingHelperDbContext();

        //GET Tool Index View
        public IActionResult Index()
        {
            List<Tool> tool = db.Tools.Include(x => x.Certification).ThenInclude(x => x.OperatorCertifications).ThenInclude(x => x.Oper).ToList();
            ToolIndexVM VM = new ToolIndexVM(tool);
            return View(VM);
        }
        //GET Tool List for Admin Editing
        public IActionResult List()
        {
            return View(db.Tools.ToList());
        }
        //Get Create Tool View
        public IActionResult Create()
        {
            Tool tool = new Tool();
            List<Bay> bays = db.Bays.ToList();
            List<Certification> certifications = db.Certifications.ToList();
            ToolCreateVM VM = new ToolCreateVM(tool, bays, certifications);
            return View(VM);
        }
        //Create new Tool POST
        [HttpPost]
        public IActionResult Create(string name, int bayId, int certificationId)
        {
            Tool newTool = new Tool(name, bayId, certificationId);
            db.Tools.Add(newTool);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Edit Tool GET
        public IActionResult Edit(int id)
        {
            var thisTool = db.Tools.FirstOrDefault(x => x.ToolId == id);
            List<Bay> bays = db.Bays.ToList();
            List<Certification> certifications = db.Certifications.ToList();
            ToolCreateVM VM = new ToolCreateVM(thisTool, bays, certifications);
            return View(VM);
        }

        //Edit Tool POST
        [HttpPost]
        public IActionResult Edit(Tool tool)
        {
            db.Entry(tool).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Delete Tool 
        public IActionResult Delete(int id)
        {
            var thisTool = db.Tools.FirstOrDefault(x => x.ToolId == id);
            db.Tools.Remove(thisTool);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Certification for selected Tool
        public IActionResult Details(int id)
        {
            Tool tool = db.Tools.Include(x => x.Certification).ThenInclude(x => x.OperatorCertifications).ThenInclude(x => x.Oper).FirstOrDefault(x => x.ToolId == id);
            //Certification certification = db.Certifications.FirstOrDefault(x => x.CertificationId == tool.CertificationId);
            ToolDetailVM VM = new ToolDetailVM(tool);
            return View(VM);
        }
        
    }
}
