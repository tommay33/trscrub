Imports Microsoft.Practices.ServiceLocation
Imports Prism.Modularity
Imports Prism.Unity

Public Class Bootstrapper
    Inherits UnityBootstrapper

    Protected Overrides Function CreateShell() As DependencyObject
        Return ServiceLocator.Current.GetInstance(Of MainView.Shell)()

        ' Return ServiceLocator.Current.GetInstance(Of Window2)()


    End Function

    Protected Overrides Sub InitializeShell()
        MyBase.InitializeShell()


        Application.Current.MainWindow = CType(Me.Shell, Window)
        Application.Current.MainWindow.Show()
    End Sub


    Protected Overrides Sub ConfigureModuleCatalog()

        MyBase.ConfigureModuleCatalog()

        Dim moduleCatalog As ModuleCatalog = CType(Me.ModuleCatalog, ModuleCatalog)
        moduleCatalog.AddModule(GetType(MainAddToShell))



    End Sub
End Class
