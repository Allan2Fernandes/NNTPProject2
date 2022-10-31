using NNTPProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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
    /// Interaction logic for ShowListView.xaml
    /// </summary>
    public partial class ShowListView : UserControl
    {
        private ShowListViewModel showListViewModel = null;

        String serverName = "news.sunsite.dk";
        int serverPort = 119;
        TcpClient socket = null;
        NetworkStream ns = null;
        string recievedMessage;
        public static StreamReader sr;
        public static StreamWriter sw;
        byte[] bytes = new byte[1024];
        string response;
        List<string> ArticleHeaders = new List<string>();


        public ShowListView()
        {
            showListViewModel = (ShowListViewModel)((App)App.Current).GetViewModel("ShowListViewModel");
            this.DataContext = showListViewModel;
            InitializeComponent();
        }

        public bool SetUpConnection(string Username, string Password)
        {
            try
            {
                socket = new TcpClient(serverName, serverPort);
                ns = socket.GetStream();
                ns.Flush();
                sr = new StreamReader(ns, Encoding.UTF8);
                recievedMessage = sr.ReadLine();

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

                        sw.WriteLine("list");
                        int length = ns.Read(bytes, 0, 1024);
                        for (int i = 0; i < length; i++)
                        {
                            
                            string header = sr.ReadLine();
                            ArticleHeaders.Add(header);
                            
                        }
                        ArticleHeaders.ForEach(item => ListOfGroups.Items.Add(item));
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
            sr.Close();
            socket.Close();
        }

        public void Authenticate()
        {
            bool CorrectlyAuthenticated = SetUpConnection("allan2fernandes@hotmail.com", "5156c1");
            if (CorrectlyAuthenticated)
            {
                Debug.WriteLine("Connected");
            }
            else
            {
                Debug.WriteLine("Not Connected");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Authenticate();
        }
    }
}
