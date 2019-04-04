using IdentityV2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentityV2.Domain.Entities;
using IdentityV2.Presentation.Models;

namespace  IdentityV2.Presentation.Controllers

{
    public class TaskPMController : Controller
    {


        ITaskPMService MyTaskService;
        TaskPMService ps = new TaskPMService();


        IServiceProject MyProjectService;


        public TaskPMController()
        {
            MyTaskService = new TaskPMService();
            MyProjectService = new ServiceProject();
        }





        // GET: TaskPM
        public ActionResult Index(string searchString)
        {
            List<TaskPMVM> lists = new List<TaskPMVM>();
            foreach (var p in MyTaskService.SearchTasks(searchString))
            {
                TaskPMVM pvm = new TaskPMVM();
                pvm.TaskId = p.TaskId;
                pvm.Name = p.Name;
                pvm.StartDate = p.StartDate;
                pvm.EndDate = p.EndDate;
                pvm.Status = p.Status;
                pvm.DeadLine = p.DeadLine;
                pvm.ProjectId = p.ProjectId;
               pvm.ProjectName = MyProjectService.GetById(p.ProjectId).Name;

                lists.Add(pvm);

            }
            return View(lists);
        }




        // GET: TaskPM/Details/5
        public ActionResult Details(int id)
        {
            //var s = sps.listskills(id);
            var p = MyTaskService.GetById(id);
            TaskPMVM pvm = new TaskPMVM();

            pvm.TaskId = p.TaskId;
            pvm.Name = p.Name;
            pvm.StartDate = p.StartDate;
            pvm.DeadLine = p.DeadLine;
            pvm.Status = p.Status;
            pvm.ProjectName = MyProjectService.GetById(p.ProjectId).Name;


            //pvm.ProjectSkills = p.ProjectSkills;
            //  pvm.ListResource = p.ListResource;


            return View(pvm);

        }

        // GET: TaskPM/Create
        public ActionResult Create()
        {
            var MyProjects = MyProjectService.GetMany();
            ViewBag.ListProjects = new SelectList(MyProjects, "ProjectId", "Name");
            //viewbag :variable pour tronsporter les données du controller lil vue 
            return View();
        }

        // POST: TaskPM/Create
        [HttpPost]
        public ActionResult Create(TaskPMVM taskVM)
        {

            TaskPM t1 = new TaskPM()
            { 
            Name = taskVM.Name,
                
                DeadLine = taskVM.DeadLine,
                EndDate = taskVM.EndDate,
                StartDate = taskVM.StartDate,
                Status = " to-do",
                 ProjectId = taskVM.ProjectId



            };
        MyTaskService.Add(t1);
            MyTaskService.Commit();

            return RedirectToAction("Index");

    }

        // GET: TaskPM/Edit/5
        public ActionResult Edit(int id)
        {
            var p = MyTaskService.GetById(id);
            TaskPMVM pvm = new TaskPMVM();
            p.Name = pvm.Name;
            p.StartDate = pvm.StartDate;
          //  p.EndDate = pvm.EndDate;

            p.DeadLine = pvm.DeadLine;

            return View(pvm);

        }

        // POST: TaskPM/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TaskPMVM pvm)
        {
            TaskPM p = MyTaskService.GetById(id);
            p.Name = pvm.Name;
            p.StartDate = pvm.StartDate;
         //   p.EndDate = pvm.EndDate;
           
            p.DeadLine = pvm.DeadLine;

           

            MyTaskService.Update(p);
            MyTaskService.Commit();

            return RedirectToAction("Index");

        }

        // GET: TaskPM/Delete/5
        public ActionResult Delete(int id)
        {
            var p = MyTaskService.GetById(id);
            TaskPMVM pvm = new TaskPMVM();
            pvm.TaskId = p.TaskId;
            pvm.Name = p.Name;
            pvm.StartDate = p.StartDate;
            pvm.EndDate = p.EndDate;
            pvm.DeadLine = p.DeadLine;
            pvm.Status = p.Status;
            
           
            return View(pvm);

        }

        // POST: TaskPM/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TaskPMVM pvm)
        {

            TaskPM p = MyTaskService.GetById(id);
            p.Name = pvm.Name;
            p.StartDate = pvm.StartDate;
            p.EndDate = pvm.EndDate;
            p.DeadLine = pvm.DeadLine;
           
            MyTaskService.Delete(p);
            MyTaskService.Commit();

            return RedirectToAction("Index");


        }
    }
}
