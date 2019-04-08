using IdentityV2.Domain.Entities;
using IdentityV2.Service;
using IdentityV2.Presentation.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Web.Mvc;
using Rotativa;


namespace IdentityV2.Presentation.Controllers
{
    public class ProjectController : Controller
    {
        ServiceProject ps = new ServiceProject();
       
        CategoryService sc = new CategoryService();
        
        // GET: Project
        public ActionResult Index()
        {
            List<ProjectViewModel> lists = new List<ProjectViewModel>();
            foreach (var p in ps.GetProjectavailable())
            {
                ProjectViewModel pvm = new ProjectViewModel();
                pvm.ProjectId = p.ProjectId;
                pvm.Name = p.Name;
                pvm.Picture = p.Picture;
                pvm.Adress = new Adress { Address = p.Address.Address, Country = p.Address.Country, ZipCode = p.Address.ZipCode, Latitude = p.Address.Latitude, Longitude = p.Address.Longitude };
                pvm.DateBegin = p.DateBegin;
                pvm.DateEnd = p.DateEnd;
                pvm.TotalNbrRessources = p.TotalNbrRessources;
               
                pvm.Description = p.Description;
                lists.Add(pvm);

            }
            return View(lists);
        }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
           
            var p = ps.GetById(id);
            ProjectViewModel pvm = new ProjectViewModel();

            pvm.ProjectId = p.ProjectId;
            pvm.Name = p.Name;
            pvm.Picture = p.Picture;
            pvm.Adress = new Adress { Address = p.Address.Address, Country = p.Address.Country, ZipCode = p.Address.ZipCode, Latitude = p.Address.Latitude, Longitude = p.Address.Longitude };
            pvm.DateBegin = p.DateBegin;
            pvm.DateEnd = p.DateEnd;
            pvm.TotalNbrRessources = p.TotalNbrRessources;
          
            pvm.Description = p.Description;
            //pvm.ProjectSkills = p.ProjectSkills;
           
           

            return View(pvm);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            var categories = sc.GetAll();
            
            ViewBag.ListCat = new SelectList(categories, "CatId", "CatName");
            

