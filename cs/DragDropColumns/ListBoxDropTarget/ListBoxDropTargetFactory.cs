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
using DevExpress.Xpf.Core;
using System.Windows;
using DevExpress.Xpf.Grid;
using System.Windows.Controls;

namespace DragDropColumns
{
    public class ListBoxDropTargetFactory : GridDropTargetFactoryBase
    {
        ListBox listBox;
        public ListBoxDropTargetFactory(ListBox listBox)
        {
            this.listBox = listBox;
        }
        protected sealed override IDropTarget CreateDropTarget(UIElement dropTargetElement)
        {
            return new ListBoxDropTarget(listBox);
        }
    }

}
