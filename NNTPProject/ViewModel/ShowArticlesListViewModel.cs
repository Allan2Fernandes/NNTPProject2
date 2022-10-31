using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NNTPProject.Model;
using NNTPProject.View;

namespace NNTPProject.ViewModel
{
    public class ShowArticlesListViewModel:Bindable
    {
        private string id = "ShowArticlesList";
        public ObservableCollection<ArticleTitles> ObsArticleCollection;

        public string ID
        {
            get { return id; }
            set { id = value; this.propertyIsChanged(); }
        }

        public ShowArticlesListViewModel()
        {
            ObsArticleCollection = new ObservableCollection<ArticleTitles>();
        }

        public void AddEntryToList(ArticleTitles articleTitle)
        {
            ObsArticleCollection.Add(articleTitle);
        }

        public ICommand ChangePageCMD { get; set; } = new DelegateCommand(() => { ((App)System.Windows.Application.Current).ChangeUserControl(new ShowListGroupView()); });
    }
}
