using NNTPProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading;
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

namespace NNTPProject.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        String serverName = "news.sunsite.dk";
        int serverPort = 119;
        TcpClient socket = null;
        NetworkStream ns = null;
        StreamReader reader = null;
        string recievedMessage;
        public static StreamReader sr;
        public static StreamWriter sw;
        string response;

        private LoginViewModel loginViewModel = null;
        public LoginView()
        {
            loginViewModel = (LoginViewModel)((App)App.Current).GetViewModel("LoginViewModel");
            this.DataContext = loginViewModel;
            InitializeComponent();
        }

        public bool SetUpConnection(string Username, string Password)
        {
            try
            {
                socket = new TcpClient(serverName, serverPort);
                ns = socket.GetStream();
                ns.Flush();
                reader = new StreamReader(ns, Encoding.UTF8);
                recievedMessage = reader.ReadLine();

                sr = new StreamReader(ns, System.Text.Encoding.Default);
                sw = new StreamWriter(ns);
                sw.AutoFlush = true;

                //Try the username:
                string UsernameCommand = string.Format("authinfo user {0}", Username);
                sw.WriteLine(UsernameCommand);
                response = sr.ReadLine();  // Retrieve Response
                Thread.Sleep(100);

                //If successful, try the password
                if (response == "381 PASS required")
                {
                    string PasswordCommand = string.Format("authinfo pass {0}", Password);
                    sw.WriteLine(PasswordCommand);
                    response = sr.ReadLine();  // Retrieve Response
                    if (response == "281 Ok")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                CloseConnection();
            }
            return false;
        }

        public void CloseConnection()
        {
            ns.Close();
            reader.Close();
            socket.Close();
        }

        public void Authenticate()
        {
            bool CorrectlyAuthenticated = SetUpConnection(UsernameField.Text, PasswordField.Text);
            if (CorrectlyAuthenticated)
            {
                AuthenticationResponse.Content = "Response: Authenticated";
                SwitchSceneButton.Visibility = Visibility.Visible;
            }
            else
            {
                AuthenticationResponse.Content = "Response: Not Authenticated";
                SwitchSceneButton.Visibility = Visibility.Hidden;
            }
        }

        private void AuthenticateButton_Click(object sender, RoutedEventArgs e)
        {
            Authenticate();
        }
    }
}
