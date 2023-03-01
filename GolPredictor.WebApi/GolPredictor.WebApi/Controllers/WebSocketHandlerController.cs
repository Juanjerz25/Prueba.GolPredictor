using GolPredictor.WebApi.Application.Contracts;
using GolPredictor.WebApi.DTO.Partido;
using GolPredictor.WebApi.DTO.Response;
using GolPredictor.WebApi.DTO.UserAdmin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace GolPredictor.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class WebSocketHandlerController : ControllerBase
    {
        #region Fields
        private readonly IWebsocketHandlerApplication _websocketHandlerApplication;

        #endregion

        #region Builder

        public WebSocketHandlerController(IWebsocketHandlerApplication websocketHandlerApplication)
        {
            _websocketHandlerApplication = websocketHandlerApplication;
        }


        #endregion

        #region Methods

        [HttpGet]
        [Route(nameof(WebSocketHandlerController.Socket))]
        public async Task Socket(string action)
        {
            var context = ControllerContext.HttpContext;
            var isSocketRequest = context.WebSockets.IsWebSocketRequest;

            if (isSocketRequest)
            {
                WebSocket websocket = await context.WebSockets.AcceptWebSocketAsync();

                await _websocketHandlerApplication.Handle(action, websocket);
            }
            else
            {
                context.Response.StatusCode = 400;
            }
        }

        #endregion
    }
}
