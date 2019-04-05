using DomainMap.Entities;
using Microsoft.AspNet.Identity;
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
    public class RequestServController : ApiController
    {
        IRequestService serviceReq = new ServiceRequest();
        IServiceRequiredSkills serviceRS = new ServiceRequiredSkills();
        IServiceClient serviceclient = new ServiceClient();

        [HttpGet]
        [Route("api/AfficheRequest")]

        public IHttpActionResult GetRequest()
        {
            int currentClient = User.Identity.GetUserId<int>();
            List<RequestViewModel> listR = new List<RequestViewModel>();
            foreach (var item in serviceReq.GetMany(t => t.ClientId == currentClient))
            {
                RequestViewModel Rvm = new RequestViewModel();

                Rvm.RequestId = item.RequestId;
                Rvm.subject = item.subject;
                Rvm.nbrResource = item.nbrResource;
                Rvm.DateBegin = item.DateBegin;
                Rvm.DateEnd = item.DateEnd;
                Rvm.DateDeposit = item.DateDeposit;
                Rvm.ClientId = item.ClientId;
                Rvm.coast = item.coast;
                Rvm.state = (WebMap.Models.RequestState)item.state;

                listR.Add(Rvm);

            }

            return Ok(listR);

        }
        
        [HttpGet]
        [Route("api/Details")]
          public IHttpActionResult DetailsRequest(int id)
        { 

        var req = serviceReq.GetById(id);
        RequestViewModel RVM = new RequestViewModel();

        RVM.subject = req.subject;
            RVM.state.Equals(req.state);
            RVM.DateBegin = req.DateBegin;
            RVM.subject = req.subject;
            RVM.DateDeposit = req.DateDeposit;
            RVM.nbrResource = req.nbrResource;
            RVM.DateEnd = req.DateEnd;
            RVM.coast = req.coast;
            RVM.state.Equals(req.state);
            RVM.ClientId = req.ClientId;


            return Ok(req);

            }
        



        [HttpDelete]
        [Route("api/Delete/id")]
        public IHttpActionResult DeleteRequest(int id)// RequestViewModel RVM  )
        {
            int currentClient = User.Identity.GetUserId<int>();
            Request R = serviceReq.GetById(id);

            //RVM.DateBegin = R.DateBegin;
            //RVM.state.Equals(R.state);
            //RVM.subject = R.subject;
            //RVM.DateDeposit = R.DateDeposit;
            //RVM.DateBegin = R.DateBegin;
            //RVM.nbrResource = R.nbrResource;
            //RVM.DateEnd = R.DateEnd;
            //RVM.coast = R.coast;

            serviceReq.Delete(R);
            serviceReq.Commit();

                      return Ok();
        }



        }
    }
