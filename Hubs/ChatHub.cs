using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebAPI.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessageToGroup(string email, string message, string chatId)
        {
            await Clients.Group(chatId).SendAsync("ReceiveMessage", email, message);
        }
        public async void AddToGroup(string chatId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId);
        }

        public async void RemoveFromGroup(string chatId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId);
        }
    }
}
