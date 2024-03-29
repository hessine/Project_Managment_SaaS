﻿using IdentityV2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentityV2.Domain.Entities;
using IdentityV2.Presentation.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Web.Security;

namespace  IdentityV2.Presentation.Controllers

{
    [Authorize]
    public class TaskPMController : Controller
    {
        /*ouss
                private ApplicationUserManager _userManager;
                public ApplicationUserManager UserManager
                {
                    get
                    {
                        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    }
                    private set
                    {
                        _userManager = value;
                    }
                }*/


        private ApplicationDbContext db = new ApplicationDbContext();


        ITaskPMService MyTaskService;
        TaskPMService ps = new TaskPMService();

        IUserService MyUserService;
        IServiceProject MyProjectService;

      /*  public TaskPMController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }*/


        public TaskPMController()
        {
            MyTaskService = new TaskPMService();
            MyProjectService = new ServiceProject();
            MyUserService = new UserService();
        }





        // GET: TaskPM
        public ActionResult Index(string searchString)
        {
            //  public Task<ActionResult> Index(string searchString)

            // var user = UserManager.FindByIdAsync(System.Web.HttpContext.Current.User.Identity.GetUserId());
            // user.Id

            string currentUserId = User.Identity.GetUserId();



            List<TaskPMVM> lists = new List<TaskPMVM>();
            foreach (var p in MyTaskService.SearchTasks(searchString))
            {
                if (currentUserId == p.leader) { 
                TaskPMVM pvm = new TaskPMVM();
                pvm.TaskId = p.TaskId;
                pvm.Name = p.Name;
                pvm.StartDate = p.StartDate;
                pvm.EndDate = p.EndDate;
                pvm.Status = p.Status;
                pvm.DeadLine = p.DeadLine;
                pvm.ProjectId = p.ProjectId;

               pvm.ProjectName = MyProjectService.GetById(p.ProjectId).Name;

                pvm.User_Id = p.UserId;
                pvm.UserName = MyUserService.GetById(p.UserId).UserName;
               
                lists.Add(pvm);
                }
            }
            return View(lists);
        }




        // GET: TaskPM/Details/5
        public ActionResult Details(int id)
        {
        // string userID = Membership.GetUser().ProviderUserKey.ToString();
       
    //var s = sps.listskills(id);
    var p = MyTaskService.GetById(id);
            TaskPMVM pvm = new TaskPMVM();

            pvm.TaskId = p.TaskId;
            pvm.Name = p.Name;
            pvm.StartDate = p.StartDate;
            pvm.DeadLine = p.DeadLine;
            pvm.Status = p.Status;
            pvm.ProjectName = MyProjectService.GetById(p.ProjectId).Name;
            pvm.ProjectDesc = MyProjectService.GetById(p.ProjectId).Description;


            //pvm.ProjectSkills = p.ProjectSkills;
            //  pvm.ListResource = p.ListResource;


            return View(pvm);

        }

        // GET: TaskPM/Create
        public ActionResult Create()
        {
            var MyProjects = MyProjectService.GetMany();

          var  MyUsers = MyUserService.GetMany();

            ViewBag.ListUsers = new SelectList(MyUsers, "Id", "UserName");


            ViewBag.ListProjects = new SelectList(MyProjects, "ProjectId", "Name");
            //viewbag :variable pour tronsporter les données du controller lil vue 
            return View();
        }

        // POST: TaskPM/Create
        [HttpPost]
        [Authorize(Roles = "TeamLeader")]
        public ActionResult Create(TaskPMVM taskVM)
        {

            string currentUserId = User.Identity.GetUserId();
          //  ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);




           
            TaskPM t1 = new TaskPM()
            { 
            Name = taskVM.Name,
                
                DeadLine = taskVM.DeadLine,
                EndDate = taskVM.EndDate,
                StartDate = taskVM.StartDate,
                Status = " todo",
                 ProjectId = taskVM.ProjectId,
                 UserId = taskVM.User_Id,
                leader = currentUserId




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
