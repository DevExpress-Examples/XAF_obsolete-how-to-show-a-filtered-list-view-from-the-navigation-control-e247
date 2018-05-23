Imports System
Imports System.Configuration
Imports System.Windows.Forms

Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Win

Imports FilteredListViewNavigationControl.Win

Public Class Program

    <STAThread()> _
    Public Shared Sub Main(ByVal arguments() As String)
#If EASYTEST Then
              DevExpress.ExpressApp.Win.EasyTest.EasyTestRemotingRegistration.Register()
#End If

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached
        Dim _application As HowToShowFilteredListViewWindowsFormsApplication = New HowToShowFilteredListViewWindowsFormsApplication()
        DevExpress.ExpressApp.Xpo.InMemoryDataStoreProvider.Register()
        _application.ConnectionString = DevExpress.ExpressApp.Xpo.InMemoryDataStoreProvider.ConnectionString
        Try
            _application.Setup()
            _application.Start()
        Catch e As Exception
            _application.HandleException(e)
        End Try

    End Sub
End Class
