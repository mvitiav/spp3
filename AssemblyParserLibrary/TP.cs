using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AssemblyParserLibrary
{
    public class TP
    {
        public Type type;
        //Dictionary<FieldInfo, FL> fields;
        //Dictionary<PropertyInfo, PR> props;
        // Dictionary<MethodInfo, MT> methods;

        public List<MT> methods;
        public List<FL> fields;
        public List<PR> props;
        public TP()
        {          
            methods = new List<MT>();
            fields = new List<FL>();
            props = new List<PR>();
        }

        public void setType(Type type) { this.type = type; }
        public void addMT(MethodInfo mi) { methods.Add(new MT(mi)); }
        public void addFL(FieldInfo fi) { fields.Add(new FL(fi)); }
        public void addPR(PropertyInfo pi) { props.Add(new PR(pi)); }

            public TP(Type type)
        {
            this.type = type;
            methods = new List<MT>();
            fields = new List<FL>();
            props = new List<PR>();
            foreach (MethodInfo mi in type.GetMethods()) {
                methods.Add(new MT(mi));
            }
            foreach (PropertyInfo pi in type.GetProperties())
            {
                props.Add(new PR(pi));
            }
            foreach (FieldInfo fi in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                fields.Add(new FL(fi));
            }
        }


    }



}
