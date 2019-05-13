Namespace MainView
    Public Class ShellViewModel

        Sub New()
            NavToDatagridView = New NavigationCommand With {.PageToShow = "MyCustomDataGrid", .RegionToShowNavigation = "MyRootFrame"}
            NavToHelloButtonView = New NavigationCommand With {.PageToShow = "SecurityMapGrid", .RegionToShowNavigation = "MyRootFrame"}

        End Sub


        'hanldles datagrid nav button
        Private _navToDatagridView As ICommand
        Public Property NavToDatagridView As ICommand
            Get
                Return _navToDatagridView
            End Get
            Set(value As ICommand)
                _navToDatagridView = value
            End Set
        End Property

        Private _navToHelloButtonView As ICommand
        Public Property NavToHelloButtonView As ICommand
            Get
                Return _navToHelloButtonView
            End Get
            Set(value As ICommand)
                _navToHelloButtonView = value
            End Set
        End Property

    End Class


End Namespace