// Developer Express Code Central Example:
// How to drag columns to GridControl from an external source
// 
// To drag columns from an external source (e.g., ListBox) it is required to
// determine the behavior of the TableView when columns are dropped onto it. To do
// this, you need to override the MoveColumnToCore method in a TableView
// descendant. To allow dropping columns back to ListBox it needs an attached
// property 'DragManager.DropTargetFactoryProperty' to be set. For this purpose,
// ListBoxDropTargetFactory class has been created. In TableView, columns are
// dropped onto a StackVisibleIndexPanel so as to implement the required
// functionality it's necessary to attach the
// 'DragManager.DropTargetFactoryProperty' to it as well.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4175

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using DevExpress.Xpf.Grid;
using System.Collections.ObjectModel;
using DevExpress.Xpf.Core;

namespace DragDropColumns
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();

            GridColumnCollection columns = new GridColumnCollection(gridControl1);
            listBox1.SetValue(DragManager.DropTargetFactoryProperty, new ListBoxDropTargetFactory());
            listBox1.SetValue(GridControl.CurrentViewProperty, tableView1);
  
            for (int i = 0; i < 5; i++)
            {
                columns.Add(new GridColumn() { FieldName = "Column" + (i + 1).ToString() });
            }
            listBox1.ItemsSource = columns;

            ObservableCollection<Customer> cusromers = new ObservableCollection<Customer>();
            cusromers.Add(new Customer() { ID = 1, Name = "Name1" });
            cusromers.Add(new Customer() { ID = 2, Name = "Name2" });
            gridControl1.ItemsSource = cusromers;
        }
    }


    public class Customer
    {
        public int ID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
    }
}
