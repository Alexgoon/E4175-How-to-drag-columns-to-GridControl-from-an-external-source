using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Core;
using System.Windows;
using System.Reflection;

namespace DragDropColumns
{
    public class MyColumnChooserDropTarget : ColumnChooserDropTarget, IDropTarget
    {
        public new void Drop(UIElement source, Point pt)
        {
            GridColumnHeader columnHeader = source as GridColumnHeader;
            GridColumn column = columnHeader.DataContext as GridColumn;
            TableView view = column.View as TableView;
            if (!view.Grid.Columns.Contains(column))
                return;

            MethodInfo method = typeof(ColumnChooserDropTarget).GetMethod("DropColumn", BindingFlags.Instance | BindingFlags.NonPublic);
            method.Invoke(this, new object[] { source });
        }
    }
}
