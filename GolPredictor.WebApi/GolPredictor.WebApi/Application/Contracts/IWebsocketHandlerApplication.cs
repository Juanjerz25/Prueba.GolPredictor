using System.Net.WebSockets;
using System.Threading.Tasks;

namespace GolPredictor.WebApi.Application.Contracts
{
    public interface IWebsocketHandlerApplication
    {
        Task Handle(string id, WebSocket webSocket);
    }
}
