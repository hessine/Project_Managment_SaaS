using DomainMap.Entities;
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
    public class RequestAdminController : Controller
    {
        IRequestService serviceReq = new ServiceRequest();
        IServiceRequiredSkills serviceRS = new ServiceRequiredSkills();
        IServiceClient serviceUser = new ServiceClient();

        // GET: RequestAdmin
        public ActionResult Index(string recherche)
        {
            List<RequestViewModel> listR = new List<RequestViewModel>();
            foreach (var item in serviceReq.GetAll())
            {
                RequestViewModel Rvm = new RequestViewModel();
                

                //ViewBag.nbrResource = new SelectList();
                Rvm.RequestId = item.RequestId;
                Rvm.subject = item.subject;
                Rvm.nbrResource = item.nbrResource;
                Rvm.DateBegin = item.DateBegin;
                Rvm.DateEnd = item.DateEnd;
                Rvm.DateDeposit = item.DateDeposit;
                Rvm.ReportedDate = item.ReportedDate;
                Client c = serviceUser.GetById(item.ClientId);
                Rvm.FirstName = c.FirstName;
                Rvm.LastName = c.LastName;
                Rvm.ClientId = item.ClientId;
                Rvm.coast = item.coast;
                Rvm.state = (WebMap.Models.RequestState)item.state;
                      listR.Add(Rvm);
                int diffdate = DateTime.Compare(DateTime.Now, item.ReportedDate);
                if (diffdate == 0)
                {
                    ViewBag.notif = "you have request reported for this date"+item.RequestId;
                   

                }



                            }
            if (!String.IsNullOrEmpty(recherche))
            {
                listR = listR.Where(m => m.subject.Contains(recherche)).ToList();
            }

            return View(listR);
        }

        // GetT: RequestAdmin/Accept
         public ActionResult Accept(int id)
        {
            var req = serviceReq.GetById(id);
            RequestViewModel RVM = new RequestViewModel();

            RVM.subject = req.subject;
            RVM.state.Equals(req.state);
            RVM.DateBegin = req.DateBegin;
            RVM.subject = req.subject;
            RVM.DateDeposit = req.DateDeposit;
            RVM.nbrResource = req.nbrResource;
            RVM.DateEnd = req.DateEnd;
            RVM.coast = req.coast;
            RVM.state.Equals(req.state);
            RVM.ClientId = req.ClientId;

            return View(RVM);
        }

        

        // POST: RequestAdmin/Accept
        [HttpPost]
        public ActionResult Accept(int id, RequestViewModel RVM)
        {
            
            Request req = serviceReq.GetById(id);
           // Client client=serviceUser.Get(x=>x.req)
           // Client Client = serviceUser.GetById(req.ClientId);

            if (req.state == DomainMap.Entities.RequestState.untreated)
            {
                req.state = DomainMap.Entities.RequestState.accepted;

                serviceReq.Update(req);
                serviceReq.Commit();
                try
                {

                    ////Mail
                    MailMessage mail = new MailMessage("leviofr@gmail.com","tounssi.nadda@gmail.com");
                mail.Subject = "Accepting project request" ;
                mail.Body = "BONJOUR : Your project request " + "' " + req.subject + " '" + "is accepted ";
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    //smtpClient.Credentials = new System.Net.NetworkCredential("nada.tounsi@esprit.tn", "pacolito4");
                    smtpClient.Credentials = new System.Net.NetworkCredential("leviofr@gmail.com", "Nada$123");
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(mail);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }


            }

            return RedirectToAction("Index");
        }




        // GetT: RequestAdmin/Refuse
        public ActionResult Refuse(int id)
        {
            var req = serviceReq.GetById(id);
            RequestViewModel RVM = new RequestViewModel();

            RVM.subject = req.subject;
            RVM.state.Equals(req.state);
            RVM.DateBegin = req.DateBegin;
            RVM.subject = req.subject;
            RVM.DateDeposit = req.DateDeposit;
            RVM.nbrResource = req.nbrResource;
            RVM.DateEnd = req.DateEnd;
            RVM.coast = req.coast;
            RVM.state.Equals(req.state);
            RVM.ClientId = req.ClientId;

            return View(RVM);
        }



        // POST: RequestAdmin/Refuse
        [HttpPost]
        public ActionResult Refuse(int id, RequestViewModel RVM)
        {
            Request req = serviceReq.GetById(id);
            if (req.state == DomainMap.Entities.RequestState.untreated)
            {
                req.state = DomainMap.Entities.RequestState.denied;

                serviceReq.Update(req);
                serviceReq.Commit();

                try
                {
                    ////Mail
                    MailMessage mail = new MailMessage("leviofr@gmail.com", "tounssi.nadda@gmail.com");
                    mail.Subject = "Refusing project request";
                    mail.Body = "BONJOUR : Your project request " + "' " + req.subject + " '" + "was denied";
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    //smtpClient.Credentials = new System.Net.NetworkCredential("nada.tounsi@esprit.tn", "pacolito4");
                    smtpClient.Credentials = new System.Net.NetworkCredential("leviofr@gmail.com", "Nada$123");
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(mail);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
            

            return RedirectToAction("Index");
        }

        // GetT: RequestAdmin/Report
        public ActionResult Report(int id)
        {
            var req = serviceReq.GetById(id);
            RequestViewModel RVM = new RequestViewModel();

            RVM.subject = req.subject;
            RVM.state.Equals(req.state);
            RVM.DateBegin = req.DateBegin;
            RVM.subject = req.subject;
            RVM.DateDeposit = req.DateDeposit;
            RVM.nbrResource = req.nbrResource;
            RVM.DateEnd = req.DateEnd;
            RVM.coast = req.coast;
            RVM.state.Equals(req.state);
            RVM.ClientId = req.ClientId;

            return View(RVM);
        }



        // POST: RequestAdmin/Report
        [HttpPost]
        public ActionResult Report(int id, RequestViewModel RVM)
        {
            Request req = serviceReq.GetById(id);
           
                req.state = DomainMap.Entities.RequestState.reported;
                req.ReportedDate = RVM.ReportedDate;
                int diffDte = DateTime.Compare(RVM.ReportedDate, DateTime.Now);
                if (diffDte>0) {

                serviceReq.Update(req);
                serviceReq.Commit();
                return RedirectToAction("Index");
            }
            else { ViewBag.msg = "reported date incorrect"; }

            return View();
        }



        // GET: RequestAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RequestAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RequestAdmin/Create
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

        // GET: RequestAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RequestAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RequestAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RequestAdmin/Delete/5
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