            return View();
           
         
            
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(ProjectViewModel pvm)
        {
            Project p = new Project();
            p.ProjectId = pvm.ProjectId;
            p.Address = new Adress { Address = "tunis", ZipCode = 2040, Longitude = 11, Latitude = 15, Country = "tunis" };
            p.Name = pvm.Name;

            string filename = Path.GetFileNameWithoutExtension(pvm.ImageFile.FileName);
            string extension = Path.GetExtension(pvm.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            pvm.ImagePath = "~/Images/" + filename;
            filename = Path.Combine(Server.MapPath("~/Images/"), filename);
            pvm.ImageFile.SaveAs(filename);

            p.Picture = pvm.ImagePath;
            p.DateBegin = pvm.DateBegin;
            p.DateEnd = pvm.DateEnd;
            p.TotalNbrRessources = pvm.TotalNbrRessources;
           
            p.Description = pvm.Description;
            p.CatIdFK = pvm.CatIdFK;
           
            p.Etat = 1;
            ps.Add(p);
            ps.Commit();
            MailMessage mail = new MailMessage("chaima.benhsouna@esprit.tn","chames.benalaya@gmail.com", "Projet pret", "votre projet est maitenant assigné a un groupe d'ing");
            // MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("Smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;

            smtpClient.Credentials = new System.Net.NetworkCredential("chaima.benhsouna@esprit.tn", "chams123");
            smtpClient.Send(mail);
            return RedirectToAction("Index");
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            var p = ps.GetById(id);
            ProjectViewModel pvm = new ProjectViewModel();
            pvm.ProjectId = p.ProjectId;
            pvm.Name = p.Name;
            pvm.Picture = p.Picture;
            pvm.Adress = new Adress { Address = p.Address.Address, Country = p.Address.Country, ZipCode = p.Address.ZipCode, Latitude = p.Address.Latitude, Longitude = p.Address.Longitude };
            pvm.DateBegin = p.DateBegin;
            pvm.DateEnd = p.DateEnd;
            pvm.TotalNbrRessources = p.TotalNbrRessources;
            pvm.Description = p.Description;
            return View(pvm);
        }

        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProjectViewModel pvm)
        {
            Project p = ps.GetById(id);
            p.Name = pvm.Name;
            p.DateBegin = pvm.DateBegin;
            p.DateEnd = pvm.DateEnd;
            p.TotalNbrRessources = pvm.TotalNbrRessources;
            p.Description = pvm.Description;

            string filename = Path.GetFileNameWithoutExtension(pvm.ImageFile.FileName);
            string extension = Path.GetExtension(pvm.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            pvm.ImagePath = "~/Images/" + filename;
            filename = Path.Combine(Server.MapPath("~/Images/"), filename);
            pvm.ImageFile.SaveAs(filename);
            p.Picture = pvm.ImagePath;

            ps.Update(p);
            ps.Commit();

            return RedirectToAction("Index");
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            var p = ps.GetById(id);
            ProjectViewModel pvm = new ProjectViewModel();
            pvm.ProjectId = p.ProjectId;
            pvm.Name = p.Name;
            pvm.Picture = p.Picture;
            pvm.Adress = new Adress { Address = p.Address.Address, Country = p.Address.Country, ZipCode = p.Address.ZipCode, Latitude = p.Address.Latitude, Longitude = p.Address.Longitude };
            pvm.DateBegin = p.DateBegin;
            pvm.DateEnd = p.DateEnd;
            pvm.TotalNbrRessources = p.TotalNbrRessources;
            pvm.Description = p.Description;
            return View(pvm);
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ProjectViewModel pvm)
        {
            Project p = ps.GetById(id);
            p.Name = pvm.Name;
            p.Picture = pvm.Picture;
            p.DateBegin = pvm.DateBegin;
            p.DateEnd = pvm.DateEnd;
            p.TotalNbrRessources = pvm.TotalNbrRessources;
            p.Description = pvm.Description;
            ps.Delete(p);
            ps.Commit();

            return RedirectToAction("Index");
        }

        public ActionResult Listwaitingproject()
        {
            List<ProjectViewModel> lists = new List<ProjectViewModel>();
            foreach (var p in ps.GetProjectWaiting())
            {
                ProjectViewModel pvm = new ProjectViewModel();
                pvm.ProjectId = p.ProjectId;
                pvm.Name = p.Name;
                pvm.Picture = p.Picture;
                pvm.Adress = new Adress { Address = p.Address.Address, Country = p.Address.Country, ZipCode = p.Address.ZipCode, Latitude = p.Address.Latitude, Longitude = p.Address.Longitude };
                pvm.DateBegin = p.DateBegin;
                pvm.DateEnd = p.DateEnd;
                pvm.TotalNbrRessources = p.TotalNbrRessources;
                pvm.Description = p.Description;
                lists.Add(pvm);

            }

            return View(lists);
        }

        [HttpPost]
        public ActionResult Accept(int id, ProjectViewModel pvm)
        {
            Project p = new Project();
            p = ps.GetById(id);
            p.DateBegin = pvm.DateBegin;
            p.DateEnd = pvm.DateEnd;
            p.Description = pvm.Description;
            p.Etat = 1;

            string filename = Path.GetFileNameWithoutExtension(pvm.ImageFile.FileName);
            string extension = Path.GetExtension(pvm.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            pvm.ImagePath = "~/Images/" + filename;
            filename = Path.Combine(Server.MapPath("~/Images/"), filename);
            pvm.ImageFile.SaveAs(filename);
            p.Picture = pvm.ImagePath;


            ps.Update(p);
            ps.Commit();
            return RedirectToAction("Index");

        }

        public ActionResult Accept(int id)
        {
            var p = ps.GetById(id);
            ProjectViewModel pvm = new ProjectViewModel();
            pvm.ProjectId = p.ProjectId;
            pvm.Name = p.Name;
            pvm.Picture = p.Picture;
            pvm.Adress = new Adress { Address = p.Address.Address, Country = p.Address.Country, ZipCode = p.Address.ZipCode, Latitude = p.Address.Latitude, Longitude = p.Address.Longitude };
            pvm.DateBegin = p.DateBegin;
            pvm.DateEnd = p.DateEnd;
            pvm.TotalNbrRessources = p.TotalNbrRessources;
            pvm.Description = p.Description;
           // pvm.ProjectSkills = p.ProjectSkills;
            return View(pvm);

        }
      /*  public ActionResult Addskillsproject(int id)
        {

            List<SkillsModelView> lists = new List<SkillsModelView>();
            foreach (var item in ss.GetAll())
            {
                SkillsModelView dvm = new SkillsModelView();
                dvm.Skillsnum = item.SkillsId;
                dvm.name = item.name;
                dvm.Difficulity = item.Difficulity;
                dvm.Projectnum = id;
                lists.Add(dvm);

            }
            return View(lists);

        }

        [HttpPost]
        public ActionResult Addskillsproject()
        {
            string[] skillsid = Request["skillstoadd"].Split('/');

            foreach (var item in skillsid)
            {
                if (item.Length >= 1)
                {
                    Skillsofproject sop = new Skillsofproject();
                    sop.numproj = Convert.ToInt32(Request["projectid"]);
                    sop.numskill = Convert.ToInt32(item.ToString());

                    if (sps.testadd(sop.numproj, sop.numskill) == false)
                    {
                        sps.Add(sop);
                        sps.Commit();
                    }

                }

            }


            return RedirectToAction("Index");

        }*/


        public ActionResult PrintViewToPdf()
        {
            var report = new ActionAsPdf("Index");
            return report;
        }

    }







       

}
