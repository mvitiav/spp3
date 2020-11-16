using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AssemblyParserLibrary
{
   public class NS
    {
       public string name;
        public Dictionary<Type, TP> types;

        public NS(string name)
        {
            this.name = name;
            types = new Dictionary<Type, TP>();
        }

        public void addType(Type ti) {
            types[ti] = new TP(ti);
        }

        public void addEverythingWithoutMethods(Type ti,List<int> indexes)
        {
            if (!types.ContainsKey(ti)) types[ti] = new TP();
            types[ti].setType(ti);
            //types[ti] = new TP(ti);
            int count = 0;
            foreach (MethodInfo mi in ti.GetMethods())
            {
              if(!indexes.Contains(count))
                types[ti].addMT(mi);
                count++;
            }
            foreach (PropertyInfo pi in ti.GetProperties())
            {
                types[ti].addPR(pi);
            }
            foreach (FieldInfo fi in ti.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                types[ti].addFL(fi);
            }

        }

        public void addMethod(Type ti,MethodInfo mi)
        {
            if (!types.ContainsKey(ti)) types[ti] = new TP();
            types[ti].setType(ti);
            types[ti].addMT(mi);
        }


        public List<TP> getTypesList() {
            return types.Values.ToList();
        }
    }
}
