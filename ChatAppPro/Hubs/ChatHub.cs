using ChatAppPro.Data;
using ChatAppPro.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Models;

namespace ChatAppPro.Hubs
{
    public class ChatHub : Hub
    {
        private readonly UserManager<ChatUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ChatHub(ApplicationDbContext context, UserManager<ChatUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        DateTime miladiDate = DateTime.Now;

        public async Task SendMessage(string message)
        {
            try
            {
                var currentUser = await _userManager.GetUserAsync(Context.User);

                var command = new Message()
                {
                    MessageBody = message,
                    MessageDateTime = ConvertDateTime.ConvertMiladiToShamsi(miladiDate, $"{"yyyy"}/{"MM"}/{"dd"}"),
                    FromUser = currentUser,
                };

                _context.Messages.Add(command);
                await _context.SaveChangesAsync();

                await Clients.All.SendAsync("ReceiveMessage", new
                {
                    messageBody = command.MessageBody,
                    fromUser = currentUser.Email,
                    MessageDateTime = command.MessageDateTime
                });

            }
            //handle error
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("HubError", new { error = ex.Message });
            }
        }


        public override async Task OnConnectedAsync()
        {
            DateTime miladiDate = DateTime.Now;

            await Clients.All.SendAsync("UserConnected", new
            {
                connectionId = Context.ConnectionId,
                connectionDateTime = ConvertDateTime.ConvertMiladiToShamsi(miladiDate, $"{"yyyy"}/{"MM"}/{"dd"}"),
                messageDateTime = ConvertDateTime.ConvertMiladiToShamsi(miladiDate, $"{"yyyy"}/{"MM"}/{"dd"}")
            });
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("UserDesconnected");
        }
    }
}
