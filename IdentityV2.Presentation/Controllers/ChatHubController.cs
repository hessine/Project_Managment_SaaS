using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Web.Mvc;
using IdentityV2.Presentation.Models;

namespace IdentityV2.Presentation.Controllers
{
    public class ChatHubController :  Controller
    {
        ChatHub m=new ChatHub();
       public ActionResult msg(string name2, string message2)
        {
           
            m.Send( name2,  message2);
            return View(m);
        }

    }
}