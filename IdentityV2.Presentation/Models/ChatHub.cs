using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace IdentityV2.Presentation.Models
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            // Call the broadcastMessage method to update clients.
           context.Clients.All.broadcastMessage(name, message);

        }
    }
}