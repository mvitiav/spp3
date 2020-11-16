using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AssemblyParserLibrary
{
    public class MT
    {
        MethodInfo mi;

        public MT(MethodInfo mi)
        {
            this.mi = mi;
        }


        public override string ToString()
        {
            string ret= "[m]" + mi.ReturnType + " " + mi.Name +'(';
            foreach (ParameterInfo pi in mi.GetParameters()) {
                ret += pi.ParameterType.Name+' '+pi.Name + ' ';
            }
            ret += ')';
            return ret;
        }
    }


}
