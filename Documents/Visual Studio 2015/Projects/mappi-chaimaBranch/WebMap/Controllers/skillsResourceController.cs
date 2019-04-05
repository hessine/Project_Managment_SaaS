using DataMap;
using DomainMap.Entities;
using ServiceMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMap.Models;

namespace WebMap.Controllers
{
    public class skillsResourceController : Controller
    {
        ServiceSkills SS = new ServiceSkills();
        ResourceService RS = new ResourceService();
        ResourceSkills RSS = new ResourceSkills();
        // GET: skillsResource
        public ActionResult Index()
        {
            return View();
        }

        // GET: skillsResource/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: skillsResource/Create
        public ActionResult Create()
        {
            List<SkillsViewModels> lists = new List<SkillsViewModels>();
            foreach (var item in SS.GetAll())
            {
                SkillsViewModels dvm = new SkillsViewModels();
                dvm.SkillsId = item.SkillsId;
                dvm.name = item.name;
                dvm.Difficulity = item.Difficulity;
               


                lists.Add(dvm);

            }
            return View(lists);
            
        }

        // POST: skillsResource/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: skillsResource/Edit/5
        public ActionResult Edit(int id)
        {
            //List<SkillsViewModels> lists = new List<SkillsViewModels>();
            //foreach (var item in SS.GetAll())
            //{


            //    dvm.SkillsId = item.SkillsId;

            //    dvm.name = item.name;
            //    dvm.Difficulity = item.Difficulity;



            //    lists.Add(dvm);

            //}
            List< SkillsViewModels> dvm = new List< SkillsViewModels>();

            foreach (var item in SS.GetAll())
            {
                SkillsViewModels bvm1 = new SkillsViewModels();
                bvm1.SkillsId = item.SkillsId;

                bvm1.name = item.name;
                dvm.Add(bvm1);

            }
            
            
            ViewData["skill"] = new SelectList(dvm, "name", "name");
            return View();
        }

        // POST: skillsResource/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,int idS )
        {
            resourceSkills rs = new resourceSkills();
            
            rs.SkillsId = idS;
            rs.userId = 1;


            //Skills s = SS.GetById(1);
            // Resource r = RS.GetById(1);
            // // r.FirstName = "bbbb";
            //  r.ResourceSkills.Add(s);
            //// s.ResourceSkills.Add(r);

            //  //  r.LastName = RVM.LastName;
            //  // r.Contrat =(DomainMap.Entities.TypeContrat) RVM.Contrat;
            //  //  r.BuissnesSector = RVM.BuissnesSector;
            //  //  r.PhoneNumber = RVM.PhoneNumber;

            // RS.Update(r);
            ////  SS.Update(s);
            //RS.Commit();
            RSS.Add(rs);
            RSS.Commit();
            // SS.Commit();
            return RedirectToAction("EDIT");

        }

        // GET: skillsResource/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: skillsResource/Delete/5
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

        public ActionResult addSkillsResource(int id)
        {
            List<SkillsViewModels> lists = new List<SkillsViewModels>();
            foreach (var item in SS.GetAll())
            {
                SkillsViewModels dvm = new SkillsViewModels();
                dvm.SkillsId = item.SkillsId;
                dvm.name = item.name;
                dvm.Difficulity = item.Difficulity;
                dvm.userId = id;
                lists.Add(dvm);

            }
            return View(lists);
        }
        [HttpPost]
        public ActionResult addSkillsResource()
        {
            string[] skillsid = Request["skillstoadd"].Split('/');

            foreach (var item in skillsid)
            {
                if (item.Length >= 1)
                {
                    resourceSkills rss = new resourceSkills();
                    rss.userId = Convert.ToInt32(Request["userId"]);
                    rss.SkillsId = Convert.ToInt32(item.ToString());

                    if (RSS.testadd(rss.userId, rss.SkillsId) == false)
                    {
                        RSS.Add(rss);
                        
                    }

                }

            }
            RSS.Commit();


            return RedirectToAction("Index");

        }

    }
}
