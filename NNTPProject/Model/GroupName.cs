using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNTPProject.Model
{
    public class GroupName: Bindable
    {
        public string name;
        public GroupName(string name)
        {
            this.name = name;
        }

        public string Index
        {
            get { return name; }
            set { name = value; propertyIsChanged(); }
        }
    }
}
