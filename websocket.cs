using System;
using System.Diagnostics;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        HttpListener server = new HttpListener();
        server.Prefixes.Add("http://localhost:8080/");
        server.Start();
        Console.WriteLine("WebSocket Server started on ws://localhost:8080");

        while (true)
        {
            HttpListenerContext context = await server.GetContextAsync();
            if (context.Request.IsWebSocketRequest)
            {
                Process clientProcess = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "dotnet", // Chemin du jeu C# compilé
                        Arguments = "Archipel.dll",
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };
                clientProcess.Start();

                HttpListenerWebSocketContext wsContext = await context.AcceptWebSocketAsync(null);
                WebSocket ws = wsContext.WebSocket;

                _ = Task.Run(async () =>
                {
                    using (var reader = clientProcess.StandardOutput)
                    {
                        while (!reader.EndOfStream)
                        {
                            string output = await reader.ReadLineAsync();
                            byte[] buffer = Encoding.UTF8.GetBytes(output);
                            await ws.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
                        }
                    }
                });

                byte[] receiveBuffer = new byte[1024];
                while (ws.State == WebSocketState.Open)
                {
                    WebSocketReceiveResult result = await ws.ReceiveAsync(new ArraySegment<byte>(receiveBuffer), CancellationToken.None);
                    string command = Encoding.UTF8.GetString(receiveBuffer, 0, result.Count);
                    await clientProcess.StandardInput.WriteLineAsync(command);
                }
            }
        }
    }
}
