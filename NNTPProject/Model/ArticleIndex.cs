using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNTPProject.Model
{
    public class ArticleIndex: Bindable
    {
        public string index;
        public ArticleIndex(string index)
        {
            this.index = index;
        }

        public string Index
        {
            get { return index; }
            set { index = value; propertyIsChanged(); }
        }
    }
}
