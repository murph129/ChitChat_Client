using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
using System.Windows.Threading;
using System.ComponentModel;
using System.Windows.Forms;

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
            //String input = "Username: " + txtInput.Text;
            //lbContent.Items.Add(input);
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

        BackgroundWorker m_backGroundWorker;
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!Started)
            {
                startListener();
            }
        }

        private void backGroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (System.Windows.Application.Current.Dispatcher.CheckAccess())
            {
                string text = ((String[])e.UserState)[0];
                lbContent.Items.Add(text);
            }
            else
            {
                System.Windows.Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                {
                    string text = ((String[])e.UserState)[0];
                    lbContent.Items.Add(text);
                }));
                return;
            }
        }

        private void backGroundWorker_runWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Form.ActiveForm.Close();
            //Form.ActiveForm.Dispose();
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

            Byte[] data = new Byte[256];
            // String to store the response ASCII representation.
            String[] responseData = null;

            while (client.Connected)
            {                               
                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes).Split(',');
                if(responseData[0] != null && responseData[0] != string.Empty)
                {
                    m_backGroundWorker.ReportProgress(1, responseData);
                }
            }
    }

    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
        WriteTextFile();
        CreateTxt();
    }

        public void PathExist()
        {
            string path = @"C:\API";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

    public void WriteTextFile()
    {
            PathExist();
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\API\ChatText.txt", false))
        {
            foreach (var line in lbContent.Items)
            {
                file.WriteLine(line.ToString());
            }
        }
    }

    public void CreateTxt()
    {
        UserCredential credential;
        using (var filestream = new FileStream(@"C:\Users\Alex Lamas\Documents\My C# Projects\Google API\GoogleApiConsole\GoogleApiConsole\client_secret.json",
            FileMode.Open, FileAccess.Read))
        {
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.Load(filestream).Secrets,
                new[] { DriveService.Scope.Drive },
                "user",
                CancellationToken.None,
                new FileDataStore("UploadedPdf/")).Result;
        }

        // Create the service.
        var service = new DriveService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = "Drive API Sample",
        });

        Google.Apis.Drive.v3.Data.File body = new Google.Apis.Drive.v3.Data.File();
        body.Name = "My Chat Text";
        body.Description = "Text being saved from Chit Chat.";
        body.MimeType = "text/csv";

        byte[] byteArray = System.IO.File.ReadAllBytes(@"C:\API\ChatText.txt");
        System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);

        FilesResource.CreateMediaUpload request = service.Files.Create(body, stream, "text/plain text");
        request.Upload();

        Google.Apis.Drive.v3.Data.File file = request.ResponseBody;

        System.Windows.MessageBox.Show("File uploaded to Google Drive successfully.", "File Upload", MessageBoxButton.OK);
    }

        private void ChatWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtInput.Focus();
            if (m_backGroundWorker == null)
            {
                m_backGroundWorker = new BackgroundWorker();
                m_backGroundWorker.WorkerReportsProgress = true;
                m_backGroundWorker.WorkerSupportsCancellation = true;
                m_backGroundWorker.ProgressChanged += new ProgressChangedEventHandler(backGroundWorker_ProgressChanged);
                m_backGroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
                m_backGroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backGroundWorker_runWorkerCompleted);
                m_backGroundWorker.RunWorkerAsync();
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            //Byte[] message = System.Text.Encoding.ASCII.GetBytes("CLIENT_GOODBYE\n");
            //stream.Write(message, 0, message.Length);            
            display.SwitchtoMain();
        }
    }
}
