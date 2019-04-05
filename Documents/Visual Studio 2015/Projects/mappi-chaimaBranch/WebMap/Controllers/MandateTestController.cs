using DomainMap;
using DomainMap.Entities;
using Rotativa;
using ServiceMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebMap.Models;

namespace WebMap.Controllers
{
    public class MandateTestController : Controller
    {
        List<Resource> listR = new List<Resource>();
        List<Skills> listS = new List<Skills>();
        List<Resource> listRA = new List<Resource>();
        List<Skills> listSA = new List<Skills>();
        List<SkillsOfProjectService> listSOF = new List<SkillsOfProjectService>();
        List<Mandate> listM = new List<Mandate>();
        List<Project> listP = new List<Project>();
        //    List<Skills> listSR = new List<Skills>();
        IServiceMandate Sm = new ServiceMandate();
        IServiceProject sp = new ServiceProject();
        IServiceResource rs = new ServiceResource();
        ResourceSkills rss = new ResourceSkills();
        IServiceEvent se = new ServiceEvent();
        IServiceHistoricalMandate shm = new ServiceHistoricalMandate();
        SkillsOfProjectService sop = new SkillsOfProjectService();
        
       // GET: MandateTest
            public ActionResult Index()
        {

            List<MandateViewModel> listmv = new List<MandateViewModel>();
            foreach (var item in Sm.GetAll())
            {
                MandateViewModel mv = new MandateViewModel();
                Project p = sp.GetById(item.ProjectId);
                Resource r = rs.GetById(item.userId);
                // mv.projet.Name = item.projet.Name;
                mv.ProjectId = p.ProjectId;
                mv.Name = p.Name;
                mv.FirstName = r.FirstName;
                mv.LastName = r.LastName;
                mv.mandat = (TypeMandate)item.mandat;
                // mv.ProjectId = item.ProjectId;
                mv.userId = item.userId;
                TimeSpan dur = item.DateEnd.Subtract(item.DateBegin);
                var dt = Convert.ToInt32(dur.TotalDays);
                mv.Duree = item.Duree;

                mv.DateBegin = item.DateBegin;
                mv.DateEnd = item.DateEnd;
                var d = Convert.ToDouble(item.Duree) * 1.8;
                var c = (item.Cost / 30 * d);
                mv.Cost = Convert.ToInt64(c);
                TimeSpan diffResult = item.DateEnd.Subtract(DateTime.Today);
                // int d3 = (int)(item.DateEnd - item.DateEnd).TotalDays;
                if (diffResult.TotalDays == 40)
                {
                    try
                    {

                        MailMessage mail = new MailMessage("narjes.seffen@esprit.tn", r.Email, "Fin Mandat", "votre mandat va s'achever dans 40 jours");
                        // MailMessage mail = new MailMessage();
                        mail.IsBodyHtml = true;
                        SmtpClient smtpClient = new SmtpClient("Smtp.gmail.com", 587);
                        smtpClient.EnableSsl = true;

                        smtpClient.Credentials = new System.Net.NetworkCredential("narjes.seffen@esprit.tn", "N12814090S");
                        smtpClient.Send(mail);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                    }
                }


                listmv.Add(mv);
            }

            return View(listmv);
        }
        [HttpPost]
        public ActionResult Index(string searchString)
        {

            List<MandateViewModel> listmv = new List<MandateViewModel>();
            foreach (var item in Sm.GetAll())
            {
                MandateViewModel mv = new MandateViewModel();
                Project p = sp.GetById(item.ProjectId);
                Resource r = rs.GetById(item.userId);
                // mv.projet.Name = item.projet.Name;
                mv.ProjectId = p.ProjectId;
                mv.Name = p.Name;
                mv.FirstName = r.FirstName;
                mv.LastName = r.LastName;

                // mv.ProjectId = item.ProjectId;
                mv.userId = item.userId;

                TimeSpan diffResult = item.DateEnd.Subtract(item.DateBegin);

                mv.DateBegin = item.DateBegin;
                mv.DateEnd = item.DateEnd;
                // mv.TypeMandate = item.TypeMandate;
                var d = Convert.ToDouble(item.Duree) * 1.8;
                var c = (item.Cost / 30 * d);
                mv.Cost = Convert.ToInt64(c);
                listmv.Add(mv);
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                listmv = listmv.Where(m => m.Name.Contains(searchString)).ToList();
            }
            return View(listmv);
        }
        // GET: MandateTest/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MandateTest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MandateTest/Create
        [HttpPost]
        public ActionResult Create(MandateViewModel collection, int idP, int idR)
        {
            Project p = sp.Get(a => a.ProjectId == idP);

            int result = DateTime.Compare(collection.DateBegin, collection.DateEnd);

            //listS = p.ProjectSkills.ToList();
            listR = rs.GetAll().Where(a => a.Id == idR).ToList();
            // listR = rs.GetAll().ToList();
            listM = Sm.GetAll().ToList();

            //foreach (var item in listS)
            //{
            //    foreach (var item2 in listR)
            //    {
            //        foreach (var item3 in item2.ResourceSkills)

            //        {
            Mandate m = new Mandate() { mandat = collection.mandat };
            m.ProjectId = p.ProjectId;
            m.Cost = collection.Cost;
            m.DateBegin = collection.DateBegin;
            m.DateEnd = collection.DateEnd;
            TimeSpan dur = collection.DateEnd.Subtract(collection.DateBegin);
            var dt = Convert.ToInt32(dur.TotalDays);
            m.Duree = dt;
            // m.Duree = collection.Duree;
            m.userId = idR;
            m.mandat = (TypeMandate)collection.mandat;


            Resource u = rs.GetById(idR);
            u.Availability = DomainMap.Entities.TypeAvailability.NotAvailable;

            if (/*(item.SkillsId == item3.SkillsId) && (item2.Availability == 0) &&*/ collection.DateBegin > collection.DateEnd)
            {
                ViewBag.text = "date debut doit etre inferieur date fin";
                // return RedirectToAction("Create");
            }
            else if (collection.DateBegin < collection.DateEnd)
            {


                
                rs.Update(u);
                rs.Commit();
                Sm.Add(m);

                Sm.Commit();
                Events e = new Events();
                e.Start = collection.DateBegin;
                e.End = collection.DateEnd;
                Project p1 = sp.GetById(p.ProjectId);
                //  e.Description = collection.Name;
                e.Description = p1.Name;

                se.Add(e);
                se.Commit();
                return RedirectToAction("Index");

            }

            //        }
            //    }
            //}




            //return View();
            return View();
            //  return RedirectToAction("Index");

        }

