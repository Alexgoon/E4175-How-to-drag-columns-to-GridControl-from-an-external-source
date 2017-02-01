Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Core
Imports System.Windows
Imports System.Reflection

Namespace DragDropColumns
	Public Class MyColumnChooserDropTarget
		Inherits ColumnChooserDropTarget
		Implements IDropTarget
        Public Shadows Sub Drop(ByVal source As UIElement, ByVal pt As Point) Implements IDropTarget.Drop
            Dim columnHeader As GridColumnHeader = TryCast(source, GridColumnHeader)
            Dim column As GridColumn = TryCast(columnHeader.DataContext, GridColumn)
            Dim view As TableView = TryCast(column.View, TableView)
            If (Not view.Grid.Columns.Contains(column)) Then
                Return
            End If

            Dim method As MethodInfo = GetType(ColumnChooserDropTarget).GetMethod("DropColumn", BindingFlags.Instance Or BindingFlags.NonPublic)
            method.Invoke(Me, New Object() {source})
        End Sub
	End Class
End Namespace
