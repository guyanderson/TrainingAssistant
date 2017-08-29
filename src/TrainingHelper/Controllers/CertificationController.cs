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
    public class CertificationController : Controller
    {
        private TrainingHelperDbContext db = new TrainingHelperDbContext();

        public IActionResult Index()
        {
            return View(db.Certifications.ToList());
        }

        //Create new Certification
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(db.Certifications.ToList());
        }
        [HttpPost]
        public IActionResult Create(string name)
        {
            Certification newCertification = new Certification(name);
            db.Certifications.Add(newCertification);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Edit Certification GET
        public IActionResult Edit(int id)
        {
            var thisCertification = db.Certifications.FirstOrDefault(x => x.CertificationId == id);
            return View(thisCertification);
        }
        //Edit Certification POST
        [HttpPost]
        public IActionResult Edit(Certification certification)
        {
            db.Entry(certification).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisCertification = db.Certifications.FirstOrDefault(x => x.CertificationId == id);
            db.Certifications.Remove(thisCertification);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
