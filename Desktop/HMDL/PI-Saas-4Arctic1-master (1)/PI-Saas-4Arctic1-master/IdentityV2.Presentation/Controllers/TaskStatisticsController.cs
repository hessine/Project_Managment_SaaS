using IdentityV2.Presentation.Models;
using IdentityV2.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityV2.Presentation.Controllers
{
    public class TaskStatisticsController : Controller
    {
        ITaskPMService MyTask;
        IServiceProject MyProjectService;
        IUserService MyUserService;



        public TaskStatisticsController()
        {
            MyTask = new TaskPMService();
            MyProjectService = new ServiceProject();
            MyUserService = new UserService();
        }

        // GET: TaskStatistics
        public ActionResult Index()
        {
           // string currentUserId = User.Identity.GetUserId();
            TaskStatisticsVM pvm = new TaskStatisticsVM();

           // foreach (var p in MyTask.GetMany())
            //{
               // if (currentUserId == p.leader)
               // {

                    var MytotalTask = MyTask.GetTotalTasks();

                    pvm.nnbTotalTasks = MytotalTask;

                    //nbr de task to do
                    var MynbrTaskToDo = MyTask.NbTaskByStatusToDo();
                    pvm.nbrTaskToDo = MynbrTaskToDo;
                    //Doing

                    var MynbrTaskDoing = MyTask.NbTaskByStatusDoing();
                    pvm.nbrTaskDoing = MynbrTaskDoing;
                    //Done
                    var MynbrTaskDone = MyTask.NbTaskByStatusDone();
                    pvm.nbrTaskDone = MynbrTaskDone;
            //Task Finish Early
                     var MynbrTaskFinishEarly = MyTask.FinishTaskEarly();
                      pvm.nbrTaskFinishEarly = MynbrTaskFinishEarly;



            // }
            //}
            return View(pvm);
        }





        public ActionResult IndexforManager()
        {
            // string currentUserId = User.Identity.GetUserId();
            TaskStatisticsVM pvm = new TaskStatisticsVM();

            // foreach (var p in MyTask.GetMany())
            //{
            // if (currentUserId == p.leader)
            // {

            var MytotalTask = MyTask.GetTotalTasks();

            pvm.nnbTotalTasks = MytotalTask;

            //nbr de task to do
            var MynbrTaskToDo = MyTask.NbTaskByStatusToDo();
            pvm.nbrTaskToDo = MynbrTaskToDo;
            //Doing

            var MynbrTaskDoing = MyTask.NbTaskByStatusDoing();
            pvm.nbrTaskDoing = MynbrTaskDoing;
            //Done
            var MynbrTaskDone = MyTask.NbTaskByStatusDone();
            pvm.nbrTaskDone = MynbrTaskDone;
            //Task Finish Early
            var MynbrTaskFinishEarly = MyTask.FinishTaskEarly();
            pvm.nbrTaskFinishEarly = MynbrTaskFinishEarly;



            // }
            //}
            return View(pvm);
        }








        // GET: TaskStatistics/Details/5
        public ActionResult MoreInfo()
        {
             string currentUserId = User.Identity.GetUserId();

            List<TaskPMVM> lists = new List<TaskPMVM>();

            TaskPMVM pvm = new TaskPMVM();

            foreach (var p in MyTask.ReturnFinishTaskEarly())
            {
                 if (currentUserId == p.leader)
                {
                pvm.TaskId = p.TaskId;
                pvm.Name = p.Name;
                pvm.StartDate = p.StartDate;
                pvm.EndDate = p.EndDate;
               // pvm.Status = p.Status;
                pvm.DeadLine = p.DeadLine;
                //  
                pvm.ProjectId = p.ProjectId;

                pvm.ProjectName = MyProjectService.GetById(p.ProjectId).Name;

                pvm.User_Id = p.UserId;
                pvm.UserName = MyUserService.GetById(p.UserId).UserName;

                lists.Add(pvm);

                }         
            }
            return View(lists);


        }





        // GET: TaskStatistics/Details/5
        public ActionResult MoreInfoforManager()
        {

            List<TaskPMVM> lists = new List<TaskPMVM>();

            TaskPMVM pvm = new TaskPMVM();

            foreach (var p in MyTask.ReturnFinishTaskEarly())
            {
              
                    pvm.TaskId = p.TaskId;
                    pvm.Name = p.Name;
                    pvm.StartDate = p.StartDate;
                    pvm.EndDate = p.EndDate;
                    // pvm.Status = p.Status;
                    pvm.DeadLine = p.DeadLine;
                    //  
                    pvm.ProjectId = p.ProjectId;

                    pvm.ProjectName = MyProjectService.GetById(p.ProjectId).Name;

                    pvm.User_Id = p.UserId;
                    pvm.UserName = MyUserService.GetById(p.UserId).UserName;

                    lists.Add(pvm);

                
            }
            return View(lists);


        }









        // GET: TaskStatistics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskStatistics/Create
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

        // GET: TaskStatistics/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TaskStatistics/Edit/5
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

        // GET: TaskStatistics/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TaskStatistics/Delete/5
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
