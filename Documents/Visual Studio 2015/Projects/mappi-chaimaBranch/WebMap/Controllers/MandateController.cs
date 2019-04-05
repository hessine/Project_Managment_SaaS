using DataMap;
using DomainMap;
using DomainMap.Entities;
using Rotativa;
using ServiceMap;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Net.Mail;
using System.Web;

using System.Web.Mvc;
using WebMap.Controllers;
using WebMap.Models;

namespace WebMap.Controllers
{
   // public enum TypeMandate { Inter_Mandate, Mandate }
    //public enum TypeAvailability { Available, NotAvailable, AvailableSoon }
    public class MandateController : Controller
    {

        List<Resource> listR = new List<Resource>();
        List<Skills> listS = new List<Skills>();
        List<Mandate> listM = new List<Mandate>();
        List<Project> listP = new List<Project>();
        //    List<Skills> listSR = new List<Skills>();
        IServiceMandate Sm = new ServiceMandate();
        IServiceProject sp = new ServiceProject();
        IServiceResource rs = new ServiceResource();
        IServiceEvent se = new ServiceEvent();
        IServiceHistoricalMandate shm = new ServiceHistoricalMandate();
        


        // GET: Mandate
        //public ActionResult Index()
        //{

        //    List<MandateViewModel> listmv = new List<MandateViewModel>();
        //    foreach (var item in Sm.GetAll())
        //    {
        //        MandateViewModel mv = new MandateViewModel();
        //        Project p = sp.GetById(item.ProjectId);
        //        Resource r = rs.GetById(item.userId);
        //        // mv.projet.Name = item.projet.Name;
        //        mv.ProjectId = p.ProjectId;
        //        mv.Name = p.Name;
        //        mv.FirstName = r.FirstName;
        //        mv.LastName = r.LastName;
        //        mv.mandat=(TypeMandate)item.mandat;
        //        // mv.ProjectId = item.ProjectId;
        //        mv.userId = item.userId;
        //      //  mv.Duree = item.Duree;

        //        mv.DateBegin = item.DateBegin;
        //        mv.DateEnd = item.DateEnd;
        //        var d = Convert.ToDouble(item.Duree) * 1.8;
        //        var c = (item.Cost / 30 * d);
        //        mv.Cost = Convert.ToInt64(c);
        //        TimeSpan diffResult = item.DateEnd.Subtract(DateTime.Today);
        //       // int d3 = (int)(item.DateEnd - item.DateEnd).TotalDays;
        //        if (diffResult.TotalDays==40)
        //        {
        //            try
        //            {

        //                MailMessage mail = new MailMessage("narjes.seffen@esprit.tn", r.Email, "Fin Mandat", "votre mandat va s'achever dans 40 jours");
        //                // MailMessage mail = new MailMessage();
        //                mail.IsBodyHtml = true;
        //                SmtpClient smtpClient = new SmtpClient("Smtp.gmail.com", 587);
        //                smtpClient.EnableSsl = true;

        //                smtpClient.Credentials = new System.Net.NetworkCredential("narjes.seffen@esprit.tn", "N12814090S");
        //                smtpClient.Send(mail);

        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine(ex.StackTrace);
        //            }
        //        }


        //        listmv.Add(mv);
        //    }

        //    return View(listmv);
        //}
        //[HttpPost]
        //public ActionResult Index(string searchString)
        //{

        //    List<MandateViewModel> listmv = new List<MandateViewModel>();
        //    foreach (var item in Sm.GetAll())
        //    {
        //        MandateViewModel mv = new MandateViewModel();
        //        Project p = sp.GetById(item.ProjectId);
        //        Resource r = rs.GetById(item.userId);
        //        // mv.projet.Name = item.projet.Name;
        //        mv.ProjectId = p.ProjectId;
        //        mv.Name = p.Name;
        //        mv.FirstName = r.FirstName;
        //        mv.LastName = r.LastName;

        //        // mv.ProjectId = item.ProjectId;
        //        mv.userId = item.userId;
        //      //  mv.Duree = item.Duree;

        //        mv.DateBegin = item.DateBegin;
        //        mv.DateEnd = item.DateEnd;
        //       // mv.TypeMandate = item.TypeMandate;
        //        var d = Convert.ToDouble(item.Duree) * 1.8;
        //        var c = (item.Cost / 30 * d);
        //        mv.Cost = Convert.ToInt64(c);
        //        listmv.Add(mv);
        //    }
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        listmv = listmv.Where(m => m.Name.Contains(searchString)).ToList();
        //    }
        //    return View(listmv);
        //}



        //// GET: Mandate/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Mandate/Create
        //public ActionResult Create()
        //{


        //    var clt = sp.GetAll();


        //    ViewBag.clt = new SelectList(clt, "ProjectId", "Name");


        //    return View();
        //}

