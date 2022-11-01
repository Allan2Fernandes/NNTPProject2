using NNTPProject.Model;
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
        static TcpClient socket = null;
        public static NetworkStream ns = null;
        string recievedMessage;
        public static StreamReader sr;
        public static StreamWriter sw;
        string response;
        DatabaseHandler DBHandler;

        private LoginViewModel loginViewModel = null;
        public LoginView()
        {
            loginViewModel = (LoginViewModel)((App)App.Current).GetViewModel("LoginViewModel");
            this.DataContext = loginViewModel;
            InitializeComponent();
            DBHandler = new DatabaseHandler();
        }

        public string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        public string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }

        public bool SetUpConnection(string Username, string Password)
        {
            try
            {
                socket = new TcpClient(serverName, serverPort);
                ns = socket.GetStream();
                sr = new StreamReader(ns, System.Text.Encoding.Default);
                sw = new StreamWriter(ns);
                
                ns.Flush();
                recievedMessage = sr.ReadLine();
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
                    string EncodedPassword = EncodePasswordToBase64(Password);
                    string DecodedPassword = DecodeFrom64(EncodedPassword);
                    Debug.WriteLine("Encoded password is " + EncodedPassword);
                    Debug.WriteLine("Decoded password is " + DecodedPassword);
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
                //CloseConnection();
            }
            return false;
        }

        public static void CloseConnection()
        {
            try
            {
                ns.Close();
                sr.Close();
                sw.Close();
                socket.Close();
            }catch(Exception e)
            {
                Debug.WriteLine("Pointless error");
            }
        }

        public void Authenticate()
        {
            string[] LogInDetails = DBHandler.GetLogInDetails();
            UsernameField.Text = LogInDetails[0];
            string Password = DecodeFrom64(LogInDetails[1]);
            PasswordField.Text = Password;
            bool CorrectlyAuthenticated = SetUpConnection(UsernameField.Text, PasswordField.Text);
            if (CorrectlyAuthenticated)
            {
                AuthenticationResponse.Content = "Response: Authenticated";
                SwitchSceneButton.Visibility = Visibility.Visible;
                string EncryptedPassword = EncodePasswordToBase64(PasswordField.Text);
                DBHandler.StoreLogInDetails(UsernameField.Text, EncryptedPassword);
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
