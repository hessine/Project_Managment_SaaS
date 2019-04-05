using DomainMap.Entities;
using Microsoft.AspNet.Identity;
using ServiceMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebMap.Models;

namespace WebMap.Controllers
{
    public class RequestController : Controller
    {
        IRequestService serviceReq = new ServiceRequest();
        IServiceRequiredSkills serviceRS = new ServiceRequiredSkills();
        IServiceClient serviceclient = new ServiceClient();

        // GET: Request
        public ActionResult Index()
        {
            int currentClient = User.Identity.GetUserId<int>();
            List<RequestViewModel> listR = new List<RequestViewModel>();
            foreach (var item in serviceReq.GetMany(t => t.ClientId == currentClient))
            {
                RequestViewModel Rvm = new RequestViewModel();

                Rvm.RequestId = item.RequestId;
                Rvm.subject = item.subject;
                Rvm.nbrResource = item.nbrResource;
                Rvm.DateBegin = item.DateBegin;
                Rvm.DateEnd = item.DateEnd;
                Rvm.DateDeposit = item.DateDeposit;
                Rvm.ClientId = item.ClientId;
                Rvm.coast = item.coast;
                Rvm.state = (WebMap.Models.RequestState)item.state;

                listR.Add(Rvm);

            }

            return View(listR);

        }


        //GET: Request/Details/5
        public ActionResult Details(int id)
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

        // GET: Request/Create

        public ActionResult Create()
        {



            return View();
        }

        // POST: Document/Create
        [HttpPost]
        public ActionResult Create(RequestViewModel RVM)
        {
            
            Request Request = new Request();// { state = (DomainMap.Entities.RequestState)RVM.state };
            RequiredSkills RSkills = new RequiredSkills();
            Request.subject = RVM.subject;
            Request.DateBegin = RVM.DateBegin;
            Request.DateEnd = RVM.DateEnd;
            //comparaison date
            int diffDate = DateTime.Compare(RVM.DateBegin, RVM.DateEnd);
            Request.DateDeposit = DateTime.Now;
            Request.coast = RVM.coast;
            Request.state = DomainMap.Entities.RequestState.untreated;
            // Request.state= (DomainMap.Entities.RequestState)RVM.state;
            Request.nbrResource = RVM.nbrResource;

            int currentClient = User.Identity.GetUserId<int>();
            Request.ClientId = currentClient;
            int diffAvecSysDate = DateTime.Compare(RVM.DateBegin, DateTime.Now);
            if (diffDate < 0 && diffAvecSysDate>0)
            {
                serviceReq.Add(Request);
                serviceReq.Commit();
                return RedirectToAction("AddRequiredSkills", new { sujet = Request.subject, id = Request.RequestId, nbRessource = Request.nbrResource });

            }
            else
            { //TempData["controleDate"] = "<script>alert('datebegin can't be more greater the dateend');</script>";

                ViewBag.msg = "date begin cant be greater then date end or less then sysdate";
              //  return RedirectToAction("Create");
            }

            return View();
           // return RedirectToAction("AddRequiredSkills", new { sujet = Request.subject, id = Request.RequestId, nbRessource = Request.nbrResource });


        }

        public PartialViewResult getPopup()
        {
            return PartialView();
        }


        // GET: Request/Edit/
        public ActionResult Edit(int id)
        {
            IEnumerable<RequiredSkills> lrs = serviceRS.GetAll().Where(x => x.requestId == id);
            ViewBag.data = lrs;

            var req = serviceReq.GetById(id);

            RequestViewModel RVM = new RequestViewModel();
            RVM.subject = req.subject;
            //RVM.state.Equals(req.state);
            RVM.DateBegin = req.DateBegin;
            RVM.subject = req.subject;
            // RVM.ClientId = req.ClientId;
            //RVM.DateDeposit = req.DateDeposit;
            RVM.nbrResource = req.nbrResource;
            RVM.DateEnd = req.DateEnd;
            RVM.coast = req.coast;
            if (req.state == DomainMap.Entities.RequestState.untreated)
            {
                return View(RVM);
            }
            else { return RedirectToAction("Index"); }
        }


