using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DomainMap.Entities;
using WebMap.Models;
using ServiceMap.StatisticsReporting;


namespace WebMap.Controllers
{
    public class StastictsController : ApiController
    {
        //Api permet de retourner nombre de clients
        [HttpGet]
        [Route("api/nbreClients")]
        public IHttpActionResult GetNombreOfClients()
        {
            ServiceClient ServiceC = new ServiceClient();


            return Ok(ServiceC.NombresOfClients());
           
        }

        //Api permet de retourner nombre des projets
        [HttpGet]
        [Route("api/nbreProjects")]
        public IHttpActionResult GetNombreOfProjects()
        {
            ServiceProject ServiceP = new ServiceProject();

            return Ok(ServiceP.NombreOfProjects());

        }

        //Api permet de retourner nombre de resources
        [HttpGet]
        [Route("api/nbreResources")]
        public IHttpActionResult GetNombreOfResources()
        {
            ServiceResource ServiceR = new ServiceResource();

            return Ok(ServiceR.NombreOfResources());

        }


        ////Api permet de retourner nombre de resources par seniority
        //[HttpGet]
        //[Route("api/nbreResourcesBySen")]
        //public IHttpActionResult GetNombreOfResourcesBySen(Seniority sn)
        //{
        //    ServiceResource ServiceR = new ServiceResource();

        //    return Ok(ServiceR.ResourceBySeniority(sn));

        //}

        //Api permet de retourner nombre de resources Freelancer
        [HttpGet]
        [Route("api/nbreResourcesFreelancer")]
        public IHttpActionResult GetNombreOfResourcesFreelancer()
        {
            ServiceResource ServiceR = new ServiceResource();

            return Ok(ServiceR.ResourceFreelancer());

        }

        //Api permet de retourner nombre de resources par availibility
        [HttpGet]
        [Route("api/nbreResourcesAvailibility")]
        public IHttpActionResult GetNombreOfResourcesAvailibility(DomainMap.Entities.TypeAvailability av)
        {
            ServiceResource ServiceR = new ServiceResource();

            return Ok(ServiceR.ResourceByAvailibility(av));
            
           
          

        }


        //Api permet de retourner nombre de resources indayoff
        [HttpGet]
        [Route("api/nbreResourcesInDayOff")]
        public IHttpActionResult GetNombreOfResourcesInDayOff()
        {
            ServiceResource ServiceR = new ServiceResource();
            return Ok(ServiceR.ResourceInDayOff());
          

        }


        //Api recherche resource par name
        [HttpGet]
        [Route("api/nbreResourcesByAddress")]
        public IHttpActionResult GetResourcesByAddress(string name)
        {
            ServiceResource ServiceR = new ServiceResource();
            IEnumerable<Resource> sr = new List<Resource>();
            sr = ServiceR.ResourceByName(name);
            List<Resource> r = new List<Resource>();

            foreach (var item in sr)
                r.Add(new Resource
                {
                    LastName = item.LastName,
                    FirstName = item.FirstName
                });
            return Ok(r);

        }


        [HttpGet]
        [Route("api/mostMandats")]
        public IHttpActionResult GetMostMandts(DateTime? datestart , DateTime? dateend)
        {
            ServiceMandat ServiceR = new ServiceMandat();
            Dictionary<int,int> sr = new Dictionary<int, int>();
            sr = ServiceR.getMostTerm(datestart,dateend);
           // Dictionary<int, int> r = new Dictionary<int, int>();
            


            return Ok(sr);

        }

        //Api permet de retourner nombre de mandats
        [HttpGet]
        [Route("api/nbrMandats")]
        public IHttpActionResult GetNombreOfMandats()
        {
            ServiceMandat ServiceR = new ServiceMandat();

            return Ok(ServiceR.nbMandats());


        }

        [HttpGet]
        [Route("api/tauxProgress")]
        public IHttpActionResult tauxAvan()
        {
            ServiceProject ServiceP = new ServiceProject();

            return Ok(ServiceP.mapTaux());




        }
    }
}
