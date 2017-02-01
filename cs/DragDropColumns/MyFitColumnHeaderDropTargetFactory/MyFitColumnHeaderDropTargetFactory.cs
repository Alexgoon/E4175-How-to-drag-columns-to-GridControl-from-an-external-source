using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Core;
using System.Windows;

namespace DragDropColumns
{
    class MyFitColumnHeaderDropTargetFactory : GridDropTargetFactoryBase
    {
        protected override IDropTarget CreateDropTarget(UIElement dropTargetElement)
        {
            return new MyFitColumnHeaderDropTarget(dropTargetElement as GridColumnHeaderBase);
        }
    }
}
