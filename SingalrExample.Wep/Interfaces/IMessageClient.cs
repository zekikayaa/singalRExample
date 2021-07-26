using System.Collections.Generic;
using System.Threading.Tasks;

namespace SingalrExample.Wep.Interfaces
{
    public interface IMessageClient
    {
        Task Clients(List<string> clients);

        Task UserJoined(string connectionId);

        Task UserLeaved(string connectionId);
    }
}