using Solution.Domain.Entities;
using Solution.Presentation.Models;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{
    public class TaskController : Controller
    {

        ITaskService MyTaskService;
        public TaskController()
        {
            MyTaskService = new TaskService();

        }

        // GET: Task
        public ActionResult Index(string searchString)
        {
            var Tasks = new List<TaskVM>();


            foreach (Task f in MyTaskService.Searchfilm(searchString))
            {
                Tasks.Add(new TaskVM()
                {
                    Name = f.Name,
                    StartDate=f.StartDate,
                    EndDate=f.EndDate,
                    DeadLine=f.DeadLine,
                    Status=f.Status

                });
            }
            return View(Tasks);

        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(TaskVM taskVM)
        {


            Task t1 = new Task()
            {
                Name = taskVM.Name,
                
                DeadLine=taskVM.DeadLine,
                EndDate=taskVM.EndDate,
                StartDate=taskVM.StartDate,
                Status=taskVM.Status
               
            };
            MyTaskService.Add(t1);
            MyTaskService.Commit();

            return RedirectToAction("Index");
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Task/Edit/5
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

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Task/Delete/5
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
