using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace x_devs_hacks.Hubs
{
    public class PickupHub : Hub
    {
        public void SendPickUp(int IdUser,string Description, string Image, double Lat, double Long)
        {
            Clients.All.broadcastPick();
        }
    }
}