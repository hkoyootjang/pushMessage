using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ServiceApi
{
    public class MyHub : Hub
    {
        public static Dictionary<string, string> userList = new Dictionary<string, string>();

        public void Hello()
        {
            Clients.All.hello("lalalalala");
        }

        public void Login(string name)
        {
            var connectionId = Context.ConnectionId;
            if (!userList.Keys.Contains(connectionId))
                userList.Add(connectionId, name);

            Clients.All.userList(userList);
        }

        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }
    }
}