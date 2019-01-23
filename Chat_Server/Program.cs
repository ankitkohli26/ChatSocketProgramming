using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Chat_Server.Packets;

namespace Chat_Server
{
    class Program
    {
        public static ServerSocket serverSocket = new ServerSocket();
        static void Main(string[] args)
        {
            serverSocket.Bind(6656);
            serverSocket.Listen(5);
            Console.WriteLine("Waiting for a client...");
            serverSocket.Accept();
            while (true)
            {
                //Console.ReadLine();
                string msg = Console.ReadLine();
                Message packet = new Message(msg);
                serverSocket.clientSocket.Send(packet.Data);
            }
        }  
    }
}
