using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        MainWindow main;
        SignUpWindow SignUp;
        ChatWindow Chat;
        UserProfileWindow User;
        public Window1()
        {
            InitializeComponent();
            main = new MainWindow(this);
            SignUp = new SignUpWindow(this);
            Chat = new ChatWindow(this);
            User = new UserProfileWindow(this);
            SwitchtoMain();
        }

        public void SwitchtoMain()
        {
            this.Content = main.Content;
            this.Title = main.Title;
        }

        public void SwitchtoSignUp()
        {
            this.Content = SignUp.Content;
            this.Title = SignUp.Title;
        }

        public void SwitchtoChat()
        {
            this.Content = Chat.Content;
            this.Title = Chat.Title;
        }

        public void SwitchtoUser()
        {
            this.Content = User.Content;
            this.Title = User.Title;
        }
    }
}
