Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Core
Imports System.Windows

Namespace DragDropColumns
	Friend Class MyFitColumnHeaderDropTargetFactory
		Inherits GridDropTargetFactoryBase
		Protected Overrides Function CreateDropTarget(ByVal dropTargetElement As UIElement) As IDropTarget
			Return New MyFitColumnHeaderDropTarget(TryCast(dropTargetElement, GridColumnHeaderBase))
		End Function
	End Class
End Namespace
