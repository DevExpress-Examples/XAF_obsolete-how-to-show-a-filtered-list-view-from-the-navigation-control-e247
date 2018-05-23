Imports System.Reflection
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Model.NodeGenerators
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.Persistent.BaseImpl

Namespace FilteredListViewNavigationControl.Module

	Public NotInheritable Partial Class FilteredListViewNavigationControlModule
		Inherits ModuleBase

		Public Sub New()
			InitializeComponent()
		End Sub
		Public Overrides Sub AddGeneratorUpdaters(ByVal updaters As DevExpress.ExpressApp.Model.Core.ModelNodesGeneratorUpdaters)
			MyBase.AddGeneratorUpdaters(updaters)
			updaters.Add(New MyNavigationItemsUpdater())
		End Sub
	End Class
	Public Class MyNavigationItemsUpdater
		Inherits ModelNodesGeneratorUpdater(Of NavigationItemNodeGenerator)

		Public Overrides Sub UpdateNode(ByVal node As DevExpress.ExpressApp.Model.Core.ModelNode)
			' Create a new filtered List View: 
			Dim newView As IModelListView = node.Application.Views.AddNode(Of IModelListView)("Task_ListView_Filtered")
            newView.ModelClass = TryCast(node.Application.BOModel.GetNode(GetType(Task).FullName), IModelClass)
			newView.Criteria = "[StartDate] = LocalDateTimeToday()"
			newView.Caption = "Today Tasks"
			' Create a new Navigation Item pointing to the List View created above: 



			Dim navigationGroupItem As IModelNavigationItem = TryCast(CType(node, IModelRootNavigationItems).Items.GetNode("Tasks"), IModelNavigationItem)
			If navigationGroupItem Is Nothing Then
				navigationGroupItem = CType(node, IModelRootNavigationItems).Items.AddNode(Of IModelNavigationItem)("Tasks")
			End If

			Dim newItem As IModelNavigationItem = navigationGroupItem.Items.AddNode(Of IModelNavigationItem)()
			newItem.View = newView
			newItem.Id = "TodayTasks"
			newItem.Caption = "Today Tasks"
		End Sub
	End Class
End Namespace
