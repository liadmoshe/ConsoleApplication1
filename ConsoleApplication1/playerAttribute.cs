using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    [System.AttributeUsage(AttributeTargets.Class)]
    class playerAttribute : Attribute
    {
        Type _interfaceType;

        public Type InterfaceType
        {
            get { return _interfaceType; }

        }
        public playerAttribute(Type interfaceType)
        {
            _interfaceType = interfaceType;
        }

    }
}
