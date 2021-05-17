using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Service.Hubs
{
    public class MyHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello("啦啦啦啦");
        }
    }
}