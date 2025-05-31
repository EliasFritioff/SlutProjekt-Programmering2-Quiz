using System;
using System.Net.Sockets;
using System.Text;

namespace QuizGame.Network
{
    public class Client
    {
        public void Connect()
        {
            var client = new TcpClient("localhost", 5000);
            var stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Server säger: " + response);
            client.Close();
        }
    }
}
