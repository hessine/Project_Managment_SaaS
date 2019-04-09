using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentityV2.Service;
using IdentityV2.Domain.Entities;
using IdentityV2.Presentation.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Web.Security;

namespace IdentityV2.Presentation.Controllers
{
    public class EventController : Controller
    {
        ServiceEvent se = new ServiceEvent();
        public ActionResult Index()
        {
            return PartialView("Index");
        }
        //public JsonResult GetEvents()
        //{
        //    var events = se.GetAll();
        //    return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };



        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(EventViewModel evm)
        {
            Events e = new Events();
            e.Subject = evm.Subject;
            e.Description = evm.Description;
            e.Start = evm.Start;
            e.End = evm.End;
            e.Themecolor = evm.Themecolor;
            e.IsFullDay = evm.IsFullDay;





            se.Add(e);
            se.Commit();
            return PartialView("Index");
        }





        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Event/Edit/5
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

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Event/Delete/5
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
        public JsonResult GetEvents()
        {
            var events = se.GetAll();
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        [HttpPost]
        public JsonResult SaveEvent(Events e)
        {
            var status = false;
            {

                if (e.EventId > 0)
                {
                    //Update the event
                    var v = se.GetAll().Where(a => a.EventId == e.EventId).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.Themecolor = e.Themecolor;
                        v.IsFullDay = e.IsFullDay;

                    }
                }
                else
                {
                    se.Add(e);
                }
                se.Commit();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;

            {
                var v = se.GetAll().Where(a => a.EventId == eventID).FirstOrDefault();
                if (v != null)
                {
                    se.Delete(v);
                    se.Commit();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}
