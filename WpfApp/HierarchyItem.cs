using AssemblyParserLibrary;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace WpfApp
{
    public class HierarchyItem : MVVMBase
    {
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        
        private Library library;
        //private string path = "G:\\SPP\\3\\consoleTest\\bin\\Debug\\netcoreapp3.1\\consoleTest.dll";
        private string path;
//todo - delete hardcoded
        public String Path {
            get
            {
                openFileDialog.Reset();
                openFileDialog.Filter = "dll files (*.dll)|*.dll";

                if (openFileDialog.ShowDialog() == true)
                {
                    path = openFileDialog.FileName;
                }
                else
                {

                    path = null;
                }

                return path;
            }
            set
            {
                path = value;
                OnPropertyChanged("Namespaces");
            }
        }

        private RCommand parseCommand;
        public RCommand ParseCommand {
            get
            {
                return parseCommand ??
                  (parseCommand = new RCommand(obj =>
                  {
                      if (path != null)
                      {

                      
                          Namespaces.Clear();                     
                         path = obj as string;
                      library = new Library(path);
                      foreach (NS ns in library.getNsList())
                      {
                          NameSpaceNode tempNS = new NameSpaceNode(ns.name);
                          foreach (TP tp in ns.getTypesList())
                          {
                              TypeNode tempType = new TypeNode(tp.type.ToString());
                              foreach (FL fl in tp.fields)
                              {
                                  tempType.Fields.Add(new FieldNode(fl.ToString()));
                              }
                              foreach (PR pr in tp.props)
                              {
                                  tempType.Fields.Add(new FieldNode(pr.ToString()));
                              }
                              foreach (MT mt in tp.methods)
                              {
                                  tempType.Fields.Add(new FieldNode(mt.ToString()));
                              }
                              tempNS.Types.Add(tempType);
                          }
                          Namespaces.Add(tempNS);
                      }
                  }
                  }));
            }
        }

        private RCommand getPathAndExecuteCommand;
        public RCommand GetPathAndExecuteCommand
        {
            get { 
            
            return getPathAndExecuteCommand?? (getPathAndExecuteCommand=new RCommand(obj=>{

                
                ParseCommand.Execute(Path);


            }));
            }
        }

        private ObservableCollection<NameSpaceNode> namespaces;

        
        public HierarchyItem()
        {
            Namespaces = new ObservableCollection<NameSpaceNode>();
            
        }
        public ObservableCollection<NameSpaceNode> Namespaces
        {
            get
            {

                return namespaces;
            }
            set
            {
                namespaces = value;
                OnPropertyChanged("Namespaces");
            }
        }
    }
}
