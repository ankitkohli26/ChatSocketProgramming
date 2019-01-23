using System.Net;
using System.Net.Sockets;
using System.Text;
using System;

namespace Chat_Server
{
    class ServerSocket
    {
        public static Socket socket;
        public Socket clientSocket;
        private byte[] buffer = new byte[1024];
        public ServerSocket()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        
        public void Bind(int port)
        {
            socket.Bind(new IPEndPoint(IPAddress.Any,port));
        }
        public void Listen(int conn)
        {
            socket.Listen(conn);
        }
        public void Accept()
        {
            socket.BeginAccept(AcceptedCallBack, null);
        }
        private void AcceptedCallBack(IAsyncResult aResult)
        {
            clientSocket = socket.EndAccept(aResult);
            //Console.WriteLine("Connected with {0} at port {1}", clientep.Address, clientep.Port);
            Console.WriteLine("Connected with Client...");
            buffer = new byte[1024];
            clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceivedCallBack, clientSocket);
            Accept();
        }
        private void ReceivedCallBack(IAsyncResult aResult)
        {
            Socket clientSocket = aResult.AsyncState as Socket;
            SocketError SE;
            int bufferSize = clientSocket.EndReceive(aResult,out SE);
            if (SE == SocketError.Success)
            {
                byte[] packet = new byte[bufferSize];
                Array.Copy(buffer, packet, packet.Length);
                //Handle the packet
                PacketHandler.Handle(packet, clientSocket);
                buffer = new byte[1024];
                clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceivedCallBack, clientSocket);
            }    
        }

    }
}
