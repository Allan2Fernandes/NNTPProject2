using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NNTPProject.Model;

namespace NNTPProject.ViewModel
{
    public class ShowListViewModel:Bindable
    {
        private string id = "ShowList";

        public string ID
        {
            get { return id; }
            set { id = value; this.propertyIsChanged(); }
        }

        public ShowListViewModel()
        {

        }
    }
}
