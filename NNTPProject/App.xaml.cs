using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using NNTPProject.Model;
using NNTPProject.ViewModel;

namespace NNTPProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        List<KeyValuePair<string, Bindable>> listOfViewModels = new List<KeyValuePair<string, Bindable>>();

        public ContentControl ContentControlRef { get; set; } = null;

        public App()
        {
            //Create instances of the viewmodels, these should be kept alive during the lifetime of the application
            listOfViewModels.Add(new KeyValuePair<string, Bindable>("LoginViewModel", new LoginViewModel()));
            listOfViewModels.Add(new KeyValuePair<string, Bindable>("ShowListViewModel", new ShowListViewModel()));
        }

        public void ChangeUserControl(UserControl view)
        {
            this.ContentControlRef.Content = view;
        }

        public Bindable GetViewModel(String viewModelName)
        {
            Bindable foundViewModel = null;

            foreach (KeyValuePair<string, Bindable> kvp in listOfViewModels)
            {
                if (kvp.Key.Equals(viewModelName))
                {
                    foundViewModel = kvp.Value;
                }
            }
            if (foundViewModel == null)
                throw new Exception("ViewModel not found");

            return foundViewModel;
        }
    }
}
