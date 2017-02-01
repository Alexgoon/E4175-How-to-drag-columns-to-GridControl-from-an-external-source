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
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Data
Imports DevExpress.Xpf.Grid
Imports System.Collections.ObjectModel
Imports DevExpress.Xpf.Core

Namespace DragDropColumns
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Private columns As GridColumnCollection

		Public Sub New()
			InitializeComponent()

			columns = New GridColumnCollection(gridControl1)
			listBox1.SetValue(DragManager.DropTargetFactoryProperty, New ListBoxDropTargetFactory(listBox1))
			listBox1.SetValue(GridControl.CurrentViewProperty, tableView1)
			tableView1.ExternalColumnList = listBox1

			For i As Integer = 0 To 4
				columns.Add(New GridColumn() With {.FieldName = "Column" & (i + 1).ToString()})
			Next i
			listBox1.ItemsSource = columns

			Dim cusromers As New ObservableCollection(Of Customer)()
			cusromers.Add(New Customer() With {.ID = 1, .Name = "Name1"})
			cusromers.Add(New Customer() With {.ID = 2, .Name = "Name2"})
			gridControl1.ItemsSource = cusromers
		End Sub
	End Class


	Public Class Customer
		Public Property ID() As Integer
		Public Property Name() As String
	End Class
End Namespace
