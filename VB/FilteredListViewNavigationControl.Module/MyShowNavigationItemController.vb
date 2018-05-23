Imports DevExpress.ExpressApp.DC
Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Data.Filtering

Namespace HowToShowFilteredListViewFromNavigationControl.Module
	Partial Public Class MyShowNavigationItemController
		Inherits ShowNavigationItemController
		Protected Overrides Sub ShowNavigationItem(ByVal args As SingleChoiceActionExecuteEventArgs)
			MyBase.ShowNavigationItem(args)
            If (args.SelectedChoiceActionItem IsNot Nothing) AndAlso args.SelectedChoiceActionItem.Enabled.ResultValue Then
                If args.SelectedChoiceActionItem.Caption = "Today's Tasks" Then
                    Dim objectSpace As IObjectSpace = Application.CreateObjectSpace()
                    Dim collectionSource As CollectionSource = CType(Application.CreateCollectionSource(objectSpace, GetType(Task), "Task_ListView"), CollectionSource)
                    'Use the CurrentDate read-only parameter to create a criteria operator			
                    collectionSource.Criteria("CurrentDate") = CriteriaWrapper.ParseCriteriaWithReadOnlyParameters("[StartDate] = '@CurrentDate'", GetType(Task))
                    Dim view As View = Application.CreateListView("Task_ListView", collectionSource, True)
                    AddHandler view.CustomizeViewShortcut, AddressOf View_CustomizeViewShortcut
                    AddHandler view.Disposing, AddressOf view_Disposing
                    args.ShowViewParameters.CreatedView = view
                    args.ShowViewParameters.TargetWindow = TargetWindow.Current
                End If
            End If
		End Sub
		Private Sub view_Disposing(ByVal sender As Object, ByVal e As CancelEventArgs)
			Dim view As View = CType(sender, View)
			RemoveHandler view.CustomizeViewShortcut, AddressOf View_CustomizeViewShortcut
			RemoveHandler view.Disposing, AddressOf view_Disposing
		End Sub
		Private Sub View_CustomizeViewShortcut(ByVal sender As Object, ByVal e As CustomizeViewShortcutArgs)
			e.ViewShortcut.Add("Filter", "On")
		End Sub
	End Class
End Namespace
