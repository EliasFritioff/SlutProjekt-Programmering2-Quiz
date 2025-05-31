using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace QuizGame.Network
{
    public class Server
    {
        public void Start()
        {
            var listener = new TcpListener(IPAddress.Any, 5000);
            listener.Start();
            Console.WriteLine("Server startad på port 5000...");

            while (true)
            {
                var client = listener.AcceptTcpClient();
                var stream = client.GetStream();
                byte[] buffer = Encoding.UTF8.GetBytes("Välkommen till quiz-servern!\n");
                stream.Write(buffer, 0, buffer.Length);
                client.Close();
            }
        }
    }
}