        //// POST: Mandate/Create
        //[HttpPost]
        //public ActionResult Create(MandateViewModel collection)
        //{
           
        //    Project p = sp.Get(a => a.ProjectId == collection.ProjectId);

        //    int result = DateTime.Compare(collection.DateBegin, collection.DateEnd);

        //    listS = p.ProjectSkills.ToList();
        //    listR = rs.GetAll().ToList();
        //    listM = Sm.GetAll().ToList();

        //    foreach (var item in listS)
        //    {
        //        foreach (var item2 in listR)
        //        {
        //            foreach (var item3 in item2.ResourceSkills)
                       
        //            {

                        
        //                if ((item.SkillsId == item3.SkillsId) && (item2.Availability == 0) && (result < 0))
        //                {

        //                    Mandate m = new Mandate() { mandat= collection.mandat };
        //                    m.ProjectId = p.ProjectId;
        //                    m.Cost = collection.Cost;
        //                    m.DateBegin = collection.DateBegin;
        //                    m.DateEnd = collection.DateEnd;
        //               //     m.Duree = collection.Duree;
        //                    m.userId = item2.Id;
        //                   // m.mandat = (TypeMandate)collection.mandat;
                         

        //                    Resource u = rs.GetById(item2.Id);
        //                    u.Availability = DomainMap.Entities.TypeAvailability.NotAvailable;

        //                    MailMessage mail = new MailMessage("narjes.seffen@esprit.tn", item2.Email, "Assignation Mandat", "Vous etes Assigne a un mandat qui debute le" + collection.DateBegin + " et se termine le  " + collection.DateEnd );
        //                    // MailMessage mail = new MailMessage();
        //                    mail.IsBodyHtml = true;
        //                    SmtpClient smtpClient = new SmtpClient("Smtp.gmail.com", 587);
        //                    smtpClient.EnableSsl = true;

        //                    smtpClient.Credentials = new System.Net.NetworkCredential("narjes.seffen@esprit.tn", "N12814090S");
        //                    smtpClient.Send(mail);
        //                    rs.Update(u);
        //                    rs.Commit();
        //                    Sm.Add(m);
        //                    Sm.Commit();



        //                }
        //            }
        //        }


        //    }
        //    Events e = new Events();
        //    e.Start = collection.DateBegin;
        //    e.End = collection.DateEnd;
        //    Project p1 = sp.GetById(p.ProjectId);
        //    //  e.Description = collection.Name;
        //    e.Description = p1.Name;

        //    se.Add(e);
        //    se.Commit();
        //   // return View();
        //    return RedirectToAction("Index");

        //}

        //// GET: Mandate/Edit/5
        //public ActionResult Edit(int idP, int idR)
        //{

        //    Mandate m = Sm.GetAll().Where(a => a.ProjectId == idP).Where(t => t.userId == idR).First();
        //    MandateViewModel mv = new MandateViewModel();
        //    mv.Cost = m.Cost;
        //    mv.DateBegin = m.DateBegin;
        //    mv.DateEnd = m.DateEnd;
        //   // mv.Duree = m.Duree;
        //    mv.ProjectId = m.ProjectId;
        //    mv.userId = m
        //        .userId;
        //    return View(mv);


        //}

        //// POST: Mandate/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int idP, int idR, MandateViewModel collection)
        //{
        //    Mandate m = Sm.GetAll().Where(a => a.ProjectId == idP).Where(t => t.userId == idR).First();
        //    m.DateBegin = collection.DateBegin;
        //    m.DateEnd = collection.DateEnd;
        //    m.Cost = collection.Cost;
        //    m.Duree = collection.Duree;
        //    Sm.Update(m);
        //    Sm.Commit();

        //    return RedirectToAction("Index");

        //}

        //// GET: Mandate/Delete/5
        //public ActionResult Delete(int idP, int idR)
        //{
        //    Mandate m = Sm.GetAll().Where(a => a.ProjectId == idP).Where(t => t.userId == idR).First();
        //    MandateViewModel mv = new MandateViewModel();
        //    mv.Cost = m.Cost;
        //    mv.DateBegin = m.DateBegin;
        //    mv.DateEnd = m.DateEnd;
        //  //  mv.Duree = m.Duree;
        //    mv.ProjectId = m.ProjectId;
        //    mv.userId = m
        //        .userId;
        //    return View(mv);

        //}

        //// POST: Mandate/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int idP, int idR, MandateViewModel collection)
        //{
        //    Mandate m = Sm.GetAll().Where(a => a.ProjectId == idP).Where(t => t.userId == idR).First();
        //    HistoricalMandate hm = new HistoricalMandate();
        //    hm.DateBegin = m.DateBegin;         
        //    hm.DateEnd = m.DateEnd;
        //    hm.Cost = m.Cost;
        //  //  hm.Duree =m.Duree;
        //    hm.ProjectId = m.ProjectId;
        //    hm.userId = m.userId;
        //    shm.Add(hm);
           
