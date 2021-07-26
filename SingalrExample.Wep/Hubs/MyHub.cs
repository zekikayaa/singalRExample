using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SingalrExample.Wep.Interfaces;

namespace SingalrExample.Wep.Hubs
{
    public class MyHub : Hub<IMessageClient> //Hub
    {
        private static List<string> clients = new List<string>();

        // public async Task SendMessageAsync(string message)
        // {
        //     // Clients.All  //  butun client lara gondericez
        //
        //     //receiveMessage  // client tarafindaki  method'umuz  
        //     // client tarafindaki method un aldigi(gonderdigimiz) parametre
        //
        //     await Clients.All.SendCoreAsync("receiveMessage", new[] {message});
        // }

        // sisteme yeni bir client baglatigi zaman tektiklenen method
        public override async Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);
            // await Clients.All.SendAsync("clients", clients);
            // await Clients.All.SendAsync("userJoined", Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.UserJoined(Context.ConnectionId);
        }

        // sistemden bir kullanici ayrildigi zaman tetiklenen method
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            // eger client html bazli bir sayfa ise , sayfayi yenileme isleminde once  baglantisini koparir ve sonra tekrardan baglanir

            clients.Remove(Context.ConnectionId);
            // await Clients.All.SendAsync("clients", clients);
            // await Clients.All.SendAsync("userLeaved", Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.UserLeaved(Context.ConnectionId);
        }
    }
}