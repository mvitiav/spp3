   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	       WpfApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #VMclr-namespace:WpfApp     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � DataContext 5	         WpfApp.HierarchyItem  5
   
   .��5      � .+�5   
   �� -   5         ��Name$ 
openButton��5      $��Open assembly��6%   $
��Left=�6=   $��	10,10,0,0q�6X   $	��Top=�6k   ��6�   �� *GetPathAndExecuteCommand+R� 5   
   -   5         R�Name$ treeView��5      $��0,35,0,0q�6%   ��67   �� *
Namespaces+��5      �� 5       �� DataType   WpfApp.NameSpaceNode"  6g    �� ItemsSource 6+   �� *Types+ �� NotifyOnTargetUpdated$
 True��.R�5      �� ��6   �� *	Namespase+ �� ItemTemplate 5      �� 5         WpfApp.TypeNode"  6p    63   �� *Fields+$
 True��.R�5      �� ��6$   �� *Field+ 5      �� 5   "      WpfApp.FieldNode"  6/   .R�5   &   �� ��6,   �� *	Fieldname+5   #   5      5!      5$      5&      5'      