Public Class MapsService

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        EventLog1 = New EventLog()
        If (EventLog.SourceExists("MySource") = True) Then
            EventLog.CreateEventSource("MySource", "MyNewLog")
        End If

        EventLog1.Source = "MySource"
        EventLog1.Log = "MyNewLog"
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        EventLog1.WriteEntry("In OnStart.")
    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
    End Sub

End Class
