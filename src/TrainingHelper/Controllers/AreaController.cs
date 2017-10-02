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
    public class AreaController : Controller
    {
        private TrainingHelperDbContext db = new TrainingHelperDbContext();


        public List<Area> getListOfFailedAreas(List<Area> areas)
        {
            int numOfCertifiedOps;
            List<Area> FailedAreaList = new List<Area>();
            
            foreach (Area area in areas)
            {
                foreach (Bay bay in area.Bay)
                {
                    foreach (Tool tool in bay.Tool)
                    {
                        bool alreadyExist = FailedAreaList.Contains(area);

                        numOfCertifiedOps = tool.Certification.OperatorCertifications.AsQueryable().Select(opCert => opCert.Oper).Count();
                        if (numOfCertifiedOps < tool.Certification.TargetTrained && alreadyExist == false)
                        {
                            FailedAreaList.Add(area);
                        }
                    }
                }
            }
            return FailedAreaList;
        }

        public List<Certification> getListOfFailedCertifications(List<Area> areas)
        {
            int numOfCertifiedOps;
            List<Certification> FailedCertList = new List<Certification>();

            foreach (Area area in areas)
            {
                foreach (Bay bay in area.Bay)
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
            }
            return FailedCertList;
        }

        public IActionResult Index()
        {
            List<Area> areas =db.Areas.Include(area => area.Bay).ThenInclude(bay => bay.Tool).ThenInclude(tool => tool.Certification).ThenInclude(cert => cert.OperatorCertifications).ThenInclude(opCert => opCert.Oper).ToList();
            List<Area> failedAreaList = getListOfFailedAreas(areas);
            List<Certification> failedCertList = getListOfFailedCertifications(areas);
            AreaIndexVM VM = new AreaIndexVM(areas, failedAreaList, failedCertList);
            return View(VM);
            //return View(db.Areas.ToList());
        }

        //Create new Area GET
        public IActionResult Create()
        {
            return View();
        }
        //Create new Operator POST
        [HttpPost]
        public IActionResult Create(string name)
        {
            Area newArea = new Area(name);
            db.Areas.Add(newArea);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult List()
        {
            return View(db.Areas.ToList());
        }
        //Edit Area GET
        public IActionResult Edit(int id)
        {
            var thisArea = db.Areas.FirstOrDefault(x => x.AreaId == id);
            return View(thisArea);
        }
        //Edit Area POST
        [HttpPost]
        public IActionResult Edit(Area area)
        {
            db.Entry(area).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisArea = db.Areas.FirstOrDefault(x => x.AreaId == id);
            db.Areas.Remove(thisArea);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //list all Bays in selected Area
        public IActionResult Details(int id)
        {
            Area area = db.Areas.FirstOrDefault(x => x.AreaId == id);
            List<Bay> bays = db.Bays.Where(x => x.AreaId == id).ToList();
            AreaDetailVM VM = new AreaDetailVM(area, bays);
            return View(VM);
        }

    }
}

/*
 &&  
                            foreach (Area a in FailedAreaList)
                            {
                                area.AreaId != a.AreaId
                            };
     */
