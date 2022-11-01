using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNTPProject.Model
{
    public class DBGroupEntry:Bindable
    {
        private int iD;
        private string header;
        private string startIndex;
        private string endIndex;

        public DBGroupEntry(int iD, string header, string startIndex, string endIndex)
        {
            this.iD = iD;
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

        public int ID
        {
            get { return iD; }
            set { iD = value; propertyIsChanged(); }
        }
    }
}
