using NNTPProject.Model;
using NNTPProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
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

namespace NNTPProject.View
{
    /// <summary>
    /// Interaction logic for ShowListGroupView.xaml
    /// </summary>
    public partial class ShowListGroupView : UserControl
    {
        private ShowListGroupViewModel showListGroupViewModel;
        public ShowListGroupView()
        {
            showListGroupViewModel = (ShowListGroupViewModel)((App)App.Current).GetViewModel("ShowListGroupViewModel");
            this.DataContext = showListGroupViewModel;
            InitializeComponent();
            ListViewIndices.ItemsSource = showListGroupViewModel.ObsArticleIndicesCollection;
        }

        private void ListViewIndices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ArticleIndex SelectedArticleIndex = (ArticleIndex)ListViewIndices.SelectedItem;
            string SelectedIndex = SelectedArticleIndex.Index;
            Debug.WriteLine(SelectedIndex);
            int counter = 0;
            LoginView.sw.WriteLine("article {0}", SelectedIndex);
            string ArticleBody = "";

            while (true)
            {
                string line = LoginView.sr.ReadLine().Trim();
                if (line == ".")
                {
                    break;
                }
                else
                {
                    if (counter != 0)
                    {
                        ArticleBody = ArticleBody + line + "\n";
                    }
                }
                counter++;
            }
            ArticleBodyTextBox.Text = ArticleBody;
        }
    }
}
