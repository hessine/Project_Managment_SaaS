using DomainMap.Entities;
using Rotativa;
using ServiceMap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebMap.Models;

namespace WebMap.Controllers
{
    public class ProjectController : Controller
    {
        ServiceProject ps = new ServiceProject();
        ServiceClient scc = new ServiceClient();
        CategoryService sc = new CategoryService();
        ServiceSkills ss = new ServiceSkills();
        SkillsOfProjectService sps = new SkillsOfProjectService();
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
            var s = sps.listskills(id);
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
            pvm.ListResource = p.ListResource;
            ViewBag.skills = "";
            foreach (var item in s)
            {
                ViewBag.skills += ss.GetById(item.numskill).name + "/";
            }

            return View(pvm);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            var clients = scc.GetAll();
            List<ClientViewModel> lbvm = new List<ClientViewModel>();
            ClientViewModel bvm = new ClientViewModel();

            foreach (var item in clients)
            {
                bvm.Id = item.Id;
                bvm.FirstName = item.FirstName;
                bvm.LastName = item.LastName;
                lbvm.Add(bvm);
                
            }

            ViewData["clients"] = new SelectList(lbvm, "Id", "FirstName");
            var categories = sc.GetAll();
            List<CategoryVM> cabvm = new List<CategoryVM>();
            CategoryVM cbvm = new CategoryVM();

            foreach (var item in categories)
            {
                cbvm.CatId = item.CatId;
                cbvm.CatName = item.CatName;
                cabvm.Add(cbvm);
            }

            ViewData["categories"] = new SelectList(cabvm, "CatId", "CatName");

         

            

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
        public ActionResult Addskillsproject(int id)
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

        }


        public ActionResult PrintViewToPdf()
        {
            var report = new ActionAsPdf("Index");
            return report;
        }

    }







       

}
