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
using DevExpress.Xpf.Grid;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using DevExpress.Xpf.Core.Native;
using System.Windows;

namespace DragDropColumns
{
    class MyTableView : TableView
    {
        public ListBox ExternalColumnList;
        protected override void MoveColumnToCore(ColumnBase source, int newVisibleIndex, HeaderPresenterType moveFrom, HeaderPresenterType moveTo)
        {
            if (Columns.Contains(source))
                base.MoveColumnToCore(source, newVisibleIndex, moveFrom, moveTo);

            else
            {
                GridColumnCollection oc = ExternalColumnList.ItemsSource as GridColumnCollection;
                oc.Remove((GridColumn)source);
                Columns.Add((GridColumn)source);
                Dispatcher.BeginInvoke(new Action(() => {
                    ((GridColumn)source).VisibleIndex = newVisibleIndex;
                }));
            }
        }
    }
}
