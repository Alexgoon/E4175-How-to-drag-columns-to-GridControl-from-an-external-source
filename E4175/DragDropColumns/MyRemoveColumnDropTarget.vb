Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.Xpf.Grid.Native
Imports DevExpress.Xpf.Grid

Namespace DragDropColumns
	Friend Class MyRemoveColumnDropTarget
		Inherits RemoveColumnDropTarget
		Public Overrides Sub Drop(ByVal source As System.Windows.UIElement, ByVal pt As System.Windows.Point)
			Dim columnHeader As GridColumnHeader = TryCast(source, GridColumnHeader)
			Dim column As GridColumn = TryCast(columnHeader.DataContext, GridColumn)
			Dim view As TableView = TryCast(column.View, TableView)
			If (Not view.Grid.Columns.Contains(column)) Then
				Return
			End If
			MyBase.Drop(source, pt)
		End Sub
	End Class
End Namespace
