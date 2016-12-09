using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChitChat
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        MainWindow window;
        Window1 display;
        public SignUpWindow(Window1 Display)
        {
            InitializeComponent();
            display = Display;
           
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUsername.Text) && !String.IsNullOrEmpty(txtPassword.Text) && !String.IsNullOrEmpty(txtFirstName.Text) && !String.IsNullOrEmpty(txtLastName.Text) && !String.IsNullOrEmpty(txtDateOfBirth.Text) && !String.IsNullOrEmpty(txtEmail.Text))
            {
                String myMessage = "ADD," + txtUsername.Text + "," + txtPassword.Text + "," + txtFirstName.Text + "," + txtLastName.Text + "," + txtDateOfBirth.Text + "," + txtEmail.Text;
                TcpClient client = new TcpClient("127.0.0.1", 8191);

                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("connect\n");
                stream.Write(data, 0, data.Length);

                Byte[] message = System.Text.Encoding.ASCII.GetBytes(myMessage + "\n");
                stream.Write(message, 0, message.Length);
                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[256];

                // String to store the response ASCII representation.
                String[] responseData = null;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes).Split(',');
                // Close everything.
                stream.Close();
                client.Close();

                if (responseData[0] == "false")
                {

                    MessageBox.Show("There was an error while signing up: " + responseData[1], "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("User Profile Created! You can now sign in.", "Register", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    display.SwitchtoMain(); //add userid as parameter
                }
            }
            else
            {
                MessageBox.Show("Please enter all user profile information before continuing.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            window = new MainWindow(display);
            display.SwitchtoMain();
        }
    }
}
