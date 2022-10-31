using NNTPProject.Model;
using NNTPProject.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NNTPProject.ViewModel
{
    public class ShowListGroupViewModel:Bindable
    {
        private string id = "ShowListGroup";
        public ObservableCollection<ArticleIndex> ObsArticleIndicesCollection;

        public ShowListGroupViewModel()
        {
            ObsArticleIndicesCollection = new ObservableCollection<ArticleIndex>();
        }

        public string ID
        {
            get { return id; }
            set { id = value; this.propertyIsChanged(); }
        }

        public void AddEntryToList(ArticleIndex Index)
        {
            ObsArticleIndicesCollection.Add(Index);
        }

        public ICommand ChangePageCMD { get; set; } = new DelegateCommand(() => { ((App)System.Windows.Application.Current).ChangeUserControl(new ShowArticlesListView()); });
    }
}
