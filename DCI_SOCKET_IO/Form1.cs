
using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DCI_SOCKET_IO
{
    public partial class Form1 : Form
    {
        private Socket socket;

        public Form1()
        {
            InitializeComponent();
            InitializeSocket();
        }

        private void InitializeSocket()
        {
            // Connect to the Socket.IO server
            socket = IO.Socket("http://localhost:9999");

            // Define event handlers
            socket.On(Socket.EVENT_CONNECT, () =>
            {
                Console.WriteLine("Connected to server");
            });

            socket.On("message", (data) =>
            {
                Console.WriteLine("Received: " + data);
            });

            socket.On(Socket.EVENT_DISCONNECT, () =>
            {
                Console.WriteLine("Disconnected from server");
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (socket != null )
            {
                string message = textBox1.Text;
                socket.Emit("message", message);
                Console.WriteLine("Sent: " + message);
            }
            else
            {
                Console.WriteLine("Not connected to server");
            }
        }
    }
}
