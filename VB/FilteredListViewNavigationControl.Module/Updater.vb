Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.BaseImpl

Namespace FilteredListViewNavigationControl.Module
	Public Class Updater
		Inherits ModuleUpdater
		Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
			MyBase.New(objectSpace, currentDBVersion)
		End Sub
		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()
			Dim task1 As Task = ObjectSpace.FindObject(Of Task)(CriteriaOperator.Parse("Subject == 'Fix breakfast'"))
			If task1 Is Nothing Then
				task1 = ObjectSpace.CreateObject(Of Task)()
				task1.Subject = "Fix breakfast"
				task1.StartDate = DateTime.Today.AddDays(-1)
				task1.DueDate = DateTime.Today
				task1.Status = DevExpress.Persistent.Base.General.TaskStatus.Completed
			End If
			Dim task2 As Task = ObjectSpace.FindObject(Of Task)(CriteriaOperator.Parse("Subject == 'Review reports'"))
			If task2 Is Nothing Then
				task2 = ObjectSpace.CreateObject(Of Task)()
				task2.Subject = "Review reports"
				task2.StartDate = DateTime.Today
				task2.DueDate = DateTime.Today.AddDays(1)
				task2.Status = DevExpress.Persistent.Base.General.TaskStatus.InProgress
			End If
		End Sub
	End Class
End Namespace
