﻿using NNTPProject.Model;
using NNTPProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        
        public static StreamReader sr;
        public static StreamWriter sw;
        
        List<string> ArticleHeaders = new List<string>();


        public ShowArticlesListView()
        {
            showListViewModel = (ShowArticlesListViewModel)((App)App.Current).GetViewModel("ShowArticlesListViewModel");
            this.DataContext = showListViewModel;
            InitializeComponent();
            ListOfGroups.ItemsSource = showListViewModel.ObsArticleCollection;


        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Authenticate();
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
                        ArticleTitle articleTitle = new ArticleTitle(Title, BeginIndex, EndIndex);
                        showListViewModel.AddEntryToList(articleTitle);
                        //Debug.WriteLine("StartIndex: {0} || EndIndex: {1}", articleTitle.StartIndex, articleTitle.EndIndex);
                    }
                }
                counter++;
            }
            Debug.WriteLine(ListOfGroups.Items.Count);

        }

    }
}
