using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DownloadManager.Service.Contract;
using Microsoft.AspNet.SignalR;

namespace DownloadManager.Web.Logging
{
    public class SignalRLogger : ILogger
    {
        private readonly IHubContext _hubContext;

        public SignalRLogger()
        {
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<LogHub>();
        }

        public void Log(string message)
        {
            _hubContext.Clients.All.ReceiveLog(message);
        }
    }

    public class LogHub : Hub
    {
        public void SendLog(string message)
        {
            Clients.All.ReceiveLog(message);
        }
    }
}