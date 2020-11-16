using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp
{
    public class TypeNode : MVVMBase
    {
        private List<FieldNode> fieldz;
        public TypeNode(string field)
        {
            Field = field;
            fieldz = new List<FieldNode>()
            {
               // new FieldNode("field1"),
            }
            ;
        }

        public List<FieldNode> Fields
        {
            get
            {
                return fieldz;
            }
            set
            {
                fieldz = value;
                OnPropertyChanged("Fields");
            }
        }

        public string Field
        {
            get;
            set;
        }
    }
}
