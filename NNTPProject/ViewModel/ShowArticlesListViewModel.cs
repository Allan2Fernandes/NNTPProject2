using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NNTPProject.Model;

namespace NNTPProject.ViewModel
{
    public class ShowArticlesListViewModel:Bindable
    {
        private string id = "ShowList";
        public ObservableCollection<ArticleTitle> ObsArticleCollection;

        public string ID
        {
            get { return id; }
            set { id = value; this.propertyIsChanged(); }
        }

        public ShowArticlesListViewModel()
        {
            ObsArticleCollection = new ObservableCollection<ArticleTitle>();
        }

        public void AddEntryToList(ArticleTitle articleTitle)
        {
            ObsArticleCollection.Add(articleTitle);
        }
    }
}
