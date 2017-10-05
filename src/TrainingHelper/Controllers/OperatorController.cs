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
        public IActionResult Create(string name, int shiftId, IFormFile img)
        {
            byte[] photo = new byte[0];
            if (img != null)
            {
                using (Stream fileStream = img.OpenReadStream())
                using (MemoryStream ms = new MemoryStream())
                {
                    fileStream.CopyTo(ms);
                    photo = ms.ToArray();
                }
            }
            Oper newOperator = new Oper(name, shiftId, photo);
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
            var thisOperator = db.Operators.AsNoTracking().FirstOrDefault(o => o.OperatorId == oper.OperatorId);
            oper.Img = thisOperator.Img; //Grabs the Img from the database then replaces it before EF removes it
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

        public IActionResult Details(int id)
        {
            Oper oper = db.Operators.Include(x => x.OperatorCertifications).ThenInclude(x => x.Certification).FirstOrDefault(x => x.OperatorId == id);
            var thisOperator = db.Operators.FirstOrDefault(x => x.OperatorId == id);
            //Shift shift = Shift.thisOperator.ShiftId;
            Shift shift = db.Shifts.FirstOrDefault(x => x.ShiftId == thisOperator.ShiftId);
            OperatorDetailsVM VM = new OperatorDetailsVM(oper, shift);
            return View(VM);
        }
    }  
}
