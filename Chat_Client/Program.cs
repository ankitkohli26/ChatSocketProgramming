using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using Chat_Client.Packets;

namespace Chat_Client
{
    class Program
    {
        private static ClientSocket clientSocket = new ClientSocket();
        static void Main(string[] args)
        {
            clientSocket.Connect("127.0.0.1", 6656);
            while (true)
            {
                string msg=Console.ReadLine();
                Message packet = new Message(msg);
                clientSocket.Send(packet.Data);
            }
        }
    }
}