        //    m.DateBegin = collection.DateBegin;
        //    m.DateEnd = collection.DateEnd;
        //    m.Cost = collection.Cost;
        //    m.Duree = collection.Duree;

          
        //    Sm.Delete(m);
        //    shm.Commit();
        //    Sm.Commit();



        //    return RedirectToAction("Index");
        //}
        //////GET:AssignResource
        ////[HttpPost]
        ////public ActionResult AssignResource()

        ////{
        ////    //var clt = sp.GetAll();


        ////    //ViewBag.clt = new SelectList(clt, "ProjectId", "Name");
        ////    List<ResourceViewModel> listr = new List<ResourceViewModel>();

        ////    Project p = sp.Get(a => a.ProjectId == 6);

        ////    listS = p.ProjectSkills.ToList();
        ////    listR = rs.GetAll().ToList();
        ////    listM = Sm.GetAll().ToList();

        ////    foreach (var item in listS)
        ////    {
        ////        foreach (var item2 in listR)

        ////        {
        ////            foreach (var item3 in item2.ResourceSkills)
        ////            {

        ////                if ((item.SkillsId == item3.SkillsId) && (item2.Availability == 0))
        ////                {
        ////                    ResourceViewModel r = new ResourceViewModel();
        ////                    r.FirstName = item2.FirstName;
        ////                    r.LastName = item2.LastName;
        ////                    // r.Availability = (TypeAvailability)Enum.GetValues; ;
        ////                    r.BuissnesSector = item2.BuissnesSector;
        ////                    listr.Add(r);

        ////                }
        ////            }
        ////        }
        ////    }

        ////    return View(listr);

        ////}

        //public ActionResult MandateInProcess()
        //{
        //    List<Mandate> listH = new List<Mandate>();
        //    listH = Sm.GetAll().Where(a => a.DateEnd.CompareTo(DateTime.Today) < 0).ToList();
        //    List<MandateViewModel> listmv = new List<MandateViewModel>();
        //    foreach (var item in listH)
        //    {
        //        Project p = sp.GetById(item.ProjectId);
        //        Resource r = rs.GetById(item.userId);
        //        MandateViewModel mv = new MandateViewModel();
        //        mv.Duree = item.Duree;
        //        mv.DateBegin = item.DateBegin;
        //        mv.DateEnd = item.DateEnd;
        //        mv.Cost = item.Cost;
        //        mv.Name = p.Name;
        //        mv.FirstName = r.FirstName;
        //        mv.LastName = r.LastName;
        //        listmv.Add(mv);
        //    }

        //    return View(listmv);
        //}
        //public ActionResult HistoricalMandate()
        //{
        //    List<HistoricalMandate> listH = new List<HistoricalMandate>();
        //    listH = shm.GetAll().ToList();
        //    List<MandateViewModel> listmv = new List<MandateViewModel>();
        //    foreach (var item in listH)
        //    {
        //        Project p = sp.GetById(item.ProjectId);
        //        Resource r = rs.GetById(item.userId);
        //        MandateViewModel mv = new MandateViewModel();
        //       // mv.Duree = item.Duree;
        //        mv.DateBegin = item.DateBegin;
        //        mv.DateEnd = item.DateEnd;
        //        mv.Cost = item.Cost;
        //        mv.Name = p.Name;
        //        mv.FirstName = r.FirstName;
        //        mv.LastName = r.LastName;
        //        listmv.Add(mv);
        //    }

        //    return View(listmv);
        //}

        //public ActionResult PrintViewToPdf()
        //{
        //    var report = new ActionAsPdf("HistoricalMandate");
        //    return report;
        //}
        //[HttpGet]
        //public PartialViewResult AssignResource(int id)
        //{
        //    List<ResourceViewModel> listr = new List<ResourceViewModel>();

        //    Project p = sp.Get(a => a.ProjectId == id);

        //    listS = p.ProjectSkills.ToList();
        //    listR = rs.GetAll().ToList();
        //    listM = Sm.GetAll().ToList();

        //    foreach (var item in listS)
        //    {
        //        foreach (var item2 in listR)

        //        {
        //            foreach (var item3 in item2.ResourceSkills)
        //            {

        //                if ((item.SkillsId == item3.SkillsId) && (item2.Availability == 0))
        //                {
        //                    ResourceViewModel r = new ResourceViewModel();
        //                    r.FirstName = item2.FirstName;
        //                    r.LastName = item2.LastName;
        //                    // r.Availability = (TypeAvailability)Enum.GetValues; ;
        //                    r.BuissnesSector = item2.BuissnesSector;
        //                    listr.Add(r);

        //                }
        //            }
        //        }
        //    }

        //    return PartialView(listr);
        //}


    }
}
