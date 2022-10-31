using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNTPProject.Model
{
    public class ArticleTitles : Bindable
    {
        private string header;
        private string startIndex;
        private string endIndex;    

        public ArticleTitles(string header, string startIndex, string endIndex)
        {
            this.header = header;
            this.startIndex = startIndex;
            this.endIndex = endIndex;
        }

        public string Header
        {
            get { return header; }
            set { header = value; propertyIsChanged(); }
        }

        public string StartIndex
        {
            get { return startIndex; }
            set { startIndex = value; propertyIsChanged(); }
        }
        
        public string EndIndex
        {
            get { return endIndex; }
            set { endIndex = value; propertyIsChanged(); }
        }

    }
}
