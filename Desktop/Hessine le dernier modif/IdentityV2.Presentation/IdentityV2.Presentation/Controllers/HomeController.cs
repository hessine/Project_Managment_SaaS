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
        ITaskPMService MyTask;
        IServiceProject MyPro;
        IUserService MyUser;
        public HomeController()
        {
            MyTask = new TaskPMService();
            MyPro = new ServiceProject();
            MyUser = new UserService();
        }
        public ActionResult Index()
        {

            TaskPMVM pvm = new TaskPMVM();
    
            var MytotalTask = MyTask.GetTotalTasks();
            
           pvm.nnbTotalTasks = MytotalTask;
            //Pour le nbr totale de project
            var MytotalProject = MyPro.GetTotalProjects();

            pvm.nbrTotalPr = MytotalProject;
            //Pour le nbr total de users
            var MytotalUsers = MyUser.GetTotalUsers();

            pvm.nbrTotalUser = MytotalUsers;
            //nbr de task to do
            var MynbrTaskToDo = MyTask.NbTaskByStatusToDo();
            pvm.nbrTaskToDo = MynbrTaskToDo;


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