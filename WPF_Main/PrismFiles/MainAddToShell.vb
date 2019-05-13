Imports Microsoft.Practices.ServiceLocation
Imports Microsoft.Practices.Unity
Imports Prism.Modularity
Imports Prism.Regions



Public Class MainAddToShell
    Implements IModule

    Private ReadOnly regionManager As IRegionManager
    Public Sub New(ByVal regionManager As IRegionManager)
        Me.regionManager = regionManager
    End Sub

    Public Sub Initialize() Implements IModule.Initialize


        Dim container = ServiceLocator.Current.GetInstance(Of IUnityContainer)
        container.RegisterType(Of [Object], Datagrid.DatagridView)("MyCustomDataGrid")
        container.RegisterType(Of [Object], SecurityMap.SecurityMapView)("SecurityMapGrid")

        container.RegisterType(Of IModelData, ModelDataService)(lifetimeManager:=New ContainerControlledLifetimeManager)
        container.Resolve(Of IModelData)


    End Sub
End Class
