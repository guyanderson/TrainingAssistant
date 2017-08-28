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

        [HttpPost]
        public IActionResult Create(string name)
        {
            Certification newCertification = new Certification(name);
            db.Certifications.Add(newCertification);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
