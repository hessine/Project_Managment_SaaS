using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentityV2.Data;
using IdentityV2.Domain.Entities;
using IdentityV2.Presentation.Models;
using IdentityV2.Service;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityV2.Presentation.Controllers
{
    [Authorize]
    public class UserController : Controller

    {

        UserService US = new UserService();
        MyContext context = new MyContext();


        // GET: User
        public ActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayMenu = "No";

                if (isAdminUser())
                {
                    ViewBag.displayMenu = "Yes";
                }
                return View();
            }   
            else   
            {
                ViewBag.Name = "Not Logged IN";
            }
            return View();
        }

        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                MyContext context= new MyContext();
                var UserManager = new UserManager<User>(new UserStore<User>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }


        public ActionResult Role()
        {

            if (User.Identity.IsAuthenticated)
            {


                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var Roles = context.Roles.ToList();
            return View(Roles);

        }




        public ActionResult CreateRole()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRole(Microsoft.AspNet.Identity.EntityFramework.IdentityRole role)
        {

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            roleManager.Create(role);

            return RedirectToAction("Role");

        }




        [Authorize(Roles = "Admin")]
        public ActionResult List()
        {
            var Users = new List<User>();

            foreach (var user in US.GetMany())
            {
                Users.Add(user);
            }

            return View(Users);
        }



    }
}