        // GET: Mandate/Edit/5
        public ActionResult Edit(int idP, int idR)
        {

            Mandate m = Sm.GetAll().Where(a => a.ProjectId == idP).Where(t => t.userId == idR).First();
            MandateViewModel mv = new MandateViewModel();
            mv.Cost = m.Cost;
            mv.DateBegin = m.DateBegin;
            mv.DateEnd = m.DateEnd;
            mv.Duree = m.Duree;
            mv.ProjectId = m.ProjectId;
            mv.userId = m
                .userId;
            Project p = sp.GetById(m.ProjectId);
            Resource r = rs.GetById(m.userId);
            mv.Name = p.Name;
            mv.LastName = r.LastName;
            mv.FirstName = r.FirstName;
            return View(mv);


        }

        // POST: Mandate/Edit/5
        [HttpPost]
        public ActionResult Edit(int idP, int idR, MandateViewModel collection)
        {
            Mandate m = Sm.GetAll().Where(a => a.ProjectId == idP).Where(t => t.userId == idR).First();

            m.DateBegin = collection.DateBegin;
            m.DateEnd = collection.DateEnd;
            //TimeSpan dur = collection.DateEnd.Subtract(collection.DateBegin);
            //var dt = Convert.ToInt32(dur.TotalDays);
            int result = DateTime.Compare(collection.DateBegin, collection.DateEnd);
            m.Cost = collection.Cost;
            //m.Duree = dt;
            if (result < 0)
            {
                Sm.Update(m);
                Sm.Commit();


            }
            return RedirectToAction("Index");
        }
        // GET: Mandate/Delete/5
        public ActionResult Delete(int idP, int idR)
        {
            Mandate m = Sm.GetAll().Where(a => a.ProjectId == idP).Where(t => t.userId == idR).First();
            MandateViewModel mv = new MandateViewModel();
            mv.Cost = m.Cost;
            mv.DateBegin = m.DateBegin;
            mv.DateEnd = m.DateEnd;
            mv.Duree = m.Duree;
            Project p = sp.GetById(m.ProjectId);
            Resource r = rs.GetById(m.userId);
            mv.Name = p.Name;
            mv.LastName = r.LastName;
            mv.FirstName = r.FirstName;
            mv.ProjectId = m.ProjectId;
            mv.userId = m
                .userId;
            return View(mv);

        }

        // POST: Mandate/Delete/5
        [HttpPost]
        public ActionResult Delete(int idP, int idR, MandateViewModel collection)
        {
            Mandate m = Sm.GetAll().Where(a => a.ProjectId == idP).Where(t => t.userId == idR).First();
            HistoricalMandate hm = new HistoricalMandate();
            hm.DateBegin = m.DateBegin;
            hm.DateEnd = m.DateEnd;
            hm.Cost = m.Cost;
            hm.Duree = m.Duree;
            hm.ProjectId = idP;
            hm.userId = idR;
            shm.Add(hm);

            m.DateBegin = collection.DateBegin;
            m.DateEnd = collection.DateEnd;
            TimeSpan dur = collection.DateEnd.Subtract(collection.DateBegin);
            var dt = Convert.ToInt32(dur.TotalDays);
            m.Cost = collection.Cost;
            m.Duree = dt;
            Resource r = rs.GetById(m.userId);
            r.Availability = DomainMap.Entities.TypeAvailability.Available;
            rs.Update(r);
            rs.Commit();

            Sm.Delete(m);
            shm.Commit();
            Sm.Commit();



            return RedirectToAction("Index");
        }
        public ActionResult getAllProjects()
        {
            List<ProjectViewModel> listmv = new List<ProjectViewModel>();
            foreach (var item in sp.GetAll())
            {
                ProjectViewModel pv = new ProjectViewModel();
                pv.ProjectId = item.ProjectId;
                pv.Name = item.Name;
                pv.DateBegin = item.DateBegin;
                pv.DateEnd = item.DateEnd;
                listmv.Add(pv);
            }
            return View(listmv);
        }
        ////GET : MandateTest/AssignResource
        //public ActionResult AssignResource()
        //{
        //    return View();
        //}
        //[HttpPost]

