using NNTPProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace NNTPProject.View
{
    /// <summary>
    /// Interaction logic for PostArticleView.xaml
    /// </summary>
    public partial class PostArticleView : UserControl
    {
        private PostArticleViewModel postArticleViewModel;
        public PostArticleView()
        {
            postArticleViewModel = (PostArticleViewModel)((App)App.Current).GetViewModel("PostArticleViewModel");
            this.DataContext = postArticleViewModel;
            InitializeComponent();
            
        }

        private void PostButton_Click(object sender, RoutedEventArgs e)
        {
            //Get name
            string name = NameTextBox.Text;
            //Get subject
            string subject = SubjectTextBox.Text;
            //Get selected newsgroup
            string newsgroup = SelectedNewsGroup.Text;
            //get body
            string body = BodyTextBox.Text;
            
            //Run the command for posting using all of that
            LoginView.sw.WriteLine("post");
            Thread.Sleep(100);
            string response = LoginView.sr.ReadLine();
            LoginView.sw.WriteLine("From: " + name);       
            LoginView.sw.WriteLine("Subject: " + subject);       
            LoginView.sw.WriteLine("Newsgroups: " + newsgroup);
            LoginView.sw.WriteLine();
            LoginView.sw.WriteLine(body);
            LoginView.sw.WriteLine();
            LoginView.sw.WriteLine(".");
    

            //Get return code and print it to debug
            response = LoginView.sr.ReadLine();
            Debug.WriteLine(response);
        }
    }
}
