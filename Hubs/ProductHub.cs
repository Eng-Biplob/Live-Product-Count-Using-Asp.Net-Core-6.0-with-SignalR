﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace AspNetCoreSignalRProductCount.Hubs
{   
    public class ProductHub : Hub
    {
        public static List<string> _products = new();
        public async Task SendProduct(string productName)
        {
            _products.Add(productName);
            await Clients.All.SendAsync("ReceiveProduct", productName, _products.Count());
        }
        public async Task ResetProduct()
        {
            _products.Clear();
            await Clients.All.SendAsync("ReceiveResetProduct");
        }

        //public override Task OnConnectedAsync()
        //{
        //    Groups.AddToGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
        //    return base.OnConnectedAsync();
        //}
        //public async Task SendMessage(string user, string message)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", user, message);
        //}

        //public Task SendMessageToGroup(string sender, string receiver, string message)
        //{
        //    return Clients.Group(receiver).SendAsync("ReceiveMessage", sender, message);
        //}
    }
}
