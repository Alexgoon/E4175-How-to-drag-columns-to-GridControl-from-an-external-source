using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpf.Grid.Native;
using DevExpress.Xpf.Grid;
using System.Windows;

namespace DragDropColumns
{
    class MyFitColumnHeaderDropTarget : FitColumnHeaderDropTarget
    {
        public MyFitColumnHeaderDropTarget(GridColumnHeaderBase columnHeader) : base(columnHeader) { }

        protected override void MoveColumnTo(UIElement source, int dropIndex)
        {
            GridColumnHeader gch = source as GridColumnHeader;
            GridView.MoveColumnTo((ColumnBase)gch.DataContext, dropIndex + DropIndexCorrection, BaseGridColumnHeader.GetHeaderPresenterTypeFromGridColumnHeader(source), BaseGridColumnHeader.GetHeaderPresenterTypeFromLocalValue(AdornableElement));
        }
    }
}
