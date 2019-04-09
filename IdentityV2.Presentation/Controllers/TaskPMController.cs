using IdentityV2.Service;
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


        public ApplicationDbContext db = new ApplicationDbContext();


        ITaskPMService MyTaskService;
        TaskPMService ps = new TaskPMService();
        ICommentService MycommentService;
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
            MycommentService = new CommentService();
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
          //  pvm.commentName = MycommentService.GetById(p.ListCommentaire<Comment>).Text;


            //pvm.ProjectSkills = p.ProjectSkills;
            //  pvm.ListResource = p.ListResource;


            return View(pvm);

        }









       /* public ActionResult com(int id)
        {
            ICommentService MycommentService= new CommentService();

            // string userID = Membership.GetUser().ProviderUserKey.ToString();

            //var s = sps.listskills(id);
            var p = MyTaskService.GetById(id);


            foreach (var s in MycommentService.GetCommentByTask())

                TaskPMVM pvm = new TaskPMVM();

            pvm.TaskId = p.TaskId;
            pvm.Name = p.Name;
            pvm.StartDate = p.StartDate;
            pvm.DeadLine = p.DeadLine;
            pvm.Status = p.Status;
            pvm.ProjectName = MyProjectService.GetById(p.ProjectId).Name;
            pvm.ProjectDesc = MyProjectService.GetById(p.ProjectId).Description;
            //  pvm.commentName = MycommentService.GetById(p.ListCommentaire<Comment>).Text;


            //pvm.ProjectSkills = p.ProjectSkills;
            //  pvm.ListResource = p.ListResource;


            return View(pvm);

        }*/






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
                Status = "todo",
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


        //**************************************hessine*************************************************//

        public ActionResult Assign(int id)
        {

            TaskPM p = MyTaskService.GetById(id);
            p.Status = "doing";
            MyTaskService.Update(p);
            MyTaskService.Commit();

            return RedirectToAction("Doing");
        }

        public ActionResult Assign2(int id)
        {

            TaskPM p = MyTaskService.GetById(id);
            p.Status = "done";
            p.EndDate = DateTime.Today;
            MyTaskService.Update(p);
            MyTaskService.Commit();

            return RedirectToAction("Done");
        }



        public ActionResult Index2()
        {
            return PartialView("Calender");
        }

        public ActionResult ToDo()
        {

            string currentUserId = User.Identity.GetUserId();
            List<TaskPMVM> lists = new List<TaskPMVM>();
           //foreach (var p in MyTaskService.GetTaskPMavailable())
          foreach (var p in MyTaskService.GetTaskPMToDo())
                if (currentUserId == p.UserId)
                {
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
                }
            //return View(lists);
            return PartialView("ToDo", lists);
        }

        public ActionResult Doing()
        {
            string currentUserId = User.Identity.GetUserId();
            List<TaskPMVM> lists = new List<TaskPMVM>();
           // foreach (var p in MyTaskService.GetTaskPMDoing())
           //  foreach (var p in MyTaskService.SearchTasks(ch))
           foreach (var p in MyTaskService.GetTaskPMDoing())
            {
                if (currentUserId == p.UserId)
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
                    IEnumerable<TaskPM> myTodoes = MyTaskService.GetTaskPMDoing().Where(x => x.UserId == currentUserId);
                 
                    lists.Add(pvm);

                    //TaskPMVM pvm = new TaskPMVM();
                    ITaskPMService ti = new TaskPMService();
                  //  pvm.nbttotaltask = ti.NbTaskByStatusToDo();
              
                    ViewBag.Percent = Math.Round(100f * ((float)5 / (float)50));
                }
            }
           // return View(lists);
             return PartialView("Doing", lists);
        }



        public ActionResult Done()
        {
            string currentUserId = User.Identity.GetUserId();
            List<TaskPMVM> lists = new List<TaskPMVM>();
          //  foreach (var p in MyTaskService.GetTaskPMDone())
             foreach (var p in MyTaskService.GetTaskPMDone())
            {
                if (currentUserId == p.UserId)
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
            }
          //  return View(lists);
             return PartialView("Done", lists);
        }

        public ActionResult DetailsTD(int id)
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
            pvm.ProjectDesc = MyProjectService.GetById(p.ProjectId).Description;

            //pvm.ProjectSkills = p.ProjectSkills;
            //  pvm.ListResource = p.ListResource;


            return View(pvm);
        }



        public PartialViewResult GetComments(int TaskId)
        {
            var Comments = new List<CommentVM>();
            foreach (Comment p in MycommentService.GetMany())
            {
                if (p.TaskId == TaskId)
                {
                    Comments.Add(new CommentVM()
                    {

                        CommentId = p.CommentId,
                        Text = p.Text
                    });
                }


            }

            return PartialView("Comments", Comments);
        }


        [HttpPost]
        public ActionResult PostComment(string Text, int TaskId)
        {


            Comment comment = new Comment()
            {
                Text = Text,
                TaskId = TaskId

            };

            MycommentService.Add(comment);
            MycommentService.Commit();



            return RedirectToAction("Detail");

        }






        /*   public ActionResult GetAllComments()
           {
               var Comments = new List<CommentVM>();
               foreach (Comment p in MycommentService.GetMany())
               {
                //   if (p.TaskId == idTask)
                 // {
                       Comments.Add(new CommentVM()
                       {
                           //TaskId = p.TaskId,
                          // CommentId = p.CommentId,
                           Text = p.Text
                       });
                 //  }


               }

               return View(Comments);
           }*/




        //à supp

        public ActionResult ALLCommentByID(int id)
        {
            //  public Task<ActionResult> Index(string searchString)

            // var user = UserManager.FindByIdAsync(System.Web.HttpContext.Current.User.Identity.GetUserId());
            // user.Id

            //   string currentUserId = User.Identity.GetUserId();
            ICommentService MycomService = new CommentService();
         
            List<CommentVM> lists = new List<CommentVM>();
            foreach (var p in MycomService.getCommentPerTask(id))
            {
                //if (currentUserId == p.leader)
                //{
                CommentVM pvm = new CommentVM();
                pvm.TaskId = p.CommentId;
                pvm.Text= p.Text;
                
                //  pvm.ProjectId = p.ProjectId;

                // pvm.ProjectName = MyProjectService.GetById(p.ProjectId).Name;

                //                    pvm.User_Id = p.UserId;
                //pvm.UserName = MyUserService.GetById(p.UserId).UserName;

                lists.Add(pvm);
                //}
            }
            return View(lists);
        }

















    }
    }
















