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
    public class LoginViewModel: Bindable
    {
        private string id = "Login";

        public string ID
        {
            get { return id; }
            set { id = value; this.propertyIsChanged(); }
        }

        public LoginViewModel()
        {
            //Commands here
        }

        //Use this command to change page
        public ICommand ChangePageCMD { get; set; } = new DelegateCommand(() => { ((App)System.Windows.Application.Current).ChangeUserControl(new ShowListView()); });

    }
}
