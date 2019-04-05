using DomainMap.Entities;
using ServiceMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMap.Models;
using Microsoft.AspNet.Identity;

namespace WebMap.Controllers
{
    public class RequiredSkillsController : Controller
    {

        IServiceRequiredSkills serviceRS = new ServiceRequiredSkills();
        // GET: RequiredSkills
        public ActionResult Index()
        {
            return View();
        }

        // GET: RequiredSkills/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RequiredSkills/Create
        public ActionResult Create()
        {
            return View();
        }

       

    // GET: RequiredSkills/Edit/5
    public ActionResult Edit(int id)
    {
            var RS = serviceRS.GetById(id);
                   RequiredSkillsViewModel RSVM = new RequiredSkillsViewModel();
            RSVM.education= RS.education;
            RSVM.experience = RS.experience;
            RSVM.profil = RS.profil;




            return View(RSVM);
        }

    // POST: RequiredSkills/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, RequiredSkillsViewModel RVM)
        {
            
            RequiredSkills reqSkill = serviceRS.GetById(id);


            reqSkill.education = RVM.education;
            reqSkill.experience = RVM.experience;
           


            serviceRS.Update(reqSkill);
            serviceRS.Commit();
            return RedirectToAction("Edit","Request",new { id=reqSkill.requestId});

        }


        // GET: RequiredSkills/Delete/5
        public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: RequiredSkills/Delete/5
    [HttpPost]
    public ActionResult Delete(int id, FormCollection collection)
    {
        try
        {
            // TODO: Add delete logic here

            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }
}
}
