Public Class ModelDataService
    Implements IModelData

    Public Function ReturnCurrentContractsToTrade() As HMCO_VIX Implements IModelData.ReturnCurrentContractsToTrade
        Dim currentData As New HMCO_VIX With {.Term1Contracts = 800,
            .Term2Contracts = 1500,
            .Term3Contracts = 900}
        Return currentData
    End Function

End Class
