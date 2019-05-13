Imports System.ComponentModel

Public Class ViewModelBase
    Implements INotifyPropertyChanged


    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected Sub ExecuteOnUIThread(ByVal action As Action)

        If action IsNot Nothing Then


            Dim currrentDispatcher = Application.Current.Dispatcher

            If currrentDispatcher.CheckAccess() Then
                action()
            Else
                currrentDispatcher.BeginInvoke(action)
            End If
        End If
    End Sub




    'Protected Sub RaisePropertyChanged(Of T)(ByVal propertyExpresssion As Expression(Of Func(Of T)))
    '    Dim propertyName = PropertySupport.ExtractPropertyName(propertyExpresssion)
    '    Me.RaisePropertyChanged(propertyName)
    'End Sub

    Protected Overridable Sub RaisePropertyChanged(ByVal propertyName As String)
        Dim handler = Me.PropertyChangedEvent
        If handler IsNot Nothing Then
            handler(Me, New PropertyChangedEventArgs(propertyName))
        End If
    End Sub

    'Protected Sub OnPropertyChanged(ByVal name As String)
    '    RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(name))
    'End Sub

End Class
