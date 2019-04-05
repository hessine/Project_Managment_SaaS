using DomainMap.Entities;
using ServiceMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebMap.Models;

namespace WebMap.Controllers
{
    public class MandateRetriveController : ApiController
    {

        IServiceMandate Sm = new ServiceMandate();
        [HttpGet]
        public IEnumerable<Mandate> GetAllMandate()

        {

            return Sm.GetAll();

        }
        public IHttpActionResult GetMandat(int idp, int idr)
        {
            MandateViewModel mv = null;
            mv = Sm.GetAll().Where(a => a.ProjectId == idp).Where(t => t.userId == idr).Select(s => new MandateViewModel()
            {
                DateBegin = s.DateBegin,
                Duree = s.Duree

            }).First<MandateViewModel>();
            if (mv == null)
            {
                return NotFound();
            }
            return Ok(mv);

        }
    }
}
