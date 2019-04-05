using IdentityV2.Domain.Entities;
using IdentityV2.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentityV2.Presentation.Models;
namespace IdentityV2.Presentation.Controllers
{
    public class ProjectController : Controller
    {
        ServiceProject ps = new ServiceProject();
     


        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(ProjectViewModel pvm)
        {
            Project p = new Project();
            p.ProjectId = pvm.ProjectId;
        //    p.Address = new Adress { Address = "tunis", ZipCode = 2040, Longitude = 11, Latitude = 15, Country = "tunis" };
            p.Name = pvm.Name;

          

  
            p.Description= pvm.Description;
          //  p.ClientFK = pvm.ClientFK;

            ps.Add(p);
            ps.Commit();
            return RedirectToAction("Index");
        }

        // GET: Project/Edit/5
      

     

   
       
       

       

      
       
    }
}
