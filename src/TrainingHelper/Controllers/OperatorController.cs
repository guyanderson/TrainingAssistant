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
    public class OperatorController : Controller
    {
        private TrainingHelperDbContext db = new TrainingHelperDbContext();
        public IActionResult Index()
        {
            return View(db.Operators.ToList());
        }

        public IActionResult List()
        {
            return View(db.Operators.ToList());
        }
        //Create new Operator GET
        public IActionResult Create()
        {
            Oper oper = new Oper();
            List<Shift> shifts = db.Shifts.ToList();
            OperatorCreateVM VM = new OperatorCreateVM(oper, shifts);
            return View(VM);
        }

        //Create new Operator POST
        [HttpPost]
        public IActionResult Create(string name, int shiftId)
        {
            Oper newOperator = new Oper(name, shiftId);
            db.Operators.Add(newOperator);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Edit Operator GET
        public IActionResult Edit(int id)
        {
            var thisOperator = db.Operators.FirstOrDefault(x => x.OperatorId == id);
            List<Shift> shifts = db.Shifts.ToList();
            List<Certification> certifications = db.Certifications.ToList();
            OperatorCertifications operatorCertifications = new OperatorCertifications();
            OperatorEditVM VM = new OperatorEditVM(thisOperator, shifts, certifications, operatorCertifications);
            return View(VM);
        }
        //Edit Operator POST
        [HttpPost]
        public IActionResult Edit(Oper oper)
        {
            db.Entry(oper).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Delete Operator
        public IActionResult Delete(int id)
        {
            var thisOperator = db.Operators.FirstOrDefault(x => x.OperatorId == id);
            db.Operators.Remove(thisOperator);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Add Certification to Operator
        public IActionResult AddCertToOper(Oper oper, OperatorCertifications operatorCertifications)
        {
            var newOperatorCertifications = new OperatorCertifications();

            newOperatorCertifications.OperatorId = oper.OperatorId;
            newOperatorCertifications.CertificationId = operatorCertifications.CertificationId;
            db.OperatorCertifications.Add(newOperatorCertifications);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

// var newOperatorCertifications = new OperatorCertifications();
// newOperatorCertifications.OperatorId = .OperatorId;
// newOperatorCertifications.CertificationId = certification.CertificationId;
// db.OperatorCertifications.Add(newOperatorCertifications);