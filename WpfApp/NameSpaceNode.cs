using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp
{
    public class NameSpaceNode:MVVMBase
    {
        private List<TypeNode> typez;
        public NameSpaceNode(string namespaze)
        {
            Namespase = namespaze;
            typez = new List<TypeNode>()
            {
              //  new TypeNode("type1"),            
            }
            ;
        }

        public List<TypeNode> Types
        {
            get
            {
                return typez;
            }
            set
            {
                typez = value;
                OnPropertyChanged("Types");
            }
        }
        private string namespaceName;
        public string Namespase
        {
            get
            {
                return namespaceName+"("+typez.Count+")";
            }
            set
            {
                namespaceName = value;
                OnPropertyChanged("Namespase");
            }
        }
    }
}
