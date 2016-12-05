using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;

namespace ChitChat
{
    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {

        Window1 display;
        int j;
        TcpClient client1;
        NetworkStream stream;
        byte[] datalength = new byte[10];

        public ChatWindow(Window1 Display)
        {
            InitializeComponent();
            txtInput.KeyDown += new System.Windows.Input.KeyEventHandler(tb_KeyDown);
            display = Display;
            try
            {
                client1 = new TcpClient("127.0.0.0", 8190);
                stream = client1.GetStream();
                ClientReceive();
            }
            catch (Exception ex)
            {
                txtContent.Text = "Cannot connect to group.";
            }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            //Send text to Server
            //PsuedoCode: SendServer(Username + input)
            //Server displays chat
            //PsuedoCode: txtContent.text = GetServerChat();

            /*
            //Only for local use
            String input = "Username: " + txtInput.Text;
            txtContent.Text += input;
            txtContent.Text += Environment.NewLine;
            */


            byte[] data = Encoding.Default.GetBytes("Username: " + txtInput.Text);
            int length = data.Length;
            byte[] datalength = new byte[10];
            datalength = BitConverter.GetBytes(length);
            stream.Write(datalength, 0, 10);
            stream.Write(data, 0, data.Length);
            txtInput.Clear();
            txtInput.Focus();
            ClientReceive();
        }

        private void tb_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                btnSend_Click(sender, e);
            }
        }

        private void ShowProfile_Click(object sender, RoutedEventArgs e)
        {
            display.SwitchtoUser();
        }

        public void ClientReceive()
        {

            stream = client1.GetStream();
            byte[] data = new byte[BitConverter.ToInt32(datalength, 0)];
            stream.Read(data, 0, data.Length);
            txtInput.Text += System.Environment.NewLine + "Server : " + Encoding.Default.GetString(data);

        }
    }
}

