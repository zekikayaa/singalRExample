using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SingalrExample.Wep.Hubs
{
    public class MyHub : Hub
    {
        public async Task SendMessageAsync(string message)
        {
            // Clients.All  //  butun client lara gondericez

            //receiveMessage  // client tarafindaki  method'umuz  
            // client tarafindaki method un aldigi(gonderdigimiz) parametre
            
            await Clients.All.SendCoreAsync("receiveMessage", new[] {message});
        }
    }
}