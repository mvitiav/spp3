using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AssemblyParserLibrary
{
    public class PR
    {
        PropertyInfo pi;

        public PR(PropertyInfo pi)
        {
            this.pi = pi;
        }

        public override string ToString()
        {
            return "[p]"+pi.PropertyType + " " + pi.Name;
        }

    }


}
