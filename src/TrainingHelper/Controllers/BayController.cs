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

        public List<Bay> getListOfFailedBays(List<Bay> bays)
        {
            int numOfCertifiedOps;
            List<Bay> FailedBayList = new List<Bay>();

            foreach (Bay bay in bays)
            {
                foreach (Tool tool in bay.Tool)
                {
                    numOfCertifiedOps = tool.Certification.OperatorCertifications.AsQueryable().Select(opCert => opCert.Oper).Count();
                    if (numOfCertifiedOps < tool.Certification.TargetTrained)
                    {
                        FailedBayList.Add(bay);
                    }
                }
            }
            return FailedBayList;
        }

        public List<Certification> getListOfFailedCertifications(List<Bay> bays)
        {
            int numOfCertifiedOps;
            List<Certification> FailedCertList = new List<Certification>();

            foreach (Bay bay in bays)
            {
                foreach (Tool tool in bay.Tool)
                {
                    numOfCertifiedOps = tool.Certification.OperatorCertifications.AsQueryable().Select(opCert => opCert.Oper).Count();
                    if (numOfCertifiedOps < tool.Certification.TargetTrained)
                    {
                        FailedCertList.Add(tool.Certification);
                    }
                }
            }
            return FailedCertList;
        }

        public IActionResult Index()
        {
            List<Bay> bay = db.Bays.Include(x => x.Tool).ThenInclude(x => x.Certification).ThenInclude(x => x.OperatorCertifications).ThenInclude(x => x.Oper).ToList();
            List<Bay> failedBayList = getListOfFailedBays(bay);
            List<Certification> FailedCertList = getListOfFailedCertifications(bay);
            BayIndexVM VM = new BayIndexVM(bay, failedBayList, FailedCertList);
            return View(VM);
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
            Bay bay = db.Bays.Include(x => x.Tool).ThenInclude(x => x.Certification).ThenInclude(x => x.OperatorCertifications).ThenInclude(x => x.Oper).FirstOrDefault(x => x.BayId == id);
            BayDetailVM VM = new BayDetailVM(bay);
            return View(VM);
        }
    }
}
