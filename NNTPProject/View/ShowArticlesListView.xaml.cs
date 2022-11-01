using NNTPProject.Model;
using NNTPProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Metadata;
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
    public partial class ShowArticlesListView : UserControl
    {
        private ShowArticlesListViewModel showListViewModel = null;
        private ShowListGroupViewModel showListGroupViewModel = null;
        private PostArticleViewModel postArticleViewModel = null;
        
        public static StreamReader sr;
        public static StreamWriter sw;
        
        List<string> ArticleHeaders = new List<string>();


        public ShowArticlesListView()
        {
            
            showListViewModel = (ShowArticlesListViewModel)((App)App.Current).GetViewModel("ShowArticlesListViewModel");
            showListGroupViewModel = (ShowListGroupViewModel)((App)App.Current).GetViewModel("ShowListGroupViewModel");
            postArticleViewModel = (PostArticleViewModel)((App)App.Current).GetViewModel("PostArticleViewModel");
            this.DataContext = showListViewModel;
            showListViewModel.ObsArticleCollection.Clear();
            InitializeComponent();
            ListOfGroups.ItemsSource = showListViewModel.ObsArticleCollection;
            
            GetListOfGroups();
            
            
        }



        public void GetListOfGroups()
        {
            LoginView.sw.WriteLine("list");
            int counter = 0;
            while (true)
            {
                string header = LoginView.sr.ReadLine().Trim();
                if(header == ".")
                {
                    break;
                }
                else
                {
                    if(counter != 0)
                    {
                        string Title = header.Substring(0, header.Length - 24);
                        string Indices = header.Substring(header.Length - 23);
                        string BeginIndex = Indices.Substring(0, 10);
                        string EndIndex = Indices.Substring(11);
                        EndIndex = EndIndex.Substring(0, 10);
                        ArticleTitles articleTitle = new ArticleTitles(Title, BeginIndex, EndIndex);
                        showListViewModel.AddEntryToList(articleTitle);
                        
                    }
                }
                counter++;
            }
            

        }

        private void ListOfGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            showListGroupViewModel.ObsArticleIndicesCollection.Clear(); 
            if(ListOfGroups.Items.Count == 0)
            {
                return;
            }
            
            ArticleTitles articleTitles = (ArticleTitles)ListOfGroups.SelectedItem;
            string Header = articleTitles.Header;
            Debug.WriteLine(Header);
            postArticleViewModel.SelectedNewsGroup = Header;
            int counter = 0;

            LoginView.sw.WriteLine("group {0}", Header);
            LoginView.sr.ReadLine();
            LoginView.sw.WriteLine("listgroup");

            while (true)
            {
                string ArticleIndex = LoginView.sr.ReadLine().Trim();
                if (ArticleIndex == ".")
                {
                    break;
                }
                else
                {
                    if (counter != 0)
                    {
                        showListGroupViewModel.AddEntryToList(new ArticleIndex(ArticleIndex));
                    }
                }
                counter++;
            }

        }

      
    }
}