        public ActionResult AssignResource(int id)

        {

            List<ResourceViewModel> listr = new List<ResourceViewModel>();

            Project p = sp.Get(a => a.ProjectId == id);
            var l = sop.listskills(p.ProjectId);

            var aa = rss.GetAll().ToList();
            // listSA = p.ProjectSkills.ToList();
           // listRA = rs.GetAll().ToList();
            // listM = Sm.GetAll().ToList();

            foreach (var item in l)
            {
                
                    foreach (var item3 in aa)
                    {
                    foreach(var item2 in rs.GetAll().Where(a=>a.Id==item3.userId).ToList())

                    {

                        if ((item.numskill == item3.SkillsId) && (item2.Availability == 0))
                        {


                            ResourceViewModel r = new ResourceViewModel();

                            r.FirstName = item2.FirstName;
                            r.LastName = item2.LastName;
                            r.userId = item2.Id;
                            // r.Availability = (TypeAvailability)Enum.GetValues; ;
                            r.BuissnesSector = item2.BuissnesSector;
                            r.ProjectId = id;
                            r.Email = item2.Email;
                            r.Contrat = (DomainMap.Entities.TypeContrat)item2.Contrat;
                            listr.Add(r);
                            MailMessage mail = new MailMessage("narjes.seffen@esprit.tn", item2.Email, "Assignation Mandat", "Vous etes Assigne a un mandat");
                            // MailMessage mail = new MailMessage();
                            mail.IsBodyHtml = true;
                            SmtpClient smtpClient = new SmtpClient("Smtp.gmail.com", 587);
                            smtpClient.EnableSsl = true;

                            smtpClient.Credentials = new System.Net.NetworkCredential("narjes.seffen@esprit.tn", "N12814090S");
                            smtpClient.Send(mail);



                        }
                    }

                }
            }
            

            List<ResourceViewModel> ll = new List<ResourceViewModel>();



            return View(listr.GroupBy(x => x.userId, (key, x) => x.FirstOrDefault()));

        }
        public ActionResult MandateInProcess()
        {
            List<Mandate> listH = new List<Mandate>();
            listH = Sm.GetAll().Where(a => a.DateEnd.CompareTo(DateTime.Today) < 0).ToList();
            List<MandateViewModel> listmv = new List<MandateViewModel>();
            foreach (var item in listH)
            {
                Project p = sp.GetById(item.ProjectId);
                Resource r = rs.GetById(item.userId);
                MandateViewModel mv = new MandateViewModel();
                TimeSpan dur = item.DateEnd.Subtract(item.DateBegin);
                var dt = Convert.ToInt32(dur.TotalDays);
                mv.Duree = dt;

               // mv.Duree = item.Duree;
                mv.DateBegin = item.DateBegin;
                mv.DateEnd = item.DateEnd;
                mv.Cost = item.Cost;
                mv.Name = p.Name;
                mv.FirstName = r.FirstName;
                mv.LastName = r.LastName;
                listmv.Add(mv);
            }

            return View(listmv);
        }
        public ActionResult HistoricalMandate()
        {
            List<HistoricalMandate> listH = new List<HistoricalMandate>();
            listH = shm.GetAll().ToList();
            List<MandateViewModel> listmv = new List<MandateViewModel>();
            foreach (var item in listH)
            {
                Project p = sp.GetById(item.ProjectId);
                Resource r = rs.GetById(item.userId);
                MandateViewModel mv = new MandateViewModel();
                //mv.Duree = item.Duree;
                mv.DateBegin = item.DateBegin;
                mv.DateEnd = item.DateEnd;
                mv.Cost = item.Cost;
                TimeSpan dur = item.DateEnd.Subtract(item.DateBegin);
                var dt = Convert.ToInt32(dur.TotalDays);
                mv.Duree = dt;
           
                mv.Name = p.Name;
                mv.FirstName = r.FirstName;
                mv.LastName = r.LastName;
                listmv.Add(mv);
            }

            return View(listmv);
        }

        public ActionResult PrintViewToPdf()
        {
            var report = new ActionAsPdf("HistoricalMandate");
            return report;
        }
    }

}