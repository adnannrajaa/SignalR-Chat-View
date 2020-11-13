using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace SignalRChat
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();

        public void SendMessage(string who, string message)
        {
            string name = Context.User.Identity.Name;
            foreach (var connectionId in _connections.GetConnections(who))
            {
                Clients.Client(connectionId).SendAsync("ReceiveMessage", name , message);
            }
        }

        public override async Task OnConnectedAsync()
        {
            string name = Context.User.Identity.Name;

            _connections.Add(name, Context.ConnectionId);

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            string name = Context.User.Identity.Name;

            _connections.Remove(name, Context.ConnectionId);

            await base.OnDisconnectedAsync(exception);
        }

        //public override async Task OnReconnectedAsync()
        //{
        //    string name = Context.User.Identity.Name;

        //    if (!_connections.GetConnections(name).Contains(Context.ConnectionId))
        //    {
        //        _connections.Add(name, Context.ConnectionId);
        //    }

        //    await base.OnReconnectedAsync();
        //}
    }
}