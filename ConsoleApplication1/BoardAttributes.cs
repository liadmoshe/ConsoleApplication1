using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    [System.AttributeUsage(AttributeTargets.Class)]
    class BoardAttributes : Attribute
    {
        string _uiOption;

        public string UIOption
        {
            get { return _uiOption; }

        }
        public BoardAttributes(string uiOption)
        {
            _uiOption = uiOption;
        }

    }
}
