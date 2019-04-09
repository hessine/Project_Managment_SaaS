using IdentityV2.Presentation.Models;
using IdentityV2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityV2.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TaskPMVM pvm = new TaskPMVM();
            ITaskPMService ti = new TaskPMService();
          pvm.nbttotaltask=  ti.NbTaskByStatusToDo();
            return View(pvm);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}