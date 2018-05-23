Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Xpo
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web

Namespace FilteredListViewNavigationControl.Web
	Partial Public Class FilteredListViewNavigationControlAspNetApplication
		Inherits WebApplication

		Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
			args.ObjectSpaceProvider = New XPObjectSpaceProviderThreadSafe(args.ConnectionString, args.Connection)
		End Sub
		Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
		Private module2 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
		Private module3 As FilteredListViewNavigationControl.Module.FilteredListViewNavigationControlModule
		Private module4 As FilteredListViewNavigationControl.Module.Web.AspNetModule
		Private module6 As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
		Private sqlConnection1 As System.Data.SqlClient.SqlConnection
		Private scriptRecorderAspNetModule1 As DevExpress.ExpressApp.ScriptRecorder.Web.ScriptRecorderAspNetModule
		Private scriptRecorderModuleBase1 As DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase
		Private module5 As DevExpress.ExpressApp.Validation.ValidationModule

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub FilteredListViewNavigationControlAspNetApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch

				e.Updater.Update()
				e.Handled = True

		End Sub

		Private Sub InitializeComponent()
			Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
			Me.module2 = New DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule()
			Me.module5 = New DevExpress.ExpressApp.Validation.ValidationModule()
			Me.module6 = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
			Me.sqlConnection1 = New System.Data.SqlClient.SqlConnection()
			Me.module3 = New FilteredListViewNavigationControl.Module.FilteredListViewNavigationControlModule()
			Me.module4 = New FilteredListViewNavigationControl.Module.Web.AspNetModule()
			Me.scriptRecorderAspNetModule1 = New DevExpress.ExpressApp.ScriptRecorder.Web.ScriptRecorderAspNetModule()
			Me.scriptRecorderModuleBase1 = New DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase()
			CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
			' 
			' module5
			' 
			Me.module5.AllowValidationDetailsAccess = True
			' 
			' sqlConnection1
			' 
			Me.sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=HowToShowFilteredListViewFromNavigationContro" & "l;Integrated Security=SSPI;Pooling=false"
			Me.sqlConnection1.FireInfoMessageEventOnUserErrors = False
			' 
			' FilteredListViewNavigationControlAspNetApplication
			' 
			Me.ApplicationName = "FilteredListViewNavigationControl"
			Me.Connection = Me.sqlConnection1
			Me.Modules.Add(Me.module1)
			Me.Modules.Add(Me.module2)
			Me.Modules.Add(Me.module6)
			Me.Modules.Add(Me.module3)
			Me.Modules.Add(Me.module4)
			Me.Modules.Add(Me.module5)
			Me.Modules.Add(Me.scriptRecorderModuleBase1)
			Me.Modules.Add(Me.scriptRecorderAspNetModule1)
'			Me.DatabaseVersionMismatch += New System.EventHandler(Of DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs)(Me.FilteredListViewNavigationControlAspNetApplication_DatabaseVersionMismatch)
			CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

		End Sub
	End Class
End Namespace
