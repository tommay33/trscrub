Imports System.Collections.ObjectModel
Imports AppCommon

Namespace SecurityMap

    Public Class SecurityMapViewModel
        Inherits ViewModelBase


        Sub New()
            Button1Text = "hi from view model"
            setup
        End Sub


        Sub setup()
            'add a record on click
            addone()
            retrieveone()

        End Sub


        Sub addone()
            'Dim rowtoadd As New Secmap With {.Id = 11, .ric = "abc", .symbol = "abc"}

            'Using dbx As New SecurityDBDataContext
            '    dbx.Secmaps.InsertOnSubmit(rowtoadd)
            '    dbx.SubmitChanges()
            'End Using

        End Sub

        Sub retrieveone()
            Dim mySecMap As List(Of Secmap)
            Using dbx As New SecurityDBDataContext
                mySecMap = (From a In dbx.Secmaps
                            Select a).ToList
            End Using

        End Sub

        Private _button1Text As String
        Property Button1Text As String
            Get
                Return _button1Text
            End Get
            Set(value As String)
                _button1Text = value
                RaisePropertyChanged("Button1Text")
            End Set
        End Property

    End Class

End Namespace
