Imports Microsoft.VisualBasic
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Grid.Native
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls

Namespace DragDropColumns

	Public Class MyFixedNoneDropTarget
		Inherits FixedNoneDropTarget
		Public Sub New(ByVal panel As Panel)
			MyBase.New(panel)
		End Sub

		Protected Overrides Sub MoveColumnTo(ByVal source As System.Windows.UIElement, ByVal dropIndex As Integer)
			Dim gch As GridColumnHeader = TryCast(source, GridColumnHeader)
			If String.Equals(gch.Tag, "external") Then
				CType(GridView, MyTableView).InsertCustomColumn(CType(gch.DataContext, GridColumn), dropIndex + DropIndexCorrection)
			Else
				MyBase.MoveColumnTo(source, dropIndex)
			End If

		End Sub
	End Class

	Public Class MyFixedNoneColumnHeaderDropTargetFactory
		Inherits FixedNoneColumnHeaderDropTargetFactory
		Protected Overrides Function CreateDropTargetCore(ByVal panel As System.Windows.Controls.Panel) As DevExpress.Xpf.Core.IDropTarget
			Return New MyFixedNoneDropTarget(panel)
		End Function
	End Class


	Public Class MyFitColumnHeaderDropTarget
		Inherits FitColumnHeaderDropTarget
		Public Sub New(ByVal columnHeader As GridColumnHeaderBase)
			MyBase.New(columnHeader)
		End Sub

		Protected Overrides Sub MoveColumnTo(ByVal source As UIElement, ByVal dropIndex As Integer)
			Dim gch As GridColumnHeader = TryCast(source, GridColumnHeader)
			If String.Equals(gch.Tag, "external") Then
				CType(GridView, MyTableView).InsertCustomColumn(CType(gch.DataContext, GridColumn), dropIndex + DropIndexCorrection)
			Else
				MyBase.MoveColumnTo(source, dropIndex)
			End If
		End Sub
	End Class


	Public Class MyFitColumnHeaderDropTargetFactory
		Inherits GridDropTargetFactoryBase
		Protected Overrides Function CreateDropTarget(ByVal dropTargetElement As UIElement) As IDropTarget
			Return New MyFitColumnHeaderDropTarget(TryCast(dropTargetElement, GridColumnHeaderBase))
		End Function
	End Class


	Public Class MyIndicatorColumnHeaderDropTarget
		Inherits IndicatorColumnHeaderDropTarget
		Public Sub New(ByVal columnHeader As GridColumnHeaderBase)
			MyBase.New(columnHeader)
		End Sub

		Protected Overrides Sub MoveColumnTo(ByVal source As UIElement, ByVal dropIndex As Integer)
			Dim gch As GridColumnHeader = TryCast(source, GridColumnHeader)
			If String.Equals(gch.Tag, "external") Then
				CType(GridView, MyTableView).InsertCustomColumn(CType(gch.DataContext, GridColumn), dropIndex + DropIndexCorrection)
			Else
				MyBase.MoveColumnTo(source, dropIndex)
			End If
		End Sub
	End Class


	Public Class MyIndicatorColumnHeaderDropTargetFactory
		Inherits GridDropTargetFactoryBase
		Protected Overrides Function CreateDropTarget(ByVal dropTargetElement As UIElement) As IDropTarget
			Return New MyIndicatorColumnHeaderDropTarget(TryCast(dropTargetElement, GridColumnHeaderBase))
		End Function
	End Class

	Public Class ListBoxDropTarget
		Implements IDropTarget
		Public Sub New()
		End Sub
        Public Sub Drop(ByVal source As UIElement, ByVal pt As Point) Implements IDropTarget.Drop
        End Sub

        Public Sub OnDragLeave() Implements IDropTarget.OnDragLeave
        End Sub
        Public Sub OnDragOver(ByVal source As UIElement, ByVal pt As Point) Implements IDropTarget.OnDragOver
        End Sub

	End Class

	Public Class ListBoxDropTargetFactory
		Inherits GridDropTargetFactoryBase
		Protected NotOverridable Overrides Function CreateDropTarget(ByVal dropTargetElement As UIElement) As IDropTarget
			Return New ListBoxDropTarget()
		End Function
	End Class
End Namespace
