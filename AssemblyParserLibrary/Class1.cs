using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AssemblyParserLibrary
{
    public class Library
    {
        private string path;

        Dictionary<string, NS> namespaces;
        Assembly asm;
        public Library(string path)
        {
            this.path = path;
            asm = Assembly.LoadFrom(path);
            namespaces = new Dictionary<string, NS>();
            
            processAsm();
        }

        public List<int> checkIfHasExtensions(TypeInfo ti) {
            List<int> temp = new List<int>();
            int count = 0;
            foreach (MethodInfo mi in ti.GetMethods()) {
                
                if (mi.IsDefined(typeof(ExtensionAttribute), true)) { temp.Add(count); }
                count++;
            }
            return temp;
        }
        public void processAsm() {

            foreach (TypeInfo ti in asm.GetTypes())
            {
                List<int> temp2 = checkIfHasExtensions(ti);

                ////todo check 
                MethodInfo[] mis = ti.GetMethods();
                foreach (int metodIndex in temp2)
                {
                    Type newType = mis[metodIndex].GetParameters()[0].ParameterType;
                    if (!namespaces.ContainsKey(newType.Namespace)) { namespaces[newType.Namespace] = new NS(newType.Namespace); }
                    namespaces[newType.Namespace].addMethod(newType, mis[metodIndex]);
                }

                ////todo check
                if (!namespaces.ContainsKey(ti.Namespace)) { namespaces[ti.Namespace] = new NS(ti.Namespace); }
                namespaces[ti.Namespace].addEverythingWithoutMethods(ti, temp2);
         
            }

        }

        public Type[] getTypes() {
            return asm.GetTypes();
        }

        public List<NS> getNsList()
        {         
            return namespaces.Values.ToList();
        }

    }
}
