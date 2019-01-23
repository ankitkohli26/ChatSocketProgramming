using System.Net;
using System.Net.Sockets;
using System.Text;
using System;

namespace Chat_Client
{
    class ClientSocket
    {
        static Socket socket;
        private byte[] buffer = new byte[1024];
        public ClientSocket()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void Connect(string ipaddress,int port)
        {
            socket.BeginConnect(new IPEndPoint(IPAddress.Parse(ipaddress),port),ConnectCallBack,null);
        }
        private void ConnectCallBack(IAsyncResult result)
        {
            if (socket.Connected)
            {
                Console.WriteLine("Connected to the server...");
                //socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceivedCallBack, null);
                buffer = new byte[1024];
                byte[] packet = new byte[4];
                byte[] packetLength = BitConverter.GetBytes((ushort)packet.Length);
                byte[] packetType = BitConverter.GetBytes((ushort)1000);
                Array.Copy(packetLength,packet,2);
                Array.Copy(packetType, 0, packet, 2, 2);
                socket.Send(packet);
            }
            else
                Console.WriteLine("Could not connect to the server");
        }
        private void ReceivedCallBack(IAsyncResult result)
        {
            int bufferLength = socket.EndReceive(result);
            byte[] packet = new byte[1024];
            Array.Copy(buffer,packet,packet.Length);
            //Handle packet
            buffer = new byte[1024];
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceivedCallBack, null);
        }
        public void Send(byte[] data)
        {
            socket.Send(data);
        }
    }
}
