' Developer Express Code Central Example:
' How to drag columns to GridControl from an external source
' 
' To drag columns from an external source (e.g., ListBox) it is required to
' determine the behavior of the TableView when columns are dropped onto it. To do
' this, you need to override the MoveColumnToCore method in a TableView
' descendant. To allow dropping columns back to ListBox it needs an attached
' property 'DragManager.DropTargetFactoryProperty' to be set. For this purpose,
' ListBoxDropTargetFactory class has been created. In TableView, columns are
' dropped onto a StackVisibleIndexPanel so as to implement the required
' functionality it's necessary to attach the
' 'DragManager.DropTargetFactoryProperty' to it as well.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E4175


Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.Xpf.Core
Imports System.Windows
Imports DevExpress.Xpf.Grid
Imports System.Windows.Controls
Imports System.Collections.ObjectModel
Imports System.Reflection


Namespace DragDropColumns
	Friend Class ListBoxDropTarget
		Implements IDropTarget
		Private listBox As ListBox
		Public Sub New(ByVal listBox As ListBox)
			Me.listBox = listBox
		End Sub
        Public Sub Drop(ByVal source As UIElement, ByVal pt As Point) Implements IDropTarget.Drop
            Dim header As BaseGridColumnHeader = CType(source, BaseGridColumnHeader)
            Dim column As GridColumn = CType(header.DataContext, GridColumn)
            If column Is Nothing Then
                Return
            End If
            Dim view As TableView = TryCast(column.View, TableView)
            Dim grid As GridControl = view.Grid
            Dim oc As GridColumnCollection = TryCast(listBox.ItemsSource, GridColumnCollection)
            If (Not oc.Contains(column)) Then
                oc.Add(column)
                grid.Columns.Remove(column)

                Dim eFlags As BindingFlags = BindingFlags.Instance Or BindingFlags.NonPublic
                Dim pi As PropertyInfo

                pi = GetType(GridColumn).GetProperty("ParentCollection", eFlags)
                pi.SetValue(column, oc, Nothing)

            End If
        End Sub

        Public Sub OnDragLeave() Implements IDropTarget.OnDragLeave

        End Sub
        Public Sub OnDragOver(ByVal source As UIElement, ByVal pt As Point) Implements IDropTarget.OnDragOver

        End Sub

	End Class
End Namespace
