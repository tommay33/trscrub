Class Application


    Protected Overrides Sub onStartup(ByVal e As StartupEventArgs)
        MyBase.OnStartup(e)

        Dim bootstrapper As New Bootstrapper
        bootstrapper.Run()

    End Sub
End Class
