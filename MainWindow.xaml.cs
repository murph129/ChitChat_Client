using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChitChat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Window1 display;
        User m_user;
        List<User> m_users = new List<User>();
        public int number;

        public MainWindow(Window1 Display)
        {
            InitializeComponent();
            txtUsername.Focus();
            display = Display;
        }
        
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            m_user = new User();
            String username = String.Empty;
            String password = String.Empty;

            username = txtUsername.Text;
            password = txtPassword.Text;

            ClearUILabels();           
            
            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
            {
                m_user.UserName = txtUsername.Text;
                m_user.Password = txtPassword.Text;
                
                Int32 port = 13000;
                TcpClient client = new TcpClient("127.0.0.1",8189);
 
                // Translate the passed message into ASCII and store it as a Byte array.
                
 
                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();
 
                NetworkStream stream = client.GetStream();
 
                // Send the message to the connected TcpServer.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("connect\n");
                stream.Write(data, 0, data.Length);

                Byte[] message = System.Text.Encoding.ASCII.GetBytes(m_user.UserName + "," + m_user.Password + "\n");
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
                    
                    // DISPLAY FALSE CONNECTION MESSGE
                }
                else
                {
                    ClearUILabels();
                    //MessageBox.Show("Login successful!", "Login", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    display.SwitchtoChat(m_user.UserName); //add userid as parameter
                }               
            }
            else
            {
                if (String.IsNullOrEmpty(username))
                {
                    UserNameStatus("Please enter a username.");
                }
                if (String.IsNullOrEmpty(password))
                {
                    PasswordStatus("Please enter a password.");
                }
            }
            //Auto Login for now
        }

        private bool IsAuthenticateUser(User a_user)
        {
            if (!String.IsNullOrEmpty(a_user.UserName) && !String.IsNullOrEmpty(a_user.Password))
            {
                foreach (User user in m_users)
                {
                    if (user.UserName == a_user.UserName && user.Password == a_user.Password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void ClearUILabels()
        {
            lblPasswordLoginError.Text = String.Empty;
            lblUsernameLoginError.Text = String.Empty;
        }

        public void UserNameStatus(String a_status)
        {
            lblUsernameLoginError.Text = a_status;
        }

        public void PasswordStatus(String a_status)
        {
            lblPasswordLoginError.Text = a_status;
        }

        private bool IsNewUser(String a_username)
        {
            if (!String.IsNullOrEmpty(a_username))
            {
                foreach (User user in m_users)
                {
                    if (user.UserName == a_username)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsPassword(User a_user)
        {
            if (!String.IsNullOrEmpty(a_user.Password))
            {
                foreach (User user in m_users)
                {
                    if (user.UserName == a_user.UserName)
                    {
                        if (user.Password == a_user.Password)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void ProcessUsers()
        {
            String path = @"C:\Client\ChitChat\ChitChat\bin\Debug\";
            String file = "LoginCredentials.csv";
            List<User> users = new List<User>();
            int index = 0;

            var lines = File.ReadAllLines(path + file).Select(a => a.Split(';'));
            var csv = from line in lines
                      select (line);

            foreach (var line in csv)
            {
                if (index == 0)
                {
                    String header = line[index];
                }
                else
                {
                    String[] value = line[0].Split(',');
                    users.Add(new User() { UserName = value[0], Password = value[1], FirstName = value[2], LastName = value[3], DateOfBirth = value[4], Email = value[5] });                   
                }
                index++;
            }
            m_users = users;
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            display.SwitchtoSignUp();
        }
    }
}
