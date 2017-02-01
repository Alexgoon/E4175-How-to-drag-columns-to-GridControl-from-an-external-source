Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.Xpf.Grid.Native
Imports DevExpress.Xpf.Grid
Imports System.Windows

Namespace DragDropColumns
	Friend Class MyFitColumnHeaderDropTarget
		Inherits FitColumnHeaderDropTarget
		Public Sub New(ByVal columnHeader As GridColumnHeaderBase)
			MyBase.New(columnHeader)
		End Sub

		Protected Overrides Sub MoveColumnTo(ByVal source As UIElement, ByVal dropIndex As Integer)
			Dim gch As GridColumnHeader = TryCast(source, GridColumnHeader)
			GridView.MoveColumnTo(CType(gch.DataContext, ColumnBase), dropIndex + DropIndexCorrection, BaseGridColumnHeader.GetHeaderPresenterTypeFromGridColumnHeader(source), BaseGridColumnHeader.GetHeaderPresenterTypeFromLocalValue(AdornableElement))
		End Sub
	End Class
End Namespace
