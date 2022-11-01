using NNTPProject.Model;
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

namespace NNTPProject.View
{
    /// <summary>
    /// Interaction logic for FavouriteGroupsView.xaml
    /// </summary>
    public partial class FavouriteGroupsView : UserControl
    {
        private FavouriteGroupsViewModel favouriteGroupsViewModel = null;
        private ShowListGroupViewModel showListGroupViewModel = null;
        DatabaseHandler databaseHandler;
        List<DBGroupEntry> AllGroups;
        List<DBGroupEntry> FavouriteGroups;
        DBGroupEntry SelectedFavouriteEntry;


        public FavouriteGroupsView()
        {
            favouriteGroupsViewModel = (FavouriteGroupsViewModel)((App)App.Current).GetViewModel("FavouriteGroupsViewModel");
            showListGroupViewModel = (ShowListGroupViewModel)((App)App.Current).GetViewModel("ShowListGroupViewModel");

            this.DataContext = favouriteGroupsViewModel;
            InitializeComponent();
            databaseHandler = new DatabaseHandler();
            AllGroups = databaseHandler.GetAllGroups();
            AllGroupsListView.ItemsSource = AllGroups;
            UpdateFavouriteGroupList();
        }

        public void UpdateFavouriteGroupList()
        {
            FavouriteGroups = databaseHandler.GetAllFavouriteGroups();
            FavouriteGroupsListView.ItemsSource = FavouriteGroups;
        }



        public List<ArticleTitles> GetListOfGroups()
        {
            List<ArticleTitles> AllGroupsList = new List<ArticleTitles>();
            LoginView.sw.WriteLine("list");
            int counter = 0;
            while (true)
            {
                string header = LoginView.sr.ReadLine().Trim();
                if (header == ".")
                {
                    break;
                }
                else
                {
                    if (counter != 0)
                    {
                        string Title = header.Substring(0, header.Length - 24);
                        string Indices = header.Substring(header.Length - 23);
                        string BeginIndex = Indices.Substring(0, 10);
                        string EndIndex = Indices.Substring(11);
                        EndIndex = EndIndex.Substring(0, 10);
                        ArticleTitles articleTitle = new ArticleTitles(Title, BeginIndex, EndIndex);
                        AllGroupsList.Add(articleTitle);
                    }
                }
                counter++;
            }
            return AllGroupsList;
        }

        private void RefreshAllGroupsButton_Click(object sender, RoutedEventArgs e)
        {
            List<ArticleTitles> AllGroupTitles = GetListOfGroups();
            databaseHandler.ReInsertAllGroups(AllGroupTitles);
            AllGroups = databaseHandler.GetAllGroups();
            AllGroupsListView.ItemsSource = AllGroups;
        }

        private void AllGroupsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DBGroupEntry SelectedRow = (DBGroupEntry)AllGroupsListView.SelectedItem;            
            databaseHandler.InsertNewFavouriteGroup(SelectedRow.ID);
            UpdateFavouriteGroupList();
        }

        private void SearchGroupsButton_Click(object sender, RoutedEventArgs e)
        {
            string PartOfName = GroupSearchField.Text;
            AllGroups = databaseHandler.GetSearchedGroups(PartOfName);            
            AllGroupsListView.ItemsSource = AllGroups;          
        }

        private void FavouriteGroupsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            showListGroupViewModel.ObsArticleIndicesCollection.Clear();
            SelectedFavouriteEntry = (DBGroupEntry)FavouriteGroupsListView.SelectedItem;
            if(SelectedFavouriteEntry == null)
            {
                return;
            }
            string Header = SelectedFavouriteEntry.Header;
            Debug.WriteLine(Header);

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

        private void DeleteFavouriteGroupButton_Click(object sender, RoutedEventArgs e)
        {
            //Using the Selected DB entry, delete it from DB
            if(SelectedFavouriteEntry == null)
            {
                return;
            }
            databaseHandler.DeleteFavouriteEntry(SelectedFavouriteEntry.ID);
            UpdateFavouriteGroupList();
        }
    }
}