        // POST: Request/Edit
        [HttpPost]
        public ActionResult Edit(int id, RequestViewModel RVM)
        {


            Request req = serviceReq.GetById(id);
            req.subject = RVM.subject;
            //req.state.Equals(RVM.state);
            req.DateBegin = RVM.DateBegin;
            req.DateEnd = RVM.DateEnd;
            req.subject = RVM.subject;
            req.DateDeposit = DateTime.Now;
            req.nbrResource = RVM.nbrResource;
            req.coast = RVM.coast;
            int diffDate = DateTime.Compare(RVM.DateBegin, RVM.DateEnd);
            if (diffDate < 0)
            {
                serviceReq.Update(req);
                serviceReq.Commit();
                return RedirectToAction("Index");
            }
            else { ViewBag.msg = "date begin cant be greater then date end or less then sysdate"; }
            return View();
           

        }




        // GET: Request/Delete/5
        public ActionResult Delete(int id)
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

            return View(RVM);

        }

        // POST: Request/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, RequestViewModel RVM)
        {
            //ViewBag.msgDelete = "you can't delete this request";

            int currentClient = User.Identity.GetUserId<int>();
            Request R = serviceReq.GetById(id);

            RVM.DateBegin = R.DateBegin;
            RVM.state.Equals(R.state);
            RVM.subject = R.subject;
            RVM.DateDeposit = R.DateDeposit;
            RVM.DateBegin = R.DateBegin;
            RVM.nbrResource = R.nbrResource;
            RVM.DateEnd = R.DateEnd;
            RVM.coast = R.coast;

            serviceReq.Delete(R);
            serviceReq.Commit();

            //TempData["msg"] = "<script>alert('this request is treated you can't delete it');</script>";
            
            return RedirectToAction("Index");

        }
        // GET: Request/AddRequiredSkills
        public ActionResult AddRequiredSkills()
        {
            return View();
        }


        // POST: Request/AddRequiredSkills
        [HttpPost]
        public ActionResult AddRequiredSkills(RequiredSkillsViewModel RVM, int id, int nbRessource, String sujet)
        {
            int IdcurrentClient = User.Identity.GetUserId<int>();
            Client client = serviceclient.GetById(IdcurrentClient);
            int nb = serviceRS.GetMany(x => x.requestId == id).Count();
            if (nb < nbRessource)
            {
                RequiredSkills RSkills = new RequiredSkills();
                RSkills.education = RVM.education;
                RSkills.experience = RVM.experience;
                RSkills.profil = RVM.profil;
                RSkills.nomSkill = RVM.education + " " + RVM.experience + "ans";
                RSkills.requestId = id;
                serviceRS.Add(RSkills);
                serviceRS.Commit();
                

                ////Mail
                try
                {
                    //MailMessage mail = new MailMessage("nada.tounsi@esprit.tn","leviofr@gmail.com") ;
                    MailMessage mail = new MailMessage("tounssi.nadda@gmail.com", "leviofr@gmail.com");
                    mail.Subject = sujet;
                    mail.Body = "BONJOUR : Je vous propose mon projet intitulé  " + "'" + sujet + "'" + "qui sera composé de " + nbRessource + " ressource(s) de votre entreprise dont les skills sont " + RSkills.nomSkill;

                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    //smtpClient.Credentials = new System.Net.NetworkCredential("nada.tounsi@esprit.tn", "pacolito4");
                    smtpClient.Credentials = new System.Net.NetworkCredential("tounssi.nadda@gmail.com", "Tounsi$123");
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(mail);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
                
            }
            else
            {
                ViewBag.msgNB = "number of skill must be the same number of resources specified previously ";
                return RedirectToAction("Index");
            }


            return View();
        }



        public ActionResult ClientTemplate()
        {
            return View();

        }

        
    }
}

    



    

