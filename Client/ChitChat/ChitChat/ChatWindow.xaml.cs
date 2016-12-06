using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
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

namespace ChitChat
{
    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {

        Window1 display;
        TcpClient client;
        NetworkStream stream;
        String userName;
        bool started = false;

        public String UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        public bool Started
        {
            get
            {
                return started;
            }
            set
            {
                started = value;
            }
        }

        public ChatWindow(Window1 Display)
        {
            InitializeComponent();
            txtInput.KeyDown += new System.Windows.Input.KeyEventHandler(tb_KeyDown);
            display = Display;

        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            Byte[] message = System.Text.Encoding.ASCII.GetBytes(txtInput.Text + "\n");
            stream.Write(message, 0, message.Length);
            //Send text to Server
            //PsuedoCode: SendServer(Username + input)
            //Server displays chat
            //PsuedoCode: txtContent.text = GetServerChat();

            //Only for local use
            String input = "Username: " + txtInput.Text;
            txtContent.Text += input;
            txtContent.Text += Environment.NewLine;
            txtInput.Clear();
            txtInput.Focus();
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

        public void startListener()
        {
            started = true;
            client = new TcpClient("127.0.0.1", 8190);
            stream = client.GetStream();
            Byte[] message = System.Text.Encoding.ASCII.GetBytes("connect\n");
            stream.Write(message, 0, message.Length);
            Byte[] user = System.Text.Encoding.ASCII.GetBytes(userName + "\n");
            stream.Write(user, 0, user.Length);

            while (true)
            {
                Byte[] data = new Byte[256];

                // String to store the response ASCII representation.
                String[] responseData = null;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes).Split(',');
                txtContent.Text += responseData;
                txtContent.Text += Environment.NewLine;
            }
        }
    }
}
