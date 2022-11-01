using NNTPProject.Model;
using NNTPProject.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NNTPProject.ViewModel
{
    public class PostArticleViewModel: Bindable
    {
        private string id = "PostArticle";
        private string selectedNewsGroup;

        public string ID
        {
            get { return id; }
            set { id = value; this.propertyIsChanged(); }
        }

        public string SelectedNewsGroup
        {
            get { return selectedNewsGroup; }
            set { selectedNewsGroup = value; propertyIsChanged(); }
        }
        
        public PostArticleViewModel()
        {

        }

        public ICommand ChangePageCMD { get; set; } = new DelegateCommand(() => { ((App)System.Windows.Application.Current).ChangeUserControl(new ShowArticlesListView()); });
    }
}
