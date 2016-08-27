using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace x_devs_hacks.Hubs
{
    public class PickUpHub : Hub
    {
        public void SendPickUp()
        {
            Clients.All.UpdatePickUpd();
        }
    }
}