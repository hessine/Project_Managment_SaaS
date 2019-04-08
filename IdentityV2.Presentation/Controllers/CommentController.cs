using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentityV2.Data;
using IdentityV2.Domain.Entities;
using IdentityV2.Service;
using IdentityV2.Presentation.Models;
using Microsoft.AspNet.Identity;

namespace IdentityV2.Presentation.Controllers
{
    public class CommentController : Controller
    {
        ITaskPMService MyTaskService;

        ICommentService MycommentService;
        public CommentController()
        {
            MycommentService = new CommentService();
            MyTaskService = new TaskPMService();
        }
        // GET: Comment
        public ActionResult Index()
        {
            var comments = new List<CommentVM>();
            foreach (Comment e in MycommentService.GetMany())
            {
                comments.Add(new CommentVM()
                {
                    CommentId = e.CommentId,
                    Text = e.Text
                });
            }
            return View(comments);
        }

        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {

            return RedirectToAction("");
        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            ITaskPMService MyTaskService = new TaskPMService();

            var MyTasks = MyTaskService.GetMany();

            ViewBag.ListTasks = new SelectList(MyTasks, "TaskId", "Name");
            return View();

        }




        // POST: Comment/Create
        [HttpPost]
        public ActionResult Create(CommentVM comVM)
        {

            
            string currentUserId = User.Identity.GetUserId();
            //  ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            
            Comment t1 = new Comment()
            {
                Text = comVM.Text,
                
                TaskId = comVM.TaskId,
                //à dem
                //Usercomment = currentUserId

            };
            MycommentService.Add(t1);
            MycommentService.Commit();

            return RedirectToAction("Index");
            
        }
    
       
        // GET: Comment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comment/Edit/5
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

        // GET: Comment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Comment p = MycommentService.GetById(id);
            MycommentService.Delete(p);
            MycommentService.Commit();
            return RedirectToAction("Index");
        }





        public ActionResult GetComments(int idTask)
        {
            var Comments = new List<CommentVM>();
            foreach (Comment p in MycommentService.GetMany())
            {
                if (p.TaskId == idTask)
                {
                    Comments.Add(new CommentVM()
                    {
                        TaskId = p.TaskId,
                        CommentId = p.CommentId,
                       Text = p.Text
                    });
                }


            }

            return View(Comments);
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






        public ActionResult GetAllComments()
        {

            List<CommentVM> lists = new List<CommentVM>();
             foreach (var p in MycommentService.GetMany())
             {
                 // if (currentUserId == p.leader)
                 //{
                 CommentVM pvm = new CommentVM();

                 pvm.CommentId = p.CommentId;
                     pvm.Text = p.Text;
                     //pvm.DeadLine = p.DeadLine;
                     pvm.TaskId = p.TaskId;
                     pvm.taskname = MyTaskService.GetById(p.TaskId).Name;
                 pvm.taskStatus = MyTaskService.GetById(p.TaskId).Status;

                    // pvm.UserName = MyUserService.GetById(p.UserId).UserName;

                     lists.Add(pvm);
                 //}
             }
             return View(lists);





            /*

             List<CommentVM> lists = new List<CommentVM>();
          foreach (var p in MycommentService.GetCommentByTask(1))
          {
              if (1 == p.TaskId)
              {
              CommentVM pvm = new CommentVM();

              pvm.CommentId = p.CommentId;
                  pvm.Text = p.Text;
                  //pvm.DeadLine = p.DeadLine;
                  pvm.TaskId = p.TaskId;
                  pvm.taskname = MyTaskService.GetById(p.TaskId).Name;
              pvm.taskStatus = MyTaskService.GetById(p.TaskId).Status;

                 // pvm.UserName = MyUserService.GetById(p.UserId).UserName;

                  lists.Add(pvm);
              }
          }
          return View(lists);
          */



        }




    }
}
