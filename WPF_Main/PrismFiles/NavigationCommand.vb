Imports Microsoft.Practices.ServiceLocation
Imports Prism.Regions


Public Class NavigationCommand
    Implements ICommand

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
    Public PageToShow As String
    Public RegionToShowNavigation As String
    'parameter is NavigationArgs
    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        Dim regionManager = ServiceLocator.Current.GetInstance(Of IRegionManager)()



        Dim NavTo = New Uri(PageToShow, UriKind.Relative)

        Try
            regionManager.RequestNavigate(RegionToShowNavigation, NavTo)
        Catch ex As Exception
            MsgBox(Err.Description)

        End Try

    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function

    Private Sub CheckForError(nr As NavigationResult)
        If nr.Result = False Then

        End If

    End Sub
End Class