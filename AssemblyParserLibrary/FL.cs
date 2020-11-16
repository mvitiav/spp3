using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AssemblyParserLibrary
{
    public class FL
    {     
        FieldInfo fi;

        public FL( FieldInfo fi)
        {     
            this.fi = fi;
        }

        public override string ToString()
        {
            return "[f]" + fi.FieldType + " " + fi.Name;
        }
    }



}
