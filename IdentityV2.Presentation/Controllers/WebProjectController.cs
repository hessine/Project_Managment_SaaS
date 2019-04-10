using IdentityV2.Domain.Entities;
using IdentityV2.Presentation.Models;
using IdentityV2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IdentityV2.Presentation.Controllers
{
    public class WebProjectController : ApiController
    {
        // GET: api/WebAPI
   
    

            IServiceProject MyService = null;


            private ServiceProject ms = new ServiceProject();
            List<ProjectViewModel> Pro = new List<ProjectViewModel>();
            public WebProjectController()
            {
                MyService = new ServiceProject();
                Index();
                Pro = Index().ToList();
            }

           
            public List<ProjectViewModel> Index()
            {
                List<Project> Projects = ms.getProjects();
                List<ProjectViewModel> projectsXml = new List<ProjectViewModel>();
                foreach (Project i in Projects)
                {
                    projectsXml.Add(new ProjectViewModel
                    {
                        ProjectId = i.ProjectId,
                        Name = i.Name,
                        CatIdFK = i.CatIdFK,
                        Description = i.Description,
                        DateBegin = i.DateBegin,
                        DateEnd = i.DateEnd,
                        TotalNbrRessources = i.TotalNbrRessources,


                    });
                }
                return projectsXml;
            }

            // GET: api/RecWebApi
            public IEnumerable<ProjectViewModel> Get()
            {
                return Pro;
            }

            // GET: api/RecWebApi/5
            public string Get(int id)
            {
                return "value";
            }

            // POST: api/RecWebApi
            public void Post([FromBody]string value)
            {
            }

            // PUT: api/RecWebApi/5
            public void Put(int id, [FromBody]string value)
            {
            }

            // DELETE: api/RecWebApi/5
            public IHttpActionResult Delete(int id)

            {
                Project comp = MyService.GetById(id);

                MyService.Delete(comp);
                MyService.Commit();

                return Ok(comp);


           
        } }
    }
