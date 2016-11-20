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

namespace ChitChat
{
    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {

        Window1 display;

        public ChatWindow(Window1 Display)
        {
            InitializeComponent();
            display = Display;
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            txtContent.Text += txtInput.Text;
            txtContent.Text += Environment.NewLine;
            txtInput.Clear();
        }

        private void tb_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                btnSend_Click(sender, e);
            }
        }



        
    }
}
