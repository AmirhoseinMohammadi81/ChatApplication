using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.Hubs
{
    public class WeatherHub:Hub
    {
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",message);
        }
    }
}
