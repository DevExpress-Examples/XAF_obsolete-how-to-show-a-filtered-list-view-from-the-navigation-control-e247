Imports Microsoft.VisualBasic
Imports System
Imports System.Reflection
Imports System.Collections.Generic
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Model.NodeGenerators
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.Persistent.BaseImpl

Namespace HowToShowFilteredListViewFromNavigationControl.Module

	Public NotInheritable Partial Class HowToShowFilteredListViewFromNavigationControlModule
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
            Dim items As IModelNavigationItems = CType(node, IModelNavigationItems)
            Dim classes As IModelList(Of IModelClass) = items.Application.BOModel            
            Dim taskNode As IModelClass = classes(GetType(Task).FullName)
			Dim view As IModelView = taskNode.DefaultListView
			Dim newItem As IModelNavigationItem = items.GetNode(Of IModelNavigationItem)("Default").AddNode(Of IModelNavigationItem)()
			newItem.View = view
			newItem.Id = "TodayTasks"
			newItem.Caption = "Today's Tasks"
		End Sub
	End Class
End Namespace
