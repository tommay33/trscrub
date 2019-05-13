Create New Solution - File--New Project -- Other Visual Studio Project Types -- Select visual studio solution
Add a WPF project to the solution (WPF_Main)
Add another project for a common library (Class Library or WPF Project) (named AppCommon)
Add referece for AppCommon to WPF_Main (right click WPF_Main -- Add -- Reference -- Projects -- Check AppCommon)

Download Prism and Unity and other useful packages
   Tools- NuGet Package Manager -- Manage Packages for Solution

   Serach and install for prism.wpf,prism.unity -- On the right hand side roll back to version v6.3.0
   Install unity v 4 is installed with prism 6
   Install CommonServiceLocator v2.0.4


Set-up Prism Boilerplate Code
     In Folder PrismFiles.  Create class - Bootstrapper.   Add the listed methods which will be the entry point to the program.
							Create class - MainAddToShell.  Class implements IModule and is used to register views and services with the unity container
							To Application.xaml.vb override the onstartup method to run the Bootstrapper. REMOVE the StartupUri markup from application.xaml
										ie delete StartupUri="MainWindow.xaml"

I like to remove the root namespace. On the project right click, properties, clear root namespace. (no root namespace in c#)

Add the generic relay command and viewmodelbase classes to AppCommon.  
							ViewModelBase Implement INotifyPropertyChanged for binding
							RealyCommand is used as the implemantation of ICommand for binding methods to the view

Set-up complete - start creating
1) add new main window to host the application.  Add - New Item - Window(WPF) -- name it Shell.xaml
												Add namespace to Shell.xaml.vb, in Shell.xaml add the namespace to the x:class markup
												In Shell.xaml.vb add method sub new().  If the view is set up correctly the compliler will add initialize component ot the method
2) Add the correct name of the namespace and shell to the startup and ini routines in boostrapper.vb
3) Add a view model for the shell view and set the datacontext
						Add new class ShellViewModel.vb
						Put the view model in the same namespace as the view
						Set the datacontext of the view to the view model in Shell.xaml
								add namespace =  xmlns:vm="clr-namespace:MainView"
								set datacontext =  <Window.DataContext>
													 <vm:ShellViewModel/>
												  </Window.DataContext>
4) add a control to host views 
						Add prism mark-up  xmlns:prism="http://www.codeplex.com/prism" to shell.xaml
						Add grid rows to the xaml as an example of how to control the placement of objects
						Add text-block (just as example)
						Add content control to host other views and define a prism region for navigation
							 <ContentControl Grid.Row="1"  prism:RegionManager.RegionName="MyRootFrame"/>

5) create some usercontrols.	
						Add MVVM folders to stay organized.  Add folders named Views,ViewModels,Models and Services (I use the services as interaces which are resolved at startup and shared across the program)
						In the Views folder add new UserControl(WPF). Add namespace like above in Shell
						In the ViewModels folder add new class to control the view. Add the namespace and set as the datacontext in the View
						In Models add a class with some Properties to display. Note only properties can be bound to the View (not fields). For example the contracts to trade from the HMCO runscript
						Register usercontrol with the container in MainAddToShell
								ie.  container.RegisterType(Of [Object], Datagrid.DatagridView)("MyCustomDataGrid")

6)Create a Service the will retrieve and populate the model.
						In services create an interface and a class that implements the interface
						Register the interface with the container and start the service in the PrismFile MainAddToShell.
								ie. container.RegisterType(Of IModelData, ModelDataService)(lifetimeManager:=New ContainerControlledLifetimeManager)
									container.Resolve(Of IModelData)

7)Set up view model to display the data.  
						View Models need to implement INotifyPropertyChanges so they need to inherit ViewModelBase
						The view model can locate an interface and set it locally using ServiceLocation (C# can pass the current instance in the constructor)
						Populate the property to show on the datagrid

8) Add datagrid and binding mark-ups to the DatagridView control

9) Add a button to the Shell to navigate to the Datagridview when clicks
						In PrismFiles folder add NavigationCommand class for prism navigation
						Bind button click event to NavCommand defined in ShellViewModel

