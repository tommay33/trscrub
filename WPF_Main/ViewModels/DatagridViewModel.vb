Imports System.Collections.ObjectModel
Imports AppCommon
Imports Microsoft.Practices.ServiceLocation

Namespace Datagrid
    Public Class DatagridViewModel
        Inherits ViewModelBase

        Private _modelDataService As IModelData

        Sub New()
            _modelDataService = ServiceLocator.Current.GetInstance(Of IModelData)()
            Setup()

        End Sub

        Sub Setup()
            Dim DataToBindIncoming = New HMCO_VIX
            DataToBindIncoming = _modelDataService.ReturnCurrentContractsToTrade
            DataToBind = New ObservableCollection(Of HMCO_VIX)
            DataToBind.Add(DataToBindIncoming)
        End Sub




#Region "Properties"

        Private _dataToBind As ObservableCollection(Of HMCO_VIX)
        Property DataToBind As ObservableCollection(Of HMCO_VIX)
            Get
                Return _dataToBind
            End Get
            Set(value As ObservableCollection(Of HMCO_VIX))
                _dataToBind = value
                RaisePropertyChanged("DataToBind")
            End Set
        End Property

#End Region

    End Class
End Namespace