using GolPredictor.WebApi.Application.Contracts;
using GolPredictor.WebApi.DTO.Sesion;
using GolPredictor.WebApi.DTO.Websocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace GolPredictor.WebApi.Application
{
    public class WebsocketHandlerApplication: IWebsocketHandlerApplication
    {
        #region Fields

        public List<SocketConnection> websocketConnections = new List<SocketConnection>();
        private readonly ISesionApplication _sesionApplication;

        #endregion

        #region Builder

        public WebsocketHandlerApplication(ISesionApplication sesionApplication)
        {
            SetupCleanUpTask();
            _sesionApplication = sesionApplication;
        }
        #endregion

        #region Methods
        public async Task Handle(string id, WebSocket webSocket)
        {
            lock (websocketConnections)
            {
                websocketConnections.Add(new SocketConnection
                {
                    Action = id,
                    WebSocket = webSocket
                });
            }

            while (webSocket.State == WebSocketState.Open)
            {
                if (id == nameof(EnumSocketType.SesionesActivas))
                {
                    await SendSesionesActivas(id, webSocket);
                }


                await Task.Delay(5000);
            }
        }
        #endregion

        #region Private Methods


        #endregion

        #region Private Methods
        private async Task SendSesionesActivas(string id, WebSocket webSocket)
        {
            var sesiones = _sesionApplication.GetSesiones();
            var json = JsonSerializer.Serialize(sesiones);
            var buffer = Encoding.UTF8.GetBytes(json);
            await webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
        }
        private async Task<string> ReceiveMessage(string id, WebSocket webSocket)
        {
            var arraySegment = new ArraySegment<byte>(new byte[4096]);
            var receivedMessage = await webSocket.ReceiveAsync(arraySegment, CancellationToken.None);
            if (receivedMessage.MessageType == WebSocketMessageType.Text)
            {
                var message = Encoding.Default.GetString(arraySegment).TrimEnd('\0');
                if (!string.IsNullOrWhiteSpace(message))
                    return $"<b>{id}</b>: {message}";
            }
            return null;
        }
        private void SetupCleanUpTask()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    IEnumerable<SocketConnection> openSockets;
                    IEnumerable<SocketConnection> closedSockets;

                    lock (websocketConnections)
                    {
                        openSockets = websocketConnections.Where(x => x.WebSocket.State == WebSocketState.Open || x.WebSocket.State == WebSocketState.Connecting);
                        closedSockets = websocketConnections.Where(x => x.WebSocket.State != WebSocketState.Open && x.WebSocket.State != WebSocketState.Connecting);

                        websocketConnections = openSockets.ToList();
                    }
                    await Task.Delay(5000);
                }
            });
        }
        #endregion
    }
}
