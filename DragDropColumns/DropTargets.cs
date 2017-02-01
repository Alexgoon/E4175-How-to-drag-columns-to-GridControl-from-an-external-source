using DevExpress.Xpf.Core;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Grid.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace DragDropColumns
{

    public class MyFixedNoneDropTarget : FixedNoneDropTarget
    {
        public MyFixedNoneDropTarget(Panel panel)
            : base(panel)
        {
        }

        protected override void MoveColumnTo(System.Windows.UIElement source, int dropIndex)
        {
            GridColumnHeader gch = source as GridColumnHeader;
            if (string.Equals(gch.Tag, "external"))
                ((MyTableView)GridView).InsertCustomColumn((GridColumn)gch.DataContext, dropIndex + DropIndexCorrection);
            else
                base.MoveColumnTo(source, dropIndex);

        }
    }

    public class MyFixedNoneColumnHeaderDropTargetFactory : FixedNoneColumnHeaderDropTargetFactory
    {
        protected override DevExpress.Xpf.Core.IDropTarget CreateDropTargetCore(System.Windows.Controls.Panel panel)
        {
            return new MyFixedNoneDropTarget(panel);
        }
    }


    public class MyFitColumnHeaderDropTarget : FitColumnHeaderDropTarget
    {
        public MyFitColumnHeaderDropTarget(GridColumnHeaderBase columnHeader) : base(columnHeader) { }

        protected override void MoveColumnTo(UIElement source, int dropIndex)
        {
            GridColumnHeader gch = source as GridColumnHeader;
            if (string.Equals(gch.Tag, "external"))
                ((MyTableView)GridView).InsertCustomColumn((GridColumn)gch.DataContext, dropIndex + DropIndexCorrection);
            else
                base.MoveColumnTo(source, dropIndex);
        }
    }


    public class MyFitColumnHeaderDropTargetFactory : GridDropTargetFactoryBase
    {
        protected override IDropTarget CreateDropTarget(UIElement dropTargetElement)
        {
            return new MyFitColumnHeaderDropTarget(dropTargetElement as GridColumnHeaderBase);
        }
    }


    public class MyIndicatorColumnHeaderDropTarget : IndicatorColumnHeaderDropTarget
    {
        public MyIndicatorColumnHeaderDropTarget(GridColumnHeaderBase columnHeader) : base(columnHeader) { }

        protected override void MoveColumnTo(UIElement source, int dropIndex)
        {
            GridColumnHeader gch = source as GridColumnHeader;
            if (string.Equals(gch.Tag, "external"))
                ((MyTableView)GridView).InsertCustomColumn((GridColumn)gch.DataContext, dropIndex + DropIndexCorrection);
            else
                base.MoveColumnTo(source, dropIndex);
        }
    }


    public class MyIndicatorColumnHeaderDropTargetFactory : GridDropTargetFactoryBase
    {
        protected override IDropTarget CreateDropTarget(UIElement dropTargetElement)
        {
            return new MyIndicatorColumnHeaderDropTarget(dropTargetElement as GridColumnHeaderBase);
        }
    }

    public class ListBoxDropTarget : IDropTarget
    {
        public ListBoxDropTarget()
        {
        }
        public void Drop(UIElement source, Point pt) { }

        public void OnDragLeave() { }
        public void OnDragOver(UIElement source, Point pt) { }

    }

    public class ListBoxDropTargetFactory : GridDropTargetFactoryBase
    {
        protected sealed override IDropTarget CreateDropTarget(UIElement dropTargetElement)
        {
            return new ListBoxDropTarget();
        }
    }
}
