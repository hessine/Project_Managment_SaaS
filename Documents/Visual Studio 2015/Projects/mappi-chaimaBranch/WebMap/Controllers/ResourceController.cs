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
    //public enum TypeContart { Freelancer, Employee }
    //public enum TypeAvailability { Available, NotAvailable, AvailableSoon }
    public class ResourceController : Controller
    {
        ServiceSkills SS = new ServiceSkills();
        ResourceSkills RSS = new ResourceSkills();
        ResourceService RS = new ResourceService();
        // GET: Resource
        public ActionResult Index()
        {
            List<ResourceViewModel> lists = new List<ResourceViewModel>();
            foreach (var item in RS.GetAll().Where(s => s.archive == false))
            {
                ResourceViewModel dvm = new ResourceViewModel();
                dvm.FirstName = item.FirstName;
                dvm.LastName = item.LastName;
                dvm.PictureResource = item.PictureResource;
                dvm.Email = item.Email;
                dvm.BuissnesSector = item.BuissnesSector;
                dvm.Availability = item.Availability;
                dvm.ID = item.Id;
                dvm.Contrat = item.Contrat;


                lists.Add(dvm);

            }
            return View(lists);
        }

        // GET: Resource/Details/5
        public ActionResult Details(int id)
        {
            var Res = RS.GetById(id);


            ResourceViewModel bvm = new ResourceViewModel();
            bvm.ID = id;
            bvm.FirstName = Res.FirstName;
            bvm.LastName = Res.LastName;
            bvm.PictureResource = Res.PictureResource;
            bvm.Email = Res.Email;
            bvm.PhoneNumber = Res.PhoneNumber;
            bvm.Contrat = Res.Contrat;

            IList<string> skillResourceList = new List<string>();
            foreach (var item in RSS.GetAll().Where(s=>s.userId==id))
            {
                Skills s = new Skills();
                s = SS.GetById(item.SkillsId); 
                skillResourceList.Add(s.name);
            }
            ViewData["listSkills"] = skillResourceList;

            return View(bvm);
        }

  

        // GET: Resource/Edit/5
        public ActionResult Edit(int id)
        {
            var R = RS.GetById(id);
            ResourceViewModel RVM = new ResourceViewModel();
            RVM.FirstName = R.FirstName;
            RVM.LastName = R.LastName;
            RVM.Contrat.Equals(R.Contrat);
            RVM.BuissnesSector = R.BuissnesSector;
            RVM.PhoneNumber = R.PhoneNumber;
            return View(RVM);
        }

        // POST: Resource/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ResourceViewModel RVM)
        {
            Resource r = RS.GetById(id);
            r.FirstName = RVM.FirstName;
           r.LastName = RVM.LastName;
            r.Contrat =(DomainMap.Entities.TypeContrat)RVM.Contrat;
            r.BuissnesSector = RVM.BuissnesSector;
            r.PhoneNumber = RVM.PhoneNumber;
            
            RS.Update(r);
            RS.Commit();
            
           return RedirectToAction("Index");
           
        }

        // GET: Resource/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Resource/Delete/5
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
        public ActionResult AddSkill(SkillsViewModels skill)
        {
          //  ServiceSkills SS = new ServiceSkills();
            
            int idPer = (int)Session["IdSelected"];
           // RS.AddSkill()
          //  string msg = string.Empty;

            //Creating Mapping
           // Mapper.Initialize(cfg => cfg.CreateMap<SkillsViewModels, Skills>());
          //  Skills skillEntity = Mapper.Map<Skills>(skill);

         /*   if (_resumeRepository.AddSkill(skillEntity, idPer))
            {
                msg = "skill added successfully";
            }
            else
            {
                msg = "something Wrong";
            }*/

            return Json(new { data ="ff" }, JsonRequestBehavior.AllowGet);
        }
        //GET: Resource/Archive/5
        public ActionResult Archive(int id)
        {
            Resource r = RS.GetById(id);
            r.archive = true;

            RS.Update(r);
            RS.Commit();

            return RedirectToAction("Index");

        }

        // GET: Resource
        public ActionResult IndexArchive()
        {
            List<ResourceViewModel> lists = new List<ResourceViewModel>();
            foreach (var item in RS.GetAll().Where(s => s.archive == true))
            {
                ResourceViewModel dvm = new ResourceViewModel();
                dvm.FirstName = item.FirstName;
                dvm.LastName = item.LastName;
                dvm.PictureResource = item.PictureResource;
                dvm.Email = item.Email;
                dvm.BuissnesSector = item.BuissnesSector;
                dvm.Availability = item.Availability;
                dvm.ID = item.Id;
                dvm.Contrat =item.Contrat;


                lists.Add(dvm);

            }
            return View(lists);
        }

    }
}
