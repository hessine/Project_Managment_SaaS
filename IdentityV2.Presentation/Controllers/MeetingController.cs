using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DHTMLX.Common;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using IdentityV2.Data;
using IdentityV2.Domain.Entities;

namespace IdentityV2.Presentation.Controllers
{
    [Authorize]
    public class MeetingController : Controller
    {
        private MyContext context = new MyContext();
        // GET: Meeting
        public ActionResult Index()
        {
            var scheduler = new DHXScheduler(this);
            scheduler.Skin = DHXScheduler.Skins.Flat;

            scheduler.Config.first_hour = 9;
            scheduler.Config.last_hour = 17;

            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;

            return View(scheduler);
        }

        public ContentResult Data()
        {
            var apps = context.Meetings.ToList();
            return new SchedulerAjaxData(apps);
        }

        public ActionResult Save(int? id, FormCollection actionValues)
        {
            var action = new DataAction(actionValues);

            try
            {
                var changedEvent = DHXEventsHelper.Bind<Meeting>(actionValues);
                switch (action.Type)
                {
                    case DataActionTypes.Insert:
                        context.Meetings.Add(changedEvent);
                        break;
                    case DataActionTypes.Delete:
                        context.Entry(changedEvent).State = EntityState.Deleted;
                        break;
                    default:// "update"  
                        context.Entry(changedEvent).State = EntityState.Modified;
                        break;
                }
                context.SaveChanges();
                action.TargetId = changedEvent.Id;
            }
            catch (Exception a)
            {
                action.Type = DataActionTypes.Error;
            }

            return (new AjaxSaveResponse(action));
        }
    }
}