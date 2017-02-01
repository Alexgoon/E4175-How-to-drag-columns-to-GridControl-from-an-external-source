using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpf.Grid.Native;
using DevExpress.Xpf.Grid;

namespace DragDropColumns
{
    class MyRemoveColumnDropTarget : RemoveColumnDropTarget
    {
        public override void Drop(System.Windows.UIElement source, System.Windows.Point pt)
        {
            GridColumnHeader columnHeader = source as GridColumnHeader;
            GridColumn column = columnHeader.DataContext as GridColumn;
            TableView view = column.View as TableView;
            if (!view.Grid.Columns.Contains(column))
                return;
            base.Drop(source, pt);
        }
    }
}
