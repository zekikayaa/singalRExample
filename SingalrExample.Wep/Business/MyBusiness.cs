using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SingalrExample.Wep.Hubs;

namespace SingalrExample.Wep.Business
{
    public class MyBusiness
    {
        private readonly IHubContext<MyHub> _hubContext;

        public MyBusiness(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageAsync(string message)
        {
            // Clients.All  //  butun client lara gondericez

            //receiveMessage  // client tarafindaki  method'umuz  
            // client tarafindaki method un aldigi(gonderdigimiz) parametre

            await _hubContext.Clients.All.SendCoreAsync("receiveMessage", new[] {message});
        }
    }
}