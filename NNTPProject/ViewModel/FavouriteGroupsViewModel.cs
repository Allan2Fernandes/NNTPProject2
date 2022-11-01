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
    public class FavouriteGroupsViewModel: Bindable
    {
        private string id = "FavouriteGroups";

        public string ID
        {
            get { return id; }
            set { id = value; this.propertyIsChanged(); }
        }

        public ICommand ChangeArticlesListPageCMD { get; set; } = new DelegateCommand(() => { ((App)System.Windows.Application.Current).ChangeUserControl(new ShowArticlesListView()); });

        public ICommand ChangeListGroupPageCMD { get; set; } = new DelegateCommand(() => { ((App)System.Windows.Application.Current).ChangeUserControl(new ShowListGroupView()); });


    }
}
