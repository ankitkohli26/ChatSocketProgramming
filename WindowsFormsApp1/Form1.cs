using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        TcpClient clientSocket = new TcpClient();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender,EventArgs e)
        {
            Console.WriteLine("Started");
            msg("Client Started");
            clientSocket.Connect("127.0.0.1", 8888);
            label1.Text = "Client Socket Program - Server Connected ...";
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = Encoding.ASCII.GetBytes(richTextBox2.Text + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
            string returndata = Encoding.ASCII.GetString(inStream);
            msg(returndata);
            richTextBox2.Text = "";
            richTextBox2.Focus();
        }

        public void msg(string message)
        {
            richTextBox1.Text = richTextBox1.Text + Environment.NewLine + " >> " + message;
        }
    }
}
