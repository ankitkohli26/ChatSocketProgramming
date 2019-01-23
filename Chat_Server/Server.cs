using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
namespace Chat_Server
{
    class Server
    {
        //static void Main(string[] args)
        //{
        //    //IPHostEntry host = Dns.GetHostEntry("127.0.0.1");
        //    IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
        //    TcpListener serverSocket = new TcpListener(iPAddress, 8888);
        //    int requestCount = 0;
        //    TcpClient clientSocket = default(TcpClient);
        //    serverSocket.Start();
        //    Console.WriteLine(" >> Server Started");
        //    clientSocket = serverSocket.AcceptTcpClient();
        //    Console.WriteLine(" >> Accept connection from client");
        //    requestCount = 0;

        //    while(true)
        //    {
        //        try
        //        {
        //            requestCount = requestCount + 1;
        //            NetworkStream networkStream = clientSocket.GetStream();
        //            byte[] bytesFrom = new byte[10025];
        //            networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
        //            string dataFromClient = Encoding.ASCII.GetString(bytesFrom);
        //            dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
        //            Console.WriteLine(" >> Data from client - " + dataFromClient);
        //            string serverResponse = "Last Message from client" + dataFromClient;
        //            Byte[] sendBytes = Encoding.ASCII.GetBytes(serverResponse);
        //            networkStream.Write(sendBytes, 0, sendBytes.Length);
        //            networkStream.Flush();
        //            Console.WriteLine(" >> " + serverResponse);
        //            clientSocket.Close();
        //            serverSocket.Stop();
        //            Console.WriteLine(" >> exit");
        //            Console.ReadLine();
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.ToString());
        //        }
        //    }
            
        //}
    }
}